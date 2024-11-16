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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        button1 = new System.Windows.Forms.Button();
        textBox1 = new System.Windows.Forms.TextBox();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        button4 = new System.Windows.Forms.Button();
        button5 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
        button1.Location = new System.Drawing.Point(585, 33);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(183, 56);
        button1.TabIndex = 0;
        button1.Text = "Brighter";
        button1.UseVisualStyleBackColor = false;
        button1.Click += button1_Click;
        // 
        // textBox1
        // 
        textBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
        textBox1.Location = new System.Drawing.Point(39, 246);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(471, 45);
        textBox1.TabIndex = 3;
        // 
        // button2
        // 
        button2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
        button2.Location = new System.Drawing.Point(585, 108);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(183, 56);
        button2.TabIndex = 4;
        button2.Text = "Dimmer";
        button2.UseVisualStyleBackColor = false;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
        button3.Location = new System.Drawing.Point(569, 246);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(213, 45);
        button3.TabIndex = 5;
        button3.Text = "Search";
        button3.UseVisualStyleBackColor = false;
        button3.Click += button3_Click;
        // 
        // button4
        // 
        button4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
        button4.Location = new System.Drawing.Point(39, 314);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(179, 50);
        button4.TabIndex = 7;
        button4.Text = "No";
        button4.UseVisualStyleBackColor = false;
        // 
        // button5
        // 
        button5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
        button5.Location = new System.Drawing.Point(331, 314);
        button5.Name = "button5";
        button5.Size = new System.Drawing.Size(179, 50);
        button5.TabIndex = 8;
        button5.Text = "Yes";
        button5.UseVisualStyleBackColor = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(804, 459);
        Controls.Add(button5);
        Controls.Add(button4);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(textBox1);
        Controls.Add(button1);
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        Margin = new System.Windows.Forms.Padding(2);
        Text = "MyConfig";
        ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button button1;

    #endregion
}