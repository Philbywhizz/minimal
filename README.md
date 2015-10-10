Minimal Forth Workbench 
=======================

Ulrich Hoffmann <<uho@xlerb.de>>

Version 1.0.0 - 2015-10-10

This package provides a workbench implementation of **Minimal Forth** as proposed by
Paul Bennett and Peter Knaggs at [EuroForth 2015][EuroForth2015] in Bath.

Their aim is to define a Standard Forth subset suitable for educational purposes.
For this they propose to cut down the number of Forth words initially explained to
Forth newcomers and only stepwise introduce new concepts such as number output, compiling
words, strings, file access, exceptions, ...

This package - the **Minimal Forth Workbench** - allows to experiment with different sets of primitive (i.e. predefined) 
definitions in order to further elaborate on Paul's and Peter's ideas.

## Implementation

This implementation picks the appropriate words from a Standard (Forth 94 oder Forth
2012) system (the so called _host_ system) and puts them in a wordlist of their own 
named `minimal`.
In the end, this wordlist is defined to become the only wordlist in the search 
order and also the current wordlist. In essence this makes all other word definitions
from the host system unavailable to the Minimal Forth Workbench.

The source code is seperated into several files:

1. The primitive words of Minimal Forth, to take from the host system. They are defined in the file `primitives.fs`

2. Words of Minimal Forth that can be defined in terms of primitives and other Minimal 
Forth words, i.e. _"All that can be built from the primitives"_. They are defined in the file `prelude.fs`

3. The implementation of the word `PRIMITIVE` and the overall setup: file `minimal.fs`.

As currently setup, the words defined in `primitives` and `prelude` are exactly
the words proposed by Paul and Peter with 69 Minimal Forth words.

In addition the words `INCLUDE`, `WORDS`, `PRIMITIVE`, and `BYE` 
that we consider more development environment than language are available. 
They are not included in the primitives and word counts.

Many other definitions are currently commented out, such as
`POSTPONE`, `IMMEDIATE`, `>BODY`, `SLITERAL`, `LITERAL`, and `COMPILE,` which
are the basis of compiling words like `S"`´, `AGAIN` or `?EXIT`.

Your are invited to experiment: remove or add primitives or modífy, add, remove definitions in `prelude`.
Please, share your findings.


## Installation

To use the Minimal Forth workbench just `INCLUDE minimal.fs` on any standard system. This makes
the Minimal Forth definitions and only them available. After loading, all defined words still
have their standard meaning - however Minimal Forth is no standard system itself
as it does not provide all definitions from the CORE word set.

## Example usage

    $ sf minimal.fs 

    Minimal Forth Workbench: 48 primitives, 69 words
     ok
    words ALIGNED CELL+ CHAR+ ROT 2/ LSHIFT XOR OR > = 0= TRUE FALSE MOD 2* / * + VARIABLE 
    CONSTANT DUP primitive WORDS INCLUDE bye \ .S ( CR KEY? EMIT KEY DOES> ; CREATE : 
    EXECUTE J LOOP UNTIL AGAIN BEGIN ELSE ' I DO REPEAT WHILE THEN IF R> OVER DROP R@ >R 
    SWAP RSHIFT INVERT AND < - */MOD CHARS CALIGNED CALIGN C@ C, C! CELLS ALIGN @ , ! 
    48 primitives, 69 words ok


## Bug Reports

Please send bug reports, improvements and suggestions to Ulrich Hoffmann <<uho@xlerb.de>>

## Conformance

This program conforms to Forth-94 and Forth-2012. It has been verified to load 
succesfully on SwiftForth, iForth and gForth.

May the Forth be with you!

[EuroForth2015]: http://www.rigwit.co.uk/EuroForth2015/
