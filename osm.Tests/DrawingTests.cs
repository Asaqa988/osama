using System;
using System.Drawing;
using Xunit;
using DrawingApp.Commands;
using DrawingApp.Factories;

namespace osm.Tests
{
    public class DrawingTests
    {
        [Fact]
        public void MoveToCommand_UpdatesDrawingStateCorrectly()
        {
            var state = new DrawingState();
            var command = new MoveToCommand(50, 75);

            // Execute without Graphics object (not used in MoveTo)
            command.Execute(null, state); 

            Assert.Equal(50, state.CurrentX);
            Assert.Equal(75, state.CurrentY);
        }

        [Fact]
        public void DrawToCommand_UpdatesStateCorrectly()
        {
            var state = new DrawingState();
            var command = new DrawToCommand(100, 200);

            // Use dummy Graphics object for testing drawing
            using var bmp = new Bitmap(1, 1);
            using var g = Graphics.FromImage(bmp);

            command.Execute(g, state);

            Assert.Equal(100, state.CurrentX);
            Assert.Equal(200, state.CurrentY);
        }

        [Fact]
        public void CommandFactory_ParsesMoveToCorrectly()
        {
            var factory = new CommandFactory();

            var command = factory.CreateCommand("moveto 100,200");

            Assert.IsType<MoveToCommand>(command);
            
            var state = new DrawingState();
            command.Execute(null, state);
            Assert.Equal(100, state.CurrentX);
            Assert.Equal(200, state.CurrentY);
        }
    }
}
