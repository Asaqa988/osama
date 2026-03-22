using System;
using System.Drawing;

namespace DrawingApp.Commands
{
    public class RectangleCommand : CanvasCommand
    {
        private readonly int _width;
        private readonly int _height;

        public RectangleCommand(int x, int y, int width, int height) : base(x, y)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width), "Width must be greater than 0.");
            if (height <= 0)
                throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than 0.");

            _width = width;
            _height = height;
        }

        public override void Execute(BOOSE.ICanvas canvas, DrawingState state)
        {
            if (canvas == null) throw new ArgumentNullException(nameof(canvas));
            if (state == null) throw new ArgumentNullException(nameof(state));

            canvas.MoveTo(X, Y); // Move to top-left corner
            canvas.Rect(_width, _height, false);
        }
    }
}
