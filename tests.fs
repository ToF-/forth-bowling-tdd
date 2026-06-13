\ tests.fs

require ffl/tst.fs

t{
     ." dummy test" cr
     2 2 + 4 ?s
}t

tst-get-result
cr
." tests:" swap . 
."  errors:" dup .
(bye)
