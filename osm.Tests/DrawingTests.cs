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

            var canvas = new BOOSE.Canvas();
            canvas.Set(500, 500);
            command.Execute(canvas, state); 

            Assert.Equal(50, state.CurrentX);
            Assert.Equal(75, state.CurrentY);
        }

        [Fact]
        public void DrawToCommand_UpdatesStateCorrectly()
        {
            var state = new DrawingState();
            var command = new DrawToCommand(100, 200);

            var canvas = new BOOSE.Canvas();
            canvas.Set(500, 500);
            command.Execute(canvas, state);

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
            var canvas = new BOOSE.Canvas();
            canvas.Set(500, 500);
            command.Execute(canvas, state);
            Assert.Equal(100, state.CurrentX);
            Assert.Equal(200, state.CurrentY);
        }
    }
}
