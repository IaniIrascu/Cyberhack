namespace Cyberhack;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Cyberhack.KeyWordFinder;
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        TextBox text = sender as TextBox;
        if (text != null)
        {
            // preiau textul din TextBox.
            String input = text.Text;

            // creez instanta si caut substringurile.
            KeyWordFinder finder = new KeyWordFinder();
            finder.FindSubstring(input);
        }
    }
}