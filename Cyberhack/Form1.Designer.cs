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
        process1 = new System.Diagnostics.Process();
        button1 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // process1
        // 
        process1.StartInfo.Domain = "";
        process1.StartInfo.LoadUserProfile = false;
        process1.StartInfo.UseCredentialsForNetworkingOnly = false;
        process1.StartInfo.UserName = "";
        process1.StartInfo.UseShellExecute = false;
        process1.SynchronizingObject = this;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(61, 53);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(263, 68);
        button1.TabIndex = 0;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(button1);
        Text = "Form1";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;

    private System.Diagnostics.Process process1;

    #endregion
}