<div style="display: flex; justify-content: space-around;">
    <img style="" src="./assets/Term.png" alt="TERM" height="150"></img>
</div>

<div style="display: flex; justify-content: space-around;">
    <h3>Save configs in text files and use them in C#!</h3>
</div>

**Term** is a simple interpreter that can convert key-value pairs defined in text to C# dictionaries.

***You can find here:***
- [Setup](#1-setup)
- [Docs](#docs)
- [Term's Syntax](#syntax)
- [Features coming soon](#coming-soon)
- [License](#license)

----------

<h1 align="center">Getting Started</h1>

> <!> This guide assumes that your project contains a csproj file.
## 1. Setup

<span style="font-size: 1.4rem;">**First**</span>, you have to download the `Term.dll` from the **latest** realease.

> <!> You can also `git clone` this repository and **compile** it yourself using:
> ```bash
> dotnet build --configuration Release
> ```

When you're ready, copy `Term.dll` to your project.

<span style="font-size: 1.4rem;">**Next**</span>, you have to add a **reference** to the file `(Term.dll)`.

To do that, add this to your `csproj`:
```xml
<ItemGroup>
    <Reference Include="Term">
        <HintPath>PATH/TO/TERM.dll</HintPath>
    </Reference>
</ItemGroup>
```
> <!> Replace "PATH/TO/TERM.dll" with the path where the `dll` is in your project.

> <!> If you're using **Visual Studio**, you can add the reference via **Visual Studio's GUI**.

That's it! You've successfully finished the setup. Continue in the [docs](#docs).

> Any problems during the setup? **Check the setup guide again**. Still have problems? Post an **issue** so I can help you!

----------

<h1 id="docs" align="center" id="docs">Docs</h1>

Jump to the [example](#example).

## Namespaces
```csharp
namespace Term;
```
----------

## Classes
```csharp
namespace Term;

public static class TermInterpreter { }
```
The interpreter itself.

<span style="font-size: 1.2rem;">**Methods**</span>:

1. ```csharp
    public static Dictionary<string, string> Interpret(string path)
    ```
    The Interpreter's method. `This` method reads a `Term` file located at a specified path and `returns` a `Dictionary` containing the keys and values that were found.

   1. ### Parameters:
      1. `path`<br>**Type**: `string`<br>Description: The absolute path to the file that will be interpreted.
   2. ### Returns
        ```csharp
        new Dictionary<string, string>
        ```
        A dictionary containing the keys and values that were found in the file.

<br/><br/>

2. ```csharp
    public static void WriteToFile(string path, Dictionary<string, string>  termContent, bool replaceContent = true)
    ```
    Writes a `dictionary` into a term file.

    It automatically generates `Term configs`
    based on the dictionary provided.

    The method will also format correctly any key in
    the dictionary.
    So if the dictionary contains a key named
    "`My Key`" it will be formatted to 
    "`my_key`" before writing
    it to the file.

    1. ### Parameters:
       1. `path`<br/>**Type**: `string`<br/>Description: The absolute path to the term file to write into.
       2. `termContent`<br/>**Type**: `Dictionary<string, string>`<br/>Description: The content that will be written in the file.
       3. `replaceContent`<br/>**Type**: `bool`<br/>Description: If `true`, replace all the contents in the term file.<br/><br/> if `false`, append all the contents to the end of the file with a comment "`# Written from C#:`".<br/><br/>This parameter is optional. Defaults to `true`.
    

----------

<h1 id="syntax" align="center">Term's syntax</h1>

1. ### Comments
   Comments in `Term` are really simple.
   
   Every line starting with a `#` it's a comment and it's going to be ignored by the `Interpreter`.
   
   Example:
   ```term
   # This is a comment
   ```

2. ### Configs
   **Configs** are made of **key-value** pairs.

   A `config` is how we call these key-value pairs in `Term`.

   The key is separeted from the value by this symbol: `->`

   Example:
   ```term
   my_key -> My value
   ```

   It's important that these `configs` are declared on a **single line**, otherwhise it can cause errors.

### Important aspects:
   1. Any empty line found in the `Term` file is going to be ignored by the `Interpreter`.
   2. The keys should be named using `snake_case`.
   3. `string` values don't need to be surrounded by `""`.

----------

## Example

Let's code a simple example using `Term`.

Assuming we already created a dotnet project and we did the [setup](#1-setup)...

<div id="configs-here"></div>

**First**, let's start by creating our `Term` file and writing some configs:
```term
# Epic configs going here

# Window
window_title -> My Window
window_color -> LIMEGREEN

# User
username -> YisusGaming
epic_stuff -> Yes it's epic
```
Now, let's save this file, in my case, I'm saving the `Term` file next to my `Program.cs` file.

<div id="file-structure"></div>

The **file structure** is something like this:
```
Project Folder
    | Program.cs
    | Term.dll
    | test.term
    | project.csproj
```
> Note: `test.term` is the name I gived to the file.

Ok, let's go into the `Program.cs`.

First, we have to make sure the `Term` namespace is being use in the `C#` file:
```csharp
using Term;
```

That way, we can use the `Interpret` method from the `TermInterpreter` class.

Now, the `Interpret` method needs one argument: The `path` to the file that will be interpreted. In order to give it the path, we can use the `Path.GetFullPath()` method included in `C#`.

In my case, It will be something like this:
```csharp
string path = Path.GetFullPath("test.term");
```
> Note: This is inside of `C#`'s `Main` method.

We call `Path.GetFullPath` and we pass in the path to our `Term` file, relative to the project's folder.
> <!> Remember: The file structure in this example is like [this](#file-structure).

Now that we got the `Term`'s file path, we can call `TermInterpreter.Interpret` and give it the path!

```csharp
Dictionary<string, string> load = TermInterpreter.Interpret(path);
```

> Notice that, I'm creating a variable called `load` to store the `Dictionary` that this method returns.

And we're done! The `Interpret` method does everything for us and returns a `Dictionary` with the keys and values in our term file!

That means: Now we can access these values using the keys.

For example: We can now access the config we created [before](#configs-here) called `window_title` and print the value in console:
```csharp
Console.WriteLine(load["window_title"]);
```
> <!> Remember: `load` was the name I give to my `Dictionary` with all the keys and values.

And should print us the value of `window_title`!

Full code of the Example:
```csharp
using System;
using System.Collections.Generic;
using Term;

namespace MyProgram
{
    class Program
    {
        public static void Main(string[] args)
        {
            string path = Path.GetFullPath("test.term"); // Get the full path from a path relative to our project's folder
            Dictionary<string, string> load = TermInterpreter.Interpret(path); // Interpret the file
            Console.WriteLine(load["window_title"]); // Should print the value!
        }
    }
}
```
## Important notes
1. You may get errors by trying to accessing a keys that isn't in the returned dictionary. This can happend for reasons like the key being not defined at the term file.

    You can manage these errors as you want.

> Any problems during the example? **Check the example again**. Still have problems? Post an **issue** so I can help you!

----------

<h1 id="coming-soon" align="center">Coming soon</h1>

1. Arithmethic operations in `Term` values.

----------

<h1 id="license" align="center">License</h1>
<a rel="license" href="http://creativecommons.org/licenses/by-nc-nd/4.0/"><img alt="Creative Commons License" style="border-width:0" src="https://i.creativecommons.org/l/by-nc-nd/4.0/88x31.png" /></a><br /><span xmlns:dct="http://purl.org/dc/terms/" property="dct:title">Term</span> by <span xmlns:cc="http://creativecommons.org/ns#" property="cc:attributionName">YisusGaming</span> is licensed under a <a rel="license" href="http://creativecommons.org/licenses/by-nc-nd/4.0/">Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International License</a>.