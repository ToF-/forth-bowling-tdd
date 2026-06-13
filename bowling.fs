\ bowling.fs

variable score
variable bonus  \ 1: spare  5: strike 6: cumulated strikes
variable frame  \ 0: new-frame {1…10}: open frame, last roll = value minus 1
variable frame#

\ initialize game state
: start
    0 score !
    0 bonus !
    0 frame !
    0 frame# ! ;

\ get bonus factor and update bonuses
: bonus>>factor ( -- n )
    bonus @ dup 3 and
    swap 2/ 2/ bonus ! ;

\ add bonus roll(s) to score
: collect-bonus ( n -- )
    bonus>>factor * score +! ;

: new-frame? ( -- f )
    frame @ 0= ;

\ update frame with roll just played
: open-frame ( n -- )
    1+ frame ! ;

\ update frame to a new frame
: close-frame ( -- )
    1 frame# +!
    0 frame ! ;

\ sets the bonus factors after a strike :
\ next roll increments, next next roll set to 1
: register-strike ( -- )
    bonus @ 1+ 4 or bonus ! ;

\ sets the bonus factor after a spare
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
