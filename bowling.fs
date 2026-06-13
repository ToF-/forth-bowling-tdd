\ bowling.fs

variable score
variable bonus
variable super
variable last-roll
variable frame

\ initialize game state
: start
    0 score !
    0 bonus !
    0 super !
    0 frame ! ;

: collect-bonus ( n -- )
    bonus @ * score +!
    super @ bonus !
    0 super ! ;

: new-frame? ( -- f )
    frame @ 0= ;

: open-frame ( n -- )
    1+ frame ! ;

: close-frame ( -- )
    0 frame ! ;

: register-strike ( -- )
    1 bonus +!
    1 super ! ;

: register-spare ( -- )
    1 bonus ! ;

: last-roll ( -- n )
    frame @ 1- ;

: check-bonus ( n -- )
    new-frame? if
        dup 10 = if
            drop
            register-strike
            close-frame
        else
            open-frame
        then
    else
        last-roll + 10 = if
            register-spare
        then
        close-frame
    then ;

: add-roll ( n -- )
    dup collect-bonus
    dup check-bonus
    score +!  ;

: final-score ( -- n )
    score @ ;
