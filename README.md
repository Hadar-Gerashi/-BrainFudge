# BrainFudge
 
BrainFudge is a C# Interpreter/Compiler for a customized Brainfuck-like language, enabling code execution, memory management, and console output in a simple and interactive way. The project demonstrates code parsing, memory handling, and advanced C# programming concepts.

---
## Technologies
- **Language:** C#  
- **IDE / Framework:** .NET / Visual Studio  
- **Project Type:** Console Application

---

## Installation 
1. Clone the repository:  
```bash
git clone https://github.com/experis-academy/top01.hadar-gerashi.git
```

2. Open the project in Visual Studio and compile to get the executable (BrainFudge.exe).
---

## Running the Project

### 1. Running via Visual Studio:

You can run the project **directly through Visual Studio** without using the command prompt or setting PATH:

1. Open the project in Visual Studio.  
2. Click **Start (F5)** to run in debug mode, or **Start Without Debugging (Ctrl+F5)** for a normal run.  
3. The project will execute the main file (`Program.cs`) and run your code.  

- You can add **Command line arguments** in **Menu Bar > Debug > Debug Properties**, if you want to run a specific `.bf` file or enable debug mode.



### 2. Running via Command Prompt:

You can run BrainFudge using Command Prompt or PowerShell. There are two options:

- #### Normal Run
```bash
BrainFudge "path\to\your\code.bf"
# Executes all commands in the file without debug output.
```
- #### Debug Mode
```bash
BrainFudge -d "path\to\your\code.bf"
# Enables debug mode, printing memory cell info, pointer positions, and intermediate results.
```

---
## Note on PATH

To run BrainFudge from any folder (without specifying the full path), you need to add the folder containing `BrainFudge.exe` to your **PATH**:

1. Press **Windows + S**, search for **Environment Variables**, and select **Edit the system environment variables**.  
2. Click **Environment Variables**.  
3. Under **System variables**, find the variable `Path` and click **Edit**.  
4. Click **New** and enter the path to the folder containing `BrainFudge.exe`.  
5. Confirm all windows with **OK**.  
6. Open a new Command Prompt and type:
```bash
BrainFudge -d "path\to\your\code.bf"
```

---

### Supported Commands

| Command | Name        | Action |
|---------|-------------|--------|
| `>`     | MoveRight   | Move the memory pointer one cell to the right. |
| `<`     | MoveLeft    | Move the memory pointer one cell to the left. |
| `+`     | Increment   | Increase the current cell value by 1. |
| `-`     | Decrement   | Decrease the current cell value by 1. |
| `.`     | Output      | Print the current cell value as an ASCII character. |
| `,`     | Input       | Read a value from the user and store it in the current cell. |
| `[`     | LoopStart   | Begin a loop. Continue while the current cell ≠ 0. |
| `]`     | LoopEnd     | End of the loop. Jumps back to the matching `[`. |
| `^`     | Power       | Raise the previous cell value to the power of the current cell value. |
| `{`     | IfStart     | Start of an `if` block. If the current cell = 0, skip forward to the matching `:`. |
| `:`     | ElseBlock   | Else part of the conditional. If the `if` failed, execution continues here until `}`. |
| `}`     | IfEnd       | Marks the end of an `if/else` block. Execution resumes after this point. |


---

### Project Structure
```
Solution 'BrainFudge'
|
├── BrainFudge/
| ├── Properties/                 # Project properties and settings
| ├── App/                        # Main application files
| | ├── BrainFudgeApp.cs          # Application entry point
| | └── Program.cs                # Main program
| |
| ├── Commands/                   # Individual command implementations
| | ├── Command.cs
| | ├── CommandList.cs
| | ├── Decrement.cs
| | ├── ElseBlock.cs
| | ├── IfEnd.cs
| | ├── IfStart.cs
| | ├── Increment.cs
| | ├── InputChar.cs
| | ├── LoopEnd.cs
| | ├── LoopStart.cs
| | ├── MoveLeft.cs
| | ├── MoveRight.cs
| | ├── OutputChar.cs
| | └── Power.cs
| |
| ├── CoreMemory/                # Memory and data structures
| | ├── Cell.cs
| | ├── DynamicArray.cs
| | └── Memory.cs
| |
| ├── Engine/                    # Compiler, interpreter, and optimizer
| | ├── Compiler.cs
| | ├── Interpreter.cs
| | ├── Optimizer.cs
| | └── SyntaxAnalyzer.cs
| |
| ├── IO/                        # Input/Output and debugging
| | ├── CodeReader.cs
| | ├── Debugger.cs
| | ├── ITerminal.cs
| | └── Terminal.cs
| |
| └── code.bf                    # Sample Brainfuck code
|
└── BrainFudgeTests/             # Unit tests
├── Dependencies/
├── MSTestSettings.cs
└── Test1.cs

```

