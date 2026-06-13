\ tests.fs

require ffl/tst.fs
require bowling.fs

page
t{ ." no rolls result in score of zero" cr
     start
     final-score
     0 ?s
}t

t{ ." average rolls result in sum of rolls" cr
    start
    3 add-roll
    6 add-roll
    2 add-roll
    4 add-roll
    final-score 15 ?s
}t

t{ ." spare results in a bonus" cr
    start
    3 add-roll
    7 add-roll
    3 add-roll
    final-score 16 ?s
}t

tst-get-result
cr
." tests:" swap . 
."  errors:" dup .
(bye)
