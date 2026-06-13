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
    0 frame !
    0 frame# ! ;

: bonus>>factor ( -- n )
    bonus @ dup 3 and
    swap 2/ 2/ bonus ! ;

: collect-bonus ( n -- )
    bonus>>factor * score +! ;

: new-frame? ( -- f )
    frame @ 0= ;

: open-frame ( n -- )
    1+ frame ! ;

: close-frame ( -- )
    1 frame# +!
    0 frame ! ;

: register-strike ( -- )
    bonus @ 1+ 4 or bonus ! ;

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
