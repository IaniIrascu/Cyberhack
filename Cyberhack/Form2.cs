namespace Cyberhack;

public partial class Form2 : Form
{
    private int xPosition;
    private int yPosition;
    private int width;
    private int height;
    
    public Form2(int x, int y, int width, int height)
    {
        InitializeComponent();
        this.BackColor = Color.White;
        this.TransparencyKey = Color.White;
        this.Name = "Form2";
        this.WindowState = FormWindowState.Maximized;
        this.BringToFront();
        this.TopMost = true;
        this.xPosition = x;
        this.yPosition = y;
        this.width = width;
        this.height = height;
        
        this.Paint += form2_Paint;
        this.MouseClick += Form2_Click;
    }

    private void form2_Paint(object sender, PaintEventArgs e)
    {
        // Create a pen to draw the square
        using (Pen pen = new Pen(Color.Blue, 3)) // Blue pen with thickness 3
        {
            Console.WriteLine(this.width);
            // Define the square's position and size
            int x = xPosition;
            int y = yPosition;
            int Width = width;
            int Height = height;

            // Draw the square
            e.Graphics.DrawRectangle(pen, x, y, Width, Height);
        }
    }

    private void Form2_Click(object sender, EventArgs e)
    {
        // Close the form when clicked
        this.Close();
    }
    
}