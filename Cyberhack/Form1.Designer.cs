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
        components = new System.ComponentModel.Container();
        button1 = new System.Windows.Forms.Button();
        checkedListBox1 = new System.Windows.Forms.CheckedListBox();
        bindingSource1 = new System.Windows.Forms.BindingSource(components);
        textBox1 = new System.Windows.Forms.TextBox();
        ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(418, 154);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(119, 88);
        button1.TabIndex = 0;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        // 
        // checkedListBox1
        // 
        checkedListBox1.FormattingEnabled = true;
        checkedListBox1.Location = new System.Drawing.Point(122, 175);
        checkedListBox1.Name = "checkedListBox1";
        checkedListBox1.Size = new System.Drawing.Size(170, 26);
        checkedListBox1.TabIndex = 1;
        // 
        // bindingSource1
        // 
        bindingSource1.CurrentChanged += bindingSource1_CurrentChanged;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(183, 307);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(362, 27);
        textBox1.TabIndex = 2;
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(textBox1);
        Controls.Add(checkedListBox1);
        Controls.Add(button1);
        Margin = new System.Windows.Forms.Padding(2);
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.BindingSource bindingSource1;

    private System.Windows.Forms.CheckedListBox checkedListBox1;

    private System.Windows.Forms.Button button1;

    #endregion
}