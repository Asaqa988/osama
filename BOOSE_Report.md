# BOOSE Report: Object-Oriented Drawing Application Architecture

## 1. Introduction

The constructed system is a dynamic, text-driven graphical drawing application built using C# and Windows Forms. It solves the problem of translating human-readable textual commands (such as "moveto", "drawto", "circle", and "rectangle") into direct visual manifestations on a digital canvas. By utilizing object-oriented methodologies, the system ensures that parsing logic, state management, and graphical rendering are decoupled, creating a highly modular and maintainable codebase structure suitable for scalable software engineering.

## 2. System Design

The high-level architecture operates on a unidirectional data flow governed by event-driven UI triggers. When a user submits a sequence of commands, the system delegates the raw string processing to a centralized factory component. This factory translates the text into a curated list of executable command objects. The graphical interface, acting as the invoker, clears its canvas and iterates through these commands, injecting a shared state context and the active graphics context. This separation ensures the UI remains completely unaware of how geometric shapes are algorithmically drawn or calculated.

## 3. Design Patterns Used

**Command Pattern:**
This behavioral design pattern is the cornerstone of the application. It encapsulates a request as a standalone object containing all information about the request (e.g., coordinates, dimensions, radius). It was implemented by defining an `ICommand` interface with an `Execute` method. This pattern was chosen because it allows the application to queue instructions seamlessly in a list and execute them on-demand during the application's sequential `Paint` rendering cycle.

**Factory Pattern:**
This creational pattern was introduced via the `CommandFactory` class to handle instantiation logic. Instead of the UI layer analyzing strings with complex conditional logic, it simply asks the factory for an `ICommand`. The factory determines which specific concrete class (`CircleCommand`, `MoveToCommand`, etc.) to return. This abstracts the instantiation logic and isolates string parsing dependencies, heavily adhering to the Single Responsibility Principle.

## 4. Object-Oriented Principles

- **Encapsulation:** The internal state of commands (such as `_radius`, `_width`, and `_height`) and the drawing state coordinates are protected and private. They are only exposed or mutated through controlled mechanisms, protecting the integrity of the data from external interference.
- **Inheritance:** The `CanvasCommand` acts as an abstract base class that implements `ICommand`. It provides shared logic—like coordinate storage and integer validation mechanisms—that subclasses inherently receive, promoting code reuse.
- **Abstraction:** The UI explicitly depends on the `ICommand` interface rather than concrete classes. The complex geometric calculations necessary to render shapes from center points (e.g., in a circle) are completely hidden behind the interface's `Execute` method.

## 5. Key Components

- **ICommand:** The fundamental interface dictating that all valid shapes and movements must provide an `Execute(Graphics g, DrawingState state)` method.
- **CanvasCommand:** An abstract intermediary class that enforces coordinate requirements (X and Y) and validates that inputs are strictly non-negative integers.
- **DrawingState:** A state container that holds the transient context (CurrentX, CurrentY). It provides historical memory for sequential commands like `drawto`, allowing a line to know where the previous command ended.
- **CommandFactory:** The parser and instantiator that bridges raw dimensional string data into validated `ICommand` objects.

## 6. Extensibility

Due to the stringent adherence to the Open/Closed Principle, extending the system to support new shapes (like Triangles or Polygons) requires zero modifications to the UI rendering loop or existing shape classes. A developer merely needs to create a new class inheriting from `CanvasCommand` and add a single corresponding `case` branch to the `CommandFactory` parser. The newly added shape instantly integrates into the ecosystem.

## 7. Error Handling

The application relies heavily on defensive programming protocols. The `CommandFactory` proactively checks for incorrect string formatting and missing parameters before object creation, throwing highly specific exceptions such as `ArgumentException`. Furthermore, constructors like `RectangleCommand` strictly validate dimensional boundary constraints, throwing `ArgumentOutOfRangeException` for negative widths. The UI layer catches these safely in a centralized `try/catch` block, converting fatal logic errors into user-friendly graphical `MessageBox` alerts without risking an application crash.
