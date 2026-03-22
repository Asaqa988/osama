using System.Drawing;

namespace DrawingApp.Commands
{
    /// <summary>
    /// Represents a command to draw a line from the current position to a new position.
    /// </summary>
    public class DrawToCommand : CanvasCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrawToCommand"/> class.
        /// </summary>
        /// <param name="x">The target X coordinate.</param>
        /// <param name="y">The target Y coordinate.</param>
        public DrawToCommand(int x, int y) : base(x, y)
        {
        }

        /// <summary>
        /// Executes the draw command by drawing a line on BOOSE canvas and updating the current drawing state.
        /// </summary>
        /// <param name="canvas">The BOOSE canvas object used for drawing.</param>
        /// <param name="state">The current drawing state of the application.</param>
        public override void Execute(BOOSE.ICanvas canvas, DrawingState state)
        {
            if (canvas == null) throw new ArgumentNullException(nameof(canvas));
            if (state == null) throw new ArgumentNullException(nameof(state));

            canvas.MoveTo(state.CurrentX, state.CurrentY); 
            canvas.DrawTo(X, Y);

            state.CurrentX = X;
            state.CurrentY = Y;
        }
    }
}
