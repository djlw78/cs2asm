# cs2asm
cs2asm is a operating system development tool that compiles CS files to Assembly code. This way you can write an operating system in c#. Let's dicuss one more thing, there is another devkit that is commonly known called Cosmos, we decided to make cs2asm because cosmos has methods that are good for development but run to slow for our expectations, and the other devkit called FlingOS is slightly outdated, and unmaintained so we just decided to develop our own.

## The Process
The process is simple... We are creating our compiler in c#, the compiler will take a c# file and convert it into CIL codes, and from there we will convert the CIL codes into Assembly code.
