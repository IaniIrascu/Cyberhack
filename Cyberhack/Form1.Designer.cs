namespace Cyberhack;

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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        button1 = new System.Windows.Forms.Button();
        textBox1 = new System.Windows.Forms.TextBox();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(580, 58);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(179, 64);
        button1.TabIndex = 0;
        button1.Text = "Brighter";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(65, 256);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(389, 122);
        textBox1.TabIndex = 3;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(65, 58);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(179, 64);
        button2.TabIndex = 4;
        button2.Text = "Dimmer";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(580, 287);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(179, 45);
        button3.TabIndex = 5;
        button3.Text = "Search";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(textBox1);
        Controls.Add(button1);
        Margin = new System.Windows.Forms.Padding(2);
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.TextBox textBox1;
    
    private System.Windows.Forms.Button button1;
    
    #endregion
}