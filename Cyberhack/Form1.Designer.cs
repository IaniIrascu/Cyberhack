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
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(249, 207);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(119, 37);
        button1.TabIndex = 0;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(215, 174);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(191, 27);
        textBox1.TabIndex = 1;
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(textBox1);
        Controls.Add(button1);
        Margin = new System.Windows.Forms.Padding(2);
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.CheckedListBox checkedListBox1;

    private System.Windows.Forms.Button button1;

    #endregion
}