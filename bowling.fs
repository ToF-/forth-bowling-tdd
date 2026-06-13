\ bowling.fs

variable score
variable bonus

\ initialize game state
: start
    0 score !
    0 bonus ! ;

: collect-bonus ( n -- )
    bonus @ * score +! ;

: check-bonus ( n -- )
    7 = if
        1 bonus !
    then ;

: add-roll ( n -- )
    dup collect-bonus
    dup check-bonus
    score +!  ;

: final-score ( -- n )
    score @ ;
