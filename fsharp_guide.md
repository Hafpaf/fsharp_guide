<!--
    Guide to Fsharp (F#) written in markdown
    
    Copyright (C) <2019>  <hafpaf haf@hafnium.me>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
-->

# F\# notes
**This is by no means a comprehensive list of FSharp syntax,** but it will be updated as I learn more about the language.

# Table of contents
- [F\# notes](#f-notes)
- [Table of contents](#table-of-contents)
  - [Install F\# and mono](#install-f-and-mono)
    - [Manjaro](#manjaro)
    - [Arch Linux](#arch-linux)
  - [Your first F\# program](#your-first-f-program)
  - [Run and compile](#run-and-compile)
    - [Fsharpc inputs](#fsharpc-inputs)
      - [Compile flags](#compile-flags)
  - [Printf](#printf)
    - [Printf values](#printf-values)
    - [Printf properties](#printf-properties)
    - [Padded formatting](#padded-formatting)
    - [Print multiple items in one print statement](#print-multiple-items-in-one-print-statement)
    - [Print out a selected item from a list](#print-out-a-selected-item-from-a-list)
  - [Lists](#lists)
  - [Libraries and signature files](#libraries-and-signature-files)
    - [Modules](#modules)
    - [Libraries](#libraries)
      - [Import library](#import-library)
      - [Compile a library](#compile-a-library)
      - [Compile program with library](#compile-program-with-library)
    - [Signature files](#signature-files)
    - [Library example](#library-example)
  - [Functions](#functions)
    - [Anonymous functions](#anonymous-functions)
    - [Recursive functions](#recursive-functions)
      - [Recursion with lists](#recursion-with-lists)
- [Resources](#resources)

## Install F\# and mono
### Manjaro
```bash
pamac build fsharp-bin && pamac install mono
```

### Arch Linux
```bash
yay -S fsharp-bin mono
```

## Your first F\# program
- Open you favorite editor.
- Create a file called `helloworld.fsx`
- create a print statement and print a string with:
  - ```FSharp
    let a = "Hello world"
    printfn "Printing: %s" a
    ```
  - `let`: creates here a string with the text "hello world"
  - `a`: is the name of the variable
  - `printfn`: prints out in the terminal
  - `"Printing: %s"`: print a string with the input `%s` where the value for `%s` is `a`
- Go to your terminal and run the program with
  -  fsharpi `helloworld.fsx`


## Run and compile
```bash
fsharpc --nologo helloworld.fsx && mono helloworld.exe
```
Compile the program `helloworld.fsx` and run with mono
### Fsharpc inputs
#### Compile flags
```bash
OUTPUT FILES
    --target:library, -a
            Build a library
```
```bash
INPUT FILES
     --reference:file, -r file
            Reference an assembly
```

To **compile libraries** and compile programs with libraries, see "[Compile a library](#compile-a-library)", under Libraries and Signature files

## Printf

`printf` prints out a formatted output to stdout, this means an output that is formatted to your liking.

### Printf values
There exists a lot of print values. If you only need to print out without formatting then use `printfn`, which create a newline after printing out. You can read more about print values [here](https://msdn.microsoft.com/visualfsharpdocs/conceptual/core.printf-module-[fsharp]#values).

To print out an variable in the form of the integer 2 could be printed out like this. 

```FSharp
let a = 2
printfn "%i" a
```

Output:
```FSharp
2
```

To add some text to the print statement, you could add it withing the quotation marks (`" "`).

```FSharp
let a = 2
printfn "This integer has the value %i" a
```

Output:
```FSharp
This integer has the value 2
```

Or you could print a string and an integer in the same print value.

```FSharp
let a = "Hello World"
let b = 1273
printfn "%s %i" a b
```

Output
```FSharp
Hello World 1273
```

Notice how we use `%s` and `%i`. These are print properties, `%s` stands for string and `%i` stands for integer. We use this to tell the F\# compiler that we expect the output to be respectively a string and an integer. If they, however are NOT the expected out, the compiler will throw an error. 

### Printf properties

Formatting print statements from [C\# Corner](https://www.c-sharpcorner.com/article/printing-and-formatting-outputs-in-fsharp/).
Also check out the official [documentation on Github](https://github.com/MicrosoftDocs/visualfsharpdocs/blob/live/docs/conceptual/core.printf-module-[fsharp].md#remarks).

The line: `printfn "text: %s" a`, prints out a string containing the string `a`.


    %s for strings
    %b for bools
    %i or %d for signed ints
    %u for unsigned ints
    %f for floats
    %A for pretty-printing tuples, records and union types, BigInteger and all complex types
    %O for other objects, using ToString()
    %x for lowercase hex 
    %X for UPPERCASE hex
    %o for octal
    %f for floats standard format
    %e or %E for exponential format
    %g or %G for the more compact of f and e.
    %M for decimals

### Padded formatting

    %0i pads with zeros
    %5i pads with 5 spaces
    %+i shows a plus sign
    % i shows a blank in place of a plus sign


### Print multiple items in one print statement

Specify properties for each variable that needs to be printed
```fsharp
let a = 2
let b = 3
do printfn "%d %d" a b
```

### Print out a selected item from a list
```fsharp
let list0 = [7;3;11;9]
do printfn "list0.Item(2) is %d" (list0.Item(2));;
```

## Lists 
NOTE: Lists are immutable
```FSharp
let lst = [1;2;3;4]
let lst = 5 :: List.tail (List.tail lst)
```
List properties
```Fsharp
// Empty list: []
// Add element: ::
// Addition of two elements: @ 
```
## Libraries and signature files
In F\# it can useful to explicitly describe what type your functions input and output should be. If these requirements is not fulfilled, the compiler will throw an error. Libraries and signature is an effective way to describe these.

A library file uses the file extension `.fs` and the signature file extension uses `.fsi`.

### Modules

Read more: [Ms docs: Modules](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/modules)

The program below takes a list of lists and return one (1) list.
```FSharp
let concat (llst:'a list list) : 'a list = 
    List.concat llst
printfn "Concatunated list: %A" (concat [[1]; [7; 3]; [5]])
```

The input called `llst` requires the type `'a list list`, a list of lists. While the output is required to be `a list`, a single list.

### Libraries

File extension: `.fs`

A library is a collection of predefined *types*, *values* and *functions* which is usable by F\# programs. The code have already specified what the function `len` should do. We can call the function with the required parameters to run it.

```FSharp
// Calculate length of a vector
let len (a : float * float) : float =
  sqrt (fst a **2.0 + snd a**2.0)
```
The above function requires input `a` to be have two (2) float values, in this case is the x and y coordinate of a vector. The output is also required to be a float. 

It is also important to look at `fst` (first) and `snd` (second) from the code sample, these are the specify if we are dealing with the first float or the second float, since they cannot be expected have the same value.

#### Import library

Read more: [Ms docs: 'Import Declarations: The open Keyword'](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/import-declarations-the-open-keyword)

We can call the function `len` to our program by importing a compiled version of out library with the function `open <libraryName>`.

```FSharp
open Utilities.vectors

printfn "vector length: %f" (Utilities.vectors.len(2.0,3.0))
```

#### Compile a library
```bash
#Compiler flags
# -a: --target:library, Build a library
# --out:my_library.dll: Name the output file

#Compile library with a signature file
fsharpc --nologo signature_file.fsi library_functions.fs -a --out:my_library.dll
```
#### Compile program with library
```bash
#Compile program with library
fsharpc --nologo -r my_library.dll program.fsx && mono program.exe
```

### Signature files

File extension: `.fsi`. [MS docs: Signatures](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/signature-files).

### Library example
Look at the files in [./examples/libraries/](./examples/libraries/)

```bash
#Compile library with a signature file
[libraries]$ fsharpc --nologo vectors.fsi vectors.fs -a --out:vectors.dll

#Compile program with the library and run it
[libraries]$ fsharpc --nologo -r vectors.dll vector_test.fsx && mono vector_test.exe

#Output
vector length: 3.605551
```

## Functions

### Anonymous functions
Use the `fun` argument
```FSharp
let vs = List.map (fun x -> x+1) [10; 20; 30]
```

### Recursive functions
A function being called within it self.

A recursive function must me called with `rec`.
```fsharp
/// print every second number to 20
let rec function_name a b =
    if a > b 
    then printfn "Stopping"
    else
        printfn "%A" a
        function_name (a + 2) b
        

function_name 1 20
```
#### Recursion with lists
```fsharp
/// Not working yet, missing anonymous function //// List
let rec find p xs =
    if List.isEmpty xs
    then None
    else if p (List.head xs)
        then Some (List.head xs)
        else find p (List.tail xs)

let xs [1;2;3]
printfn // anon fun
```

# Resources
- A general help is to look in the Microsoft Fsharp [documentation](https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/visual-fsharp) and Fsharp [Language Reference](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/)
- [Lists](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/lists)
- [printfn on fsharpforfunandprofit.com](https://fsharpforfunandprofit.com/posts/printf/)
- [printf documentation on Github.com](https://github.com/MicrosoftDocs/visualfsharpdocs/blob/live/docs/conceptual/core.printf-module-[fsharp].md#remarks)
- [index](https://www.tutorialspoint.com/fsharp/fsharp_lists.htm)
- [C\# Corner: printing and formatting outputs in F\#](https://www.c-sharpcorner.com/article/printing-and-formatting-outputs-in-fsharp/)
- [Signatures](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/signature-files)
- [Modules](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/modules)
- [Import Declarations: The open Keyword](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/import-declarations-the-open-keyword)