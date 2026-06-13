\ bowling.fs

variable score
variable bonus
variable super
variable last-roll

\ initialize game state
: start
    0 score !
    0 bonus !
    0 super !
    0 last-roll ! ;

: collect-bonus ( n -- )
    bonus @ * score +!
    super @ bonus !
    0 super ! ;

: check-bonus ( n -- )
    dup 10 = if
        drop
        1 bonus !
        1 super !
    else last-roll @ + 10 = if
        1 bonus !
    then then ;

: add-roll ( n -- )
    dup collect-bonus
    dup check-bonus
    dup last-roll !
    score +!  ;

: final-score ( -- n )
    score @ ;
