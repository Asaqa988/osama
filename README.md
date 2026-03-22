# Canvas Command Drawer

## Description

This project uses the provided BOOSE.dll as the drawing engine while implementing additional design patterns such as Command and Factory.

This is a C# Windows Forms application that processes text-based drawing commands. Users can type commands into a text box, and the application parses and executes them to dynamically draw shapes on a graphical canvas.

## Features

The application currently supports the following commands:

- `moveto x,y`: Moves the drawing pen to the specified X and Y coordinates without drawing a line.
- `drawto x,y`: Draws a line from the current pen position to the specified X and Y coordinates.
- `circle x,y,radius`: Draws a circle centered at the specified coordinates with the given radius.
- `rectangle x,y,width,height`: Draws a rectangle starting from the given X, Y coordinates with the specified width and height.

## Architecture

This project is built using clean object-oriented principles with the following design choices:

- **Command Pattern**: Encapsulates drawing operations into specific classes (like `MoveToCommand`, `RectangleCommand`) that implement a unified `ICommand` interface.
- **Factory Pattern**: A `CommandFactory` parses user input strings and instantiates the appropriate command objects to keep creation logic separate.
- **DrawingState Usage**: A shared `DrawingState` object tracks the current position of the pen across sequential commands.
- **Separation of Concerns**: The graphical interface (WinForms) is completely decoupled from parsing logic and drawing implementations.

## How to Run

To build and run the application locally using the .NET CLI:

1. Open a terminal in the project directory.
2. Compile the project:
   ```shell
   dotnet build
   ```
3. Launch the application:
   ```shell
   dotnet run
   ```

## Example Usage

When the application opens, paste the following sequence into the top text box and click the **Run** button:

```text
moveto 50,50
drawto 200,200
circle 200,200,50
rectangle 100,100,150,80
```

## Testing

The application includes a robust set of automated unit tests using the **xUnit** framework. The tests verify:

- The `CommandFactory` accurately parses raw text into command objects.
- Commands reliably update the internal `DrawingState` as expected.
- Safe handling of dummy graphical environments without requiring a UI.

## Error Handling

Input is thoroughly validated at creation. The system guards against invalid numbers, missing parameters, and negative coordinates by throwing structured exceptions (`ArgumentException`, `ArgumentOutOfRangeException`, etc.), which are gracefully displayed to the user via UI message boxes instead of crashing the program.

## Author

Osama
