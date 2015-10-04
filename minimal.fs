\ Minimal Forth word set                    uh 2015-10-04

: min-n ( -- x )
    -1 BEGIN dup 2* dup WHILE  swap drop REPEAT drop ;

: U2/ ( u -- u )  2/  [ min-n invert ] Literal and ;

: tick (  <spaces>name<spaces> -- xt f )
    state @  ] bl word find rot IF ] ELSE POSTPONE [ THEN ;

: immediate-alias ( xt <spaces>name<spaces> -- )
    CREATE , immediate DOES> @ EXECUTE ;

: non-immediate-alias ( xt <spaces>name<spaces> -- )
    CREATE , immediate DOES> @ state @ IF compile,  ELSE  EXECUTE THEN ;

variable #primitive  0 #primitive !

wordlist Constant minimal

: primitive ( <space>ccc<space> -- )
    get-order
    forth-wordlist 1 set-order
    1 #primitive +!
    >in @  tick  rot >in !  0< IF non-immediate-alias ELSE immediate-alias THEN
    set-order ;

: :?  >in @  parse-name find-name IF  drop  postpone \  ELSE  >in !  : THEN ;

minimal set-current

primitive !
primitive ,
primitive @
primitive ALIGN
\ primitive ALIGNED
primitive CELL+
primitive CELLS
primitive C!
primitive C,
primitive C@
: CALIGN ;
: CALIGNED ;
\ primitive CHAR+
primitive CHARS

primitive */MOD
primitive -
primitive 2/
primitive u2/

\ primitive 0=
primitive <
primitive AND
primitive INVERT

\ primitive DUP
primitive SWAP
primitive >R
primitive R@
primitive DROP
primitive OVER
primitive R>

primitive IF
primitive THEN
primitive WHILE
primitive REPEAT
primitive DO
primitive I
primitive '
primitive ELSE
primitive BEGIN
\ primitive AGAIN
primitive UNTIL
primitive LOOP
primitive J
primitive EXECUTE

primitive :
primitive CREATE
primitive ;
primitive DOES>

primitive KEY
primitive EMIT
primitive KEY?
primitive CR

primitive (
primitive .S
primitive \

primitive bye
primitive INCLUDE
primitive WORDS
\ primitive order

primitive POSTPONE
primitive IMMEDIATE
primitive >BODY

primitive SLITERAL
primitive LITERAL
primitive COMPILE,

primitive PARSE

primitive EXIT

primitive primitive
primitive :?

get-order ' set-order
minimal 1 set-order 

include prelude.fs

execute
cr .( Minimal Forth word set activated: )  #primitive @ . .( primitives )  cr
minimal 1 set-order
