using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DrawingApp.Commands;
using DrawingApp.Factories;

namespace osm;

public partial class Form1 : Form
{
    private DrawingState state = new DrawingState();
    private CommandFactory factory = new CommandFactory();
    private List<ICommand> commands = new List<ICommand>();
    private BOOSE.ICanvas canvas;

    public Form1()
    {
        InitializeComponent();
        try
        {
            canvas = new BOOSE.Canvas();
            canvas.Set(this.Width > 0 ? this.Width : 640, this.Height > 0 ? this.Height : 480);
        }
        catch
        {
            // fallback if BOOSE.Canvas needs different initialization
        }
    }

    private void btnRun_Click(object sender, EventArgs e)
    {
        // 1. Clear the command list
        commands.Clear();
        
        // 2. Reset DrawingState to (0,0) as requested before parsing
        state.CurrentX = 0;
        state.CurrentY = 0;

        try
        {
            // 3. Parse all input lines using CommandFactory and store in list
            foreach (string line in txtCommands.Lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                commands.Add(factory.CreateCommand(line.Trim()));
            }
            
            // 4. Call Invalidate() to trigger a redraw
            this.Invalidate();
        }
        catch (Exception ex)
        {
            // Handle errors
            MessageBox.Show(ex.Message, "Invalid Command", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        state.CurrentX = 0;
        state.CurrentY = 0;
        if (canvas != null)
        {
            canvas.Clear();
            canvas.SetColour(0, 0, 0);

            // Execute commands via BOOSE canvas
            foreach (var cmd in commands)
            {
                cmd.Execute(canvas, state);
            }

            // Draw bitmap
            object bmpObj = canvas.getBitmap();
            if (bmpObj is Bitmap bmp)
            {
                e.Graphics.DrawImageUnscaled(bmp, 0, 0);
            }
        }
    }
}
