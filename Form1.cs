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

    public Form1()
    {
        InitializeComponent();
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
        // Reset state here is strictly necessary for WinForms because Paint is called 
        // every time the form is minimized/maximized or covered by another window
        state.CurrentX = 0;
        state.CurrentY = 0;

        // Do NOT parse input. Loop through the stored command list.
        foreach (var cmd in commands)
        {
            // Execute each command in order
            cmd.Execute(e.Graphics, state);
        }
    }
}
