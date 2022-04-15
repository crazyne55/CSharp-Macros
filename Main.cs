using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace SimulateKeyPress
{
    class Form1 : Form
    {
        private Button button1 = new Button();

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        
        public ComboBox mybox = new ComboBox();
        public Form1()
        {
            button1.Location = new Point(10, 10);
            button1.TabIndex = 0;
            button1.Text = "Find Processes";
            button1.AutoSize = true;
            button1.Click += new EventHandler(button1_Click);
            this.Controls.Add(button1);

            button2.Location = new Point(10, 30);
            button2.TabIndex = 0;
            button2.Text = "Submit";
            button2.AutoSize = true;
            button2.Click += new EventHandler(button2_Click);
            this.Controls.Add(button2);

            mybox.Location = new Point(10, 77);
            mybox.Size = new Size(216, 26);
            // mybox.MaxLength = 100;
            mybox.DropDownStyle = ComboBoxStyle.DropDownList;
            
            this.Controls.Add(mybox);
        }
        

        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        // Send a series of key presses to the Calculator application.
        private void button1_Click(object sender, EventArgs e)
        {

            Process[] processlist = Finder.FindProccesses();


        }
        private void button2_Click(object sender, EventArgs e)
        {

            Object SelectedProcess = mybox.selectedItem;



            IntPtr AppHandle = FindWindow(null,"Discord");

            //if (calculatorHandle == IntPtr.Zero)
            //{
            //    MessageBox.Show("Calculator is not running.");
            //    return;
            //}
            
            SetForegroundWindow(AppHandle);
        }
    }




    public class Finder {
        public static Process[] FindProccesses() {
            
            Process[] processlist = Process.GetProcesses();
            Console.WriteLine("--------------------( Processes )--------------------");
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    Console.WriteLine("Process: {0} ID: {1} Window title: {2}", process.ProcessName, process.Id, process.MainWindowTitle);
                }
            }
            return processlist;
        }
    }
}
