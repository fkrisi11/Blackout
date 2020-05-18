using System;
using System.Drawing;
using System.Windows.Forms;

namespace Blackout
{
    public partial class secondary : Form
    {
        public secondary()
        {
            InitializeComponent();
        }
        Font stringFont = new Font("Microsoft Sans Serif", 72);
        string seconds, minutes, hours;

        private void Move_Tick(object sender, EventArgs e)
        {
                if ((label1.Top + label1.Height + 200) < Screen.AllScreens[1].Bounds.Height)
                    label1.Top += 200;
                else
                    label1.Top = 200;
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            seconds = DateTime.Now.Second.ToString();
            if (int.Parse(seconds) < 10)
                seconds = "0" + seconds;

            minutes = DateTime.Now.Minute.ToString();
            if (int.Parse(minutes) < 10)
                minutes = "0" + minutes;

            hours = DateTime.Now.Hour.ToString();
            if (int.Parse(hours) < 10)
                hours = "0" + hours;

            label1.Text = hours + ":" + minutes + ":" + seconds;
            label1.Left = Screen.AllScreens[1].Bounds.Width / 2 - label1.Width / 2;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Middle)
            {
                Environment.Exit(0);
            }
        }

        private void secondary_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Middle)
            {
                Environment.Exit(0);
            }
        }

        private void secondary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.H && e.Modifiers != Keys.Control)
            {
                Environment.Exit(0);
            }
            else
            {
                if (e.KeyCode == Keys.H)
                {
                    Time.Enabled = false;
                    Move.Enabled = false;
                    Hide();
                }
            }
        }

        private void monitor2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Time.Enabled = true;
            Move.Enabled = true;
            label1.Visible = true;
            Show();
        }

        private void secondary_Load(object sender, EventArgs e)
        {
            if (SystemInformation.MonitorCount > 1)
            {
                Move.Enabled = true;
                Time.Enabled = true;
                FormBorderStyle = FormBorderStyle.None;
                Width = Screen.AllScreens[1].Bounds.Width;
                Height = Screen.AllScreens[1].Bounds.Height;
                Left = Screen.AllScreens[1].Bounds.Left;
                Top = Screen.AllScreens[1].Bounds.Top;
                Cursor.Hide();
                label1.Left = Screen.AllScreens[1].Bounds.Width / 2 - label1.Width / 2;
                label1.Top = Screen.AllScreens[1].Bounds.Height / 2 - label1.Height / 2;
            }
        }
    }
}