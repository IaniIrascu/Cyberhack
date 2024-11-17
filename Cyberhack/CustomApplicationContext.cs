using System;
using System.Windows.Forms;

namespace Cyberhack
{
    public class CustomApplicationContext : ApplicationContext
    {
        private F2button f2Button;
        private Form1 mainForm;

        public CustomApplicationContext()
        {
            // Register the F2 hotkey to show the form
            f2Button = new F2button(IntPtr.Zero, ShowForm);
        }

        private void ShowForm()
        {
            if (mainForm == null || mainForm.IsDisposed)
            {
                mainForm = new Form1();
                mainForm.FormClosing += (s, e) => 
                {
                    e.Cancel = true; 
                    mainForm.Hide(); 
                };
                mainForm.Show();
            }
            else
            {
                mainForm.Show();
                mainForm.WindowState = FormWindowState.Normal;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                f2Button?.Dispose();
                mainForm?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}