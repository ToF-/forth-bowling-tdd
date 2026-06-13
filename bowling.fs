\ bowling.fs

variable score
variable bonus
variable super
variable frame
variable frame#

\ initialize game state
: start
    0 score !
    0 bonus !
    0 super !
    0 frame !
    0 frame# ! ;

: collect-bonus ( n -- )
    bonus @ * score +!
    super @ bonus !
    0 super ! ;

: new-frame? ( -- f )
    frame @ 0= ;

: open-frame ( n -- )
    1+ frame ! ;

: close-frame ( -- )
    1 frame# +!
    0 frame ! ;

: register-strike ( -- )
    1 bonus +!
    1 super ! ;

: register-spare ( -- )
    1 bonus ! ;

: last-roll ( -- n )
    frame @ 1- ;

: check-for-strike ( n -- )
    dup 10 = if
        drop
        register-strike
        close-frame
    else
        open-frame
    then ;

: check-for-spare ( n -- )
    last-roll + 10 = if
        register-spare
    then
    close-frame ;

: check-bonus ( n -- )
    new-frame? if
        check-for-strike 
    else
        check-for-spare
    then ;

: within-game? ( -- f )
    frame# @ 0 10 within ;

: add-roll ( n -- )
    dup collect-bonus
    dup check-bonus
    within-game? if
        score +!
    else
        drop
    then ;

: final-score ( -- n )
    score @ ;
