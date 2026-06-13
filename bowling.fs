\ bowling.fs

variable score
variable bonus
variable super
variable last-roll
variable frame-limit

\ initialize game state
: start
    0 score !
    0 bonus !
    0 super !
    0 frame-limit !
    0 last-roll ! ;

: collect-bonus ( n -- )
    bonus @ * score +!
    super @ bonus !
    0 super ! ;

: new-frame? ( -- f )
    frame-limit @ 0= ;

: close-frame ( n -- )
    last-roll !
    1 frame-limit ! ;

: open-frame ( -- )
    0 frame-limit ! ;

: register-strike ( -- )
    1 bonus +!
    1 super ! ;

: check-bonus ( n -- )
    new-frame? if
        dup 10 = if
            drop
            register-strike
        else
            close-frame
        then
    else
        last-roll @ + 10 = if
            1 bonus !
        then
        open-frame
    then ;

: add-roll ( n -- )
    dup collect-bonus
    dup check-bonus
    dup last-roll !
    score +!  ;

: final-score ( -- n )
    score @ ;
