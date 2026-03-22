using System.Drawing;

namespace DrawingApp.Commands
{
    /// <summary>
    /// Represents a command to move the drawing cursor to a new position without drawing.
    /// </summary>
    public class MoveToCommand : CanvasCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoveToCommand"/> class.
        /// </summary>
        /// <param name="x">The new X coordinate.</param>
        /// <param name="y">The new Y coordinate.</param>
        public MoveToCommand(int x, int y) : base(x, y)
        {
        }

        /// <summary>
        /// Executes the move command by updating the current drawing state and BOOSE canvas.
        /// </summary>
        /// <param name="canvas">The BOOSE canvas object.</param>
        /// <param name="state">The current drawing state of the application.</param>
        public override void Execute(BOOSE.ICanvas canvas, DrawingState state)
        {
            if (canvas == null) throw new ArgumentNullException(nameof(canvas));
            if (state == null) throw new ArgumentNullException(nameof(state));

            canvas.MoveTo(X, Y);
            state.CurrentX = X;
            state.CurrentY = Y;
        }
    }
}
