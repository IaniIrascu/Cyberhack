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
        button1 = new System.Windows.Forms.Button();
        textBox1 = new System.Windows.Forms.TextBox();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
        button1.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button1.Location = new System.Drawing.Point(580, 188);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(179, 45);
        button1.TabIndex = 0;
        button1.Text = "Brighter";
        button1.UseVisualStyleBackColor = false;
        button1.Click += button1_Click;
        // 
        // textBox1
        // 
        textBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
        textBox1.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        textBox1.Location = new System.Drawing.Point(65, 330);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(471, 45);
        textBox1.TabIndex = 3;
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // button2
        // 
        button2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
        button2.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button2.Location = new System.Drawing.Point(65, 188);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(179, 45);
        button2.TabIndex = 4;
        button2.Text = "Dimmer";
        button2.UseVisualStyleBackColor = false;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
        button3.Location = new System.Drawing.Point(580, 330);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(179, 45);
        button3.TabIndex = 5;
        button3.Text = "Search";
        button3.UseVisualStyleBackColor = false;
        button3.Click += button3_Click;
        // 
        // label1
        // 
        label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
        label1.Location = new System.Drawing.Point(275, 37);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(277, 62);
        label1.TabIndex = 6;
        label1.Text = "Welcome to MyConfig\r\n";
        label1.Click += label1_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(label1);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(textBox1);
        Controls.Add(button1);
        Margin = new System.Windows.Forms.Padding(2);
        Text = "MyConfig";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.TextBox textBox1;
    
    private System.Windows.Forms.Button button1;

    #endregion
}