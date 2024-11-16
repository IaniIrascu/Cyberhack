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

    private void textBox2_TextChanged(object sender, KeyEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void bindingSource1_CurrentChanged(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string text = textBox2.Text;
        // if(e.KeyCode==Keys.Enter)
        //     buttonSearch_Click(sender,e);
            // preiau textul din TextBox.
            String input = text;

            // creez instanta si caut substringurile.
            KeyWordFinder finder = new KeyWordFinder();
            String stringRet = finder.FindSubstring(input);
            Console.WriteLine(stringRet);
            
            // we have the keyword that the user type.
            // and now we apply the handlefunction for that keyword, keyword.
    }
}