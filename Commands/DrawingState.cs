namespace DrawingApp.Commands
{
    /// <summary>
    /// Represents the current state of the drawing environment.
    /// </summary>
    public class DrawingState
    {
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }

        public DrawingState()
        {
            CurrentX = 0;
            CurrentY = 0;
        }
    }
}