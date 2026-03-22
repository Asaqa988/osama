using System.Drawing;

namespace DrawingApp.Commands
{
    /// <summary>
    /// Defines the contract for all drawing commands in the application.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the drawing command on the provided graphics canvas.
        /// </summary>
        /// <param name="canvas">The BOOSE canvas object used for drawing.</param>
        /// <param name="state">The current drawing state of the application.</param>
        void Execute(BOOSE.ICanvas canvas, DrawingState state);
    }
}
