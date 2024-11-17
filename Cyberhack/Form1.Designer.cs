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
        trackBar1 = new System.Windows.Forms.TrackBar();
        label1 = new System.Windows.Forms.Label();
        pictureBox1 = new System.Windows.Forms.PictureBox();
        ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.Color.FromArgb(((int)((byte)238)), ((int)((byte)238)), ((int)((byte)238)));
        button1.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)57)), ((int)((byte)62)), ((int)((byte)70)));
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
        textBox1.Location = new System.Drawing.Point(39, 279);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(471, 45);
        textBox1.TabIndex = 3;
        // 
        // button2
        // 
        button2.BackColor = System.Drawing.Color.FromArgb(((int)((byte)57)), ((int)((byte)62)), ((int)((byte)70)));
        button2.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)238)), ((int)((byte)238)), ((int)((byte)238)));
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
        button3.Location = new System.Drawing.Point(569, 279);
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
        button4.Location = new System.Drawing.Point(39, 353);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(179, 50);
        button4.TabIndex = 7;
        button4.Text = "No";
        button4.UseVisualStyleBackColor = false;
        button4.Click += button4_Click;
        // 
        // button5
        // 
        button5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
        button5.Location = new System.Drawing.Point(331, 353);
        button5.Name = "button5";
        button5.Size = new System.Drawing.Size(179, 50);
        button5.TabIndex = 8;
        button5.Text = "Yes";
        button5.UseVisualStyleBackColor = false;
        button5.Click += button5_Click;
        // 
        // trackBar1
        // 
        trackBar1.BackColor = System.Drawing.Color.FromArgb(((int)((byte)34)), ((int)((byte)40)), ((int)((byte)49)));
        trackBar1.Location = new System.Drawing.Point(569, 353);
        trackBar1.Name = "trackBar1";
        trackBar1.Size = new System.Drawing.Size(213, 69);
        trackBar1.TabIndex = 9;
        trackBar1.Scroll += trackBar1_Scroll;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 12F);
        label1.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)238)), ((int)((byte)238)), ((int)((byte)238)));
        label1.Location = new System.Drawing.Point(569, 400);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(213, 47);
        label1.TabIndex = 10;
        label1.Text = "Volume";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        label1.Click += label1_Click;
        // 
        // pictureBox1
        // 
        pictureBox1.Image = ((System.Drawing.Image)resources.GetObject("pictureBox1.Image"));
        pictureBox1.Location = new System.Drawing.Point(62, 33);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(465, 189);
        pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        pictureBox1.TabIndex = 11;
        pictureBox1.TabStop = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(((int)((byte)34)), ((int)((byte)40)), ((int)((byte)49)));
        ClientSize = new System.Drawing.Size(804, 459);
        Controls.Add(pictureBox1);
        Controls.Add(label1);
        Controls.Add(trackBar1);
        Controls.Add(button5);
        Controls.Add(button4);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(textBox1);
        Controls.Add(button1);
        Margin = new System.Windows.Forms.Padding(2);
        Text = "MyConfig";
        ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.PictureBox pictureBox1;

    private System.Windows.Forms.TrackBar trackBar1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button button1;

    #endregion
}