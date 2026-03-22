using System;
using System.Drawing;

namespace DrawingApp.Commands
{
    /// <summary>
    /// Represents a base abstract command for canvas operations that require X and Y coordinates.
    /// </summary>
    public abstract class CanvasCommand : ICommand
    {
        /// <summary>
        /// Gets or sets the X coordinate for the command.
        /// </summary>
        protected int X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate for the command.
        /// </summary>
        protected int Y { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasCommand"/> class.
        /// </summary>
        /// <param name="x">The X coordinate on the canvas.</param>
        /// <param name="y">The Y coordinate on the canvas.</param>
        /// <exception cref="ArgumentException">Thrown when coordinates are negative.</exception>
        protected CanvasCommand(int x, int y)
        {
            ValidateCoordinate(x, nameof(x));
            ValidateCoordinate(y, nameof(y));

            X = x;
            Y = y;
        }

        /// <summary>
        /// Validates that a given coordinate is a non-negative integer.
        /// </summary>
        /// <param name="value">The coordinate value to validate.</param>
        /// <param name="parameterName">The name of the parameter being validated.</param>
        /// <exception cref="ArgumentException">Thrown when the value is negative.</exception>
        protected void ValidateCoordinate(int value, string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentException($"Coordinate '{parameterName}' must be a non-negative integer. Received: {value}", parameterName);
            }
        }

        /// <summary>
        /// Executes the drawing command. Must be implemented by specific command types.
        /// </summary>
        /// <param name="canvas">The canvas object used for drawing.</param>
        /// <param name="state">The current drawing state of the application.</param>
        public abstract void Execute(BOOSE.ICanvas canvas, DrawingState state);
    }
}
