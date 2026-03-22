using System;
using System.Drawing;

namespace DrawingApp.Commands
{
    /// <summary>
    /// Represents a command to draw a circle around a center coordinate.
    /// </summary>
    public class CircleCommand : CanvasCommand
    {
        private int _radius;

        /// <summary>
        /// Initializes a new instance of the <see cref="CircleCommand"/> class.
        /// </summary>
        /// <param name="x">The center X coordinate.</param>
        /// <param name="y">The center Y coordinate.</param>
        /// <param name="radius">The radius of the circle, must be a positive integer.</param>
        public CircleCommand(int x, int y, int radius) : base(x, y)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius must be a positive integer.", nameof(radius));
            }

            _radius = radius;
        }

        /// <summary>
        /// Executes the draw command by drawing a circle on BOOSE canvas.
        /// Does not update the current drawing state position.
        /// </summary>
        /// <param name="canvas">The BOOSE canvas object used for drawing.</param>
        /// <param name="state">The current drawing state of the application.</param>
        public override void Execute(BOOSE.ICanvas canvas, DrawingState state)
        {
            if (canvas == null) throw new ArgumentNullException(nameof(canvas));

            canvas.MoveTo(X, Y); // Move to center
            canvas.Circle(_radius, false);
        }
    }
}
