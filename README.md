# IVS-proj2 | Sunny-Calc

A calculator created for the [second project](http://ivs.fit.vutbr.cz/projekt-2_tymova_spoluprace2019-20.html) in the [IVS course](https://www.fit.vut.cz/study/course/13372/.en)

## Installation

There is currently nothing no install :(

## Usage

## Profiling

The `SunnyCalc.Profiling` project contains a simple utility that calculates variance of a set of numbers.
The project also contains a simple integrated profiler. It can be used in two modes.

By default, it is supposed to be used with external profiling tools. It behaves as defined in the project specification.
The executable consumes floating-point numbers from _stdin_ until it reaches `EOF`.
(One number per line, lines that don't contain a number are ignored.)
Then it calculates the variance of the input numbers and outputs it to _stdout_ (the number is formatted using current system culture settings).
 
If the program is run with a `-s [file]` argument, the integrated profiler is enabled.
It will output the profiling results to the specified file, or to _stderr_ if `-` is used as the file name.

In both cases, the program will read its input from a file instead of reading from _stdin_ when a file name
is supplied as the last argument.

## Authors
#### Pracovní skupina Sluníčka
František Nečas (xnecas27) \
Ondřej Ondryáš (xondry02) \
David Chocholatý (xchoch08)

## License

The project is licensed under GNU GPLv3.
