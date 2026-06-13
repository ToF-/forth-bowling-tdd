\ bowling.fs

variable score
variable bonus
variable last-roll

\ initialize game state
: start
    0 score !
    0 bonus !
    0 last-roll ! ;

: collect-bonus ( n -- )
    bonus @ * score +! ;

: check-bonus ( n -- )
    last-roll @ + 10 = if
        1 bonus !
    then ;

: add-roll ( n -- )
    dup collect-bonus
    dup check-bonus
    dup last-roll !
    score +!  ;

: final-score ( -- n )
    score @ ;
