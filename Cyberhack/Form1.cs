namespace Cyberhack;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Installer chrome = new Installer("chrome");
        chrome.Install();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Installer facebook = new Installer("facebook");
        facebook.Install();
    }
}