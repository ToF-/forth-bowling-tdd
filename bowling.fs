\ bowling.fs

variable score
variable bonus
variable next-bonus
variable frame  \ 0: new-frame {1…10}: open frame, last roll = value minus 1
variable frame#

\ initialize game state
: start
    0 score !
    0 bonus !
    0 next-bonus !
    0 frame !
    0 frame# ! ;

15 constant roll-mask
16 constant frame-mask

\ get bonus factor and update bonuses
: bonus>>factor ( -- n )
    bonus @
    next-bonus @ bonus ! ;

\ add bonus roll(s) to score
: collect-bonus ( n -- )
     bonus>>factor * score +! ;

: new-frame? ( -- f )
    frame @ 0= ;

\ update frame with roll just played
: open-frame ( n -- )
    frame-mask or frame ! ;

\ update frame to a new frame
: close-frame ( -- )
    1 frame# +!
    0 frame ! ;

\ sets the bonus factors after a strike :
\ next roll increments, next next roll set to 1
: register-strike ( -- )
    1 bonus +!
    1 next-bonus ! ;

\ sets the bonus factor after a spare
: register-spare ( -- )
    1 bonus ! ;

: last-roll ( -- n )
    frame @ roll-mask and ;

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
