\ tests.fs

require ffl/tst.fs
require bowling.fs

page
t{
     ." no rolls result in score of zero" cr
     start
     final-score
     0 ?s
}t

tst-get-result
cr
." tests:" swap . 
."  errors:" dup .
(bye)
