\ bowling.fs

variable score

\ initialize game state
: start
    0 score ! ;

: add-roll ( n -- )
    score +!  ;

: final-score ( -- n )
    score @ ;
