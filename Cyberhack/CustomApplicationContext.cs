using System;
using System.Windows.Forms;

namespace Cyberhack
{
    public class CustomApplicationContext : ApplicationContext
    {
        private F2button f2Button;

        public CustomApplicationContext()
        {
            f2Button = new F2button(IntPtr.Zero, ShowForm);
        }

        private void ShowForm()
        {
            var form = new Form1();
            form.Show();
            form.FormClosing += (s, e) => f2Button.Dispose();
        }
    }
}