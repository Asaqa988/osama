using System;
using DrawingApp.Commands;

namespace DrawingApp.Factories
{
    public class CommandFactory
    {
        public ICommand CreateCommand(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input cannot be empty or whitespace.");
            }

            string[] parts = input.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                throw new ArgumentException("Invalid command format. Expected 'command parameters'.");
            }

            string commandName = parts[0].ToLowerInvariant();
            string[] args = parts[1].Split(',');

            if (commandName == "rectangle")
            {
                if (args.Length != 4)
                    throw new ArgumentException("Invalid rectangle format. Expected 'rectangle x,y,width,height'.");

                if (!int.TryParse(args[0].Trim(), out int x) ||
                    !int.TryParse(args[1].Trim(), out int y) ||
                    !int.TryParse(args[2].Trim(), out int w) ||
                    !int.TryParse(args[3].Trim(), out int h))
                {
                    throw new ArgumentException("Rectangle parameters must be valid integers.");
                }

                return new RectangleCommand(x, y, w, h);
            }
            else if (commandName == "circle")
            {
                if (args.Length != 3) 
                    throw new ArgumentException("Invalid circle format. Expected 'circle x,y,radius'.");

                if (!int.TryParse(args[0].Trim(), out int x) ||
                    !int.TryParse(args[1].Trim(), out int y) ||
                    !int.TryParse(args[2].Trim(), out int radius))
                {
                    throw new ArgumentException("Circle parameters must be valid integers.");
                }
                
                return new CircleCommand(x, y, radius);
            }
            else
            {
                if (args.Length != 2)
                {
                    throw new ArgumentException("Invalid coordinates format. Expected 'x,y'.");
                }

                if (!int.TryParse(args[0].Trim(), out int x) || 
                    !int.TryParse(args[1].Trim(), out int y))
                {
                    throw new ArgumentException("Coordinates must be valid integers.");
                }

                return commandName switch
                {
                    "moveto" => new MoveToCommand(x, y),
                    "drawto" => new DrawToCommand(x, y),
                    _ => throw new ArgumentException($"Unknown command: {commandName}")
                };
            }
        }
    }
}
