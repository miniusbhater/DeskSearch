using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeakSearch
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Rectangle pos = Screen.PrimaryScreen.WorkingArea; // puts the window at the very bottom right of your monitor (hopefully)
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(
                pos.Right - this.Width,  
                pos.Bottom - this.Height 
            );
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string Search = textBox1.Text;
            if (!string.IsNullOrWhiteSpace(Search))
            {
                if (!Search.StartsWith("http://") && !Search.StartsWith("https://")) // adds 'https://' to the beggining of whatever is entered incase you were dumb or something 
                {
                    Search = "https://" + Search;
                }
                try
                {
                    var open = new ProcessStartInfo
                    {
                        FileName = Search,
                        UseShellExecute = true // opens the silly
                    };
                    Process.Start(open);
                }
                catch (Exception broke)
                {
                    MessageBox.Show("Can't open URL: " + broke, "Failed to open URL!", MessageBoxButtons.OK, MessageBoxIcon.Error); // if something breaks >:(
                }
            }

            else
            {
                MessageBox.Show("Enter a valid URL", "Enter a URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);  // entirely user error just get better
            }
        }

    }
    }

