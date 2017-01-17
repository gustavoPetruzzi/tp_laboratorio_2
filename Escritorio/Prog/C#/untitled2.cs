using System;
using System.Drawing;
using System.Windows.Forms;

//$/t:winexe
//& RunInOwnWindow

namespace QuickSharp
{
    public class MainForm : Form
    {
        private static void Main(string [] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException +=
                new System.Threading.ThreadExceptionEventHandler(ThreadException);

            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   
        
        private static void ThreadException(
            object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            Application.Exit();
        }        
        
        public MainForm()
        {
            Text = "MainForm";
            Size = new Size(500, 300);
            
            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.AutoSize = true;
            okButton.Location = new Point(10, 10);
            okButton.Click += delegate { Close(); };
            
            Controls.Add(okButton);
        }
    }
}
