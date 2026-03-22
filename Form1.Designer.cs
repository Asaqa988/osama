namespace osm;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.txtCommands = new System.Windows.Forms.TextBox();
        this.btnRun = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // txtCommands
        // 
        this.txtCommands.Dock = System.Windows.Forms.DockStyle.Top;
        this.txtCommands.Location = new System.Drawing.Point(0, 0);
        this.txtCommands.Multiline = true;
        this.txtCommands.Name = "txtCommands";
        this.txtCommands.Size = new System.Drawing.Size(800, 100);
        this.txtCommands.TabIndex = 0;
        // 
        // btnRun
        // 
        this.btnRun.Dock = System.Windows.Forms.DockStyle.Top;
        this.btnRun.Location = new System.Drawing.Point(0, 100);
        this.btnRun.Name = "btnRun";
        this.btnRun.Size = new System.Drawing.Size(800, 30);
        this.btnRun.TabIndex = 1;
        this.btnRun.Text = "Run";
        this.btnRun.UseVisualStyleBackColor = true;
        this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Controls.Add(this.btnRun);
        this.Controls.Add(this.txtCommands);
        this.Name = "Form1";
        this.Text = "Form1";
        this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.TextBox txtCommands;
    private System.Windows.Forms.Button btnRun;
}
