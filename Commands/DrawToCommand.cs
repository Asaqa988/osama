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
        /// Executes the draw command by drawing a line and updating the current drawing state.
        /// </summary>
        /// <param name="g">The graphics object used for drawing.</param>
        /// <param name="state">The current drawing state of the application.</param>
        public override void Execute(Graphics g, DrawingState state)
        {
            if (g == null) throw new ArgumentNullException(nameof(g));
            if (state == null) throw new ArgumentNullException(nameof(state));

            g.DrawLine(Pens.Black, state.CurrentX, state.CurrentY, X, Y);

            state.CurrentX = X;
            state.CurrentY = Y;
        }
    }
}
