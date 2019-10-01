# F\# notes
**This is by now means a comprehensive list of FSharp syntax,** but it will be updated as i learn more about the language.

## Install F\# and mono on Arch linux or Manjaro
```bash
pamac install fsharp-bin mono
```
or
```bash
sudo pacman -S fsharp-bin mono
```

## Your first F\# program
- Open you favorite editor.
- Create a file called `helloworld.fsx`
- create a print statement and print a string with:
  - ```FSharp
    let a = "Hello world
    printfn "Printing: %s" a
    ```
  - `let`: creates here a string with the text "hello world"
  - `a`: is the name of the variable
  - `printfn`: prints out in the terminal
  - `"Printing: %s"`: print a string with the input `%s` and and the value for `%s` is `a`
- Go to your terminal and run the program with
  -  fsharpi `helloworld.fsx`


## Run and compile
```bash
fsharpc --nologo helloworld.fsx && mono helloworld.exe
```
Compile the program `helloworld.fsx` and run with mono
### Fsharpc inputs
#### fsharpc flags
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

##### Compile a library
```bash
#Compiler flags
# -a: --target:library, Build a library
# --out:vec2d.dll: Name the output file

#Compile library with a sigtnature file
fsharpc --nologo signature_file.fsi library_functions.fs -a --out:my_library.dll
```
##### Compile program with libray
```bash
#Compile program with library
fsharpc --nologo -r my_library.dll program.fsx && mono program.exe

```


## Printfn

### Printfn properties
Formatting print statements from [C\# Corner](https://www.c-sharpcorner.com/article/printing-and-formatting-outputs-in-fsharp/)

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

Padded formatting

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
.fsi

.fs

To compile se, 'Compile with library' under Fsharpc
## Functions

### Anonymous functions
Use the `fun` argument
```FSharp
let vs = List.map (fun x -> x+1) [10; 20; 30]
```

## Resources
- [Lists](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/lists)
- [printfn](https://fsharpforfunandprofit.com/posts/printf/)
- [index](https://www.tutorialspoint.com/fsharp/fsharp_lists.htm)
- [C\# Corner: printing and formatting outputs in F\#](https://www.c-sharpcorner.com/article/printing-and-formatting-outputs-in-fsharp/)