using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Blackout
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
        }
        string seconds, minutes, hours;
        Font stringFont = new Font("Microsoft Sans Serif", 72);
        int monitorCount = SystemInformation.MonitorCount;
        List<secondary> clones = new List<secondary>();
        private void Form1_Load(object sender, EventArgs e)
        {
            clones.Add(null);
            if (monitorCount > 1)
            {
                clones.Add(new secondary());
            }

            FormBorderStyle = FormBorderStyle.None;
            Top = 0; Left = 0;
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            Cursor.Hide();
            label1.Left = Screen.PrimaryScreen.Bounds.Width / 2 - label1.Width /2;
            label1.Top = Screen.PrimaryScreen.Bounds.Height / 2 - label1.Height /2;

            ToolStripMenuItem item, submenu;
            submenu = new ToolStripMenuItem();
            submenu.Text = "Show on";

            item = new ToolStripMenuItem();
            item.Text = "Monitor 1";
            submenu.DropDownItems.Add(item);

            for (int i = 1; i < clones.Count; i++)
            {
                clones[i].Show();
                item = new ToolStripMenuItem();
                item.Text = "Monitor " + (i+1).ToString();
                submenu.DropDownItems.Add(item);
            }
            item = new ToolStripMenuItem();
            item.Text = "All";
            submenu.DropDownItems.Add(item);
            contextMenuStrip1.Items.Add(submenu);
            submenu.DropDownItemClicked += Submenu_DropDownItemClicked;

            item = new ToolStripMenuItem();
            item.Text = "Exit";
            contextMenuStrip1.Items.Add(item);
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0 && label1.Font.Size > 6)
                stringFont = new Font(label1.Font.FontFamily, label1.Font.Size - 5);
           
            if (e.Delta > 0)
                stringFont = new Font(label1.Font.FontFamily, label1.Font.Size + 5);

                label1.Font = stringFont;
                label1.Left = Screen.PrimaryScreen.Bounds.Width / 2 - label1.Width / 2;

            if (monitorCount > 1)
            {
                for (int i = 1; i < clones.Count; i++)
                {
                    clones[i].label1.Font = stringFont;
                    clones[i].label1.Left = Screen.AllScreens[i].Bounds.Width / 2 - label1.Width / 2;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.T && e.KeyCode != Keys.H && e.Modifiers != Keys.Control)
            {
                exit();
                Environment.Exit(0);
            }
            else
            {
                if (e.KeyCode == Keys.T)
                {
                    if (label1.Visible)
                    {
                        Time.Enabled = false;
                        Move.Enabled = false;
                        label1.Visible = false;

                        if (monitorCount > 1)
                        {
                            for (int i = 1; i < clones.Count; i++)
                            {
                                clones[i].Time.Enabled = false;
                                clones[i].Move.Enabled = false;
                                clones[i].label1.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        Time.Enabled = true;
                        Move.Enabled = true;
                        label1.Visible = true;

                        if (monitorCount > 1)
                        {
                            for (int i = 1; i < clones.Count; i++)
                            {
                                clones[i].Time.Enabled = true;
                                clones[i].Move.Enabled = true;
                                clones[i].label1.Visible = true;
                            }
                        }
                    }
                }
                if (e.KeyCode == Keys.H)
                {
                    Time.Enabled = false;
                    Move.Enabled = false;
                    Hide();
                    Cursor.Show();
                }
            }
        }

        private void Move_Tick(object sender, EventArgs e)
        {
            if ((label1.Top + label1.Height + 200) < Screen.PrimaryScreen.Bounds.Height)
                label1.Top += 200;
            else
                label1.Top = 200;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Middle)
            {
                exit();
                Environment.Exit(0);
            }
            else
            {
                stringFont = new Font(label1.Font.FontFamily, 72);
                label1.Font = stringFont;
                label1.Left = Screen.PrimaryScreen.Bounds.Width / 2 - label1.Width / 2;

                for (int i = 1; i < clones.Count; i++)
                {
                    clones[i].label1.Font = stringFont;
                    clones[i].label1.Left = Screen.AllScreens[i].Bounds.Width / 2 - label1.Width / 2;
                }
            }
        }

        private void showOnPrimary()
        {
            if (monitorCount > 1)
            {
                for (int i = 1; i < clones.Count; i++)
                {
                    clones[i].Time.Enabled = false;
                    clones[i].Move.Enabled = false;
                    clones[i].label1.Visible = false;
                    clones[i].Hide();
                }
            }

            Time.Enabled = true;
            Move.Enabled = true;
            label1.Visible = true;
            Show();
        }

        private void showOnOtherSelected(int numberOfMonitor)
        {
            if (monitorCount > 1)
            {
                for (int i = 1; i < clones.Count; i++)
                {
                    if (i != numberOfMonitor)
                    {
                        clones[i].Time.Enabled = false;
                        clones[i].Move.Enabled = false;
                        clones[i].label1.Visible = false;
                        clones[i].Hide();
                    }
                    else
                    {
                        clones[i].Time.Enabled = true;
                        clones[i].Move.Enabled = true;
                        clones[i].label1.Visible = true;
                        clones[i].Show();
                    }
                }
            }

            Time.Enabled = false;
            Move.Enabled = false;
            label1.Visible = false;
            Hide();
        }

        private void showOnAll()
        {
            if (monitorCount > 1)
            {
                for (int i = 1; i < clones.Count; i++)
                {
                    clones[i].Time.Enabled = true;
                    clones[i].Move.Enabled = true;
                    clones[i].label1.Visible = true;
                    clones[i].Show();
                }
            }

            Time.Enabled = true;
            Move.Enabled = true;
            label1.Visible = true;
            Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit();
            Environment.Exit(0);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Middle)
            {
                exit();
                Environment.Exit(0);
            }
            else
            {
                stringFont = new Font(label1.Font.FontFamily, 72);
                label1.Font = stringFont;
                label1.Left = Screen.PrimaryScreen.Bounds.Width / 2 - label1.Width / 2;

                for (int i = 1; i < clones.Count; i++)
                {
                    clones[i].label1.Font = stringFont;
                    clones[i].label1.Left = Screen.AllScreens[i].Bounds.Width / 2 - label1.Width / 2;
                }
            }
        }

        private void contextMenuStrip1_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void contextMenuStrip1_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Hide();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Exit")
                Close();
        }

        private void Submenu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text.Contains("Monitor"))
            {
                if (e.ClickedItem.Text == "Monitor 1")
                    showOnPrimary();
                else
                    showOnOtherSelected((int.Parse(e.ClickedItem.Text.Split(' ')[1]))-1);
            }
            else
                showOnAll();
        }

        private int findItemNumber(ToolStripMenuItem submenu, string menuName)
        {
            for (int i = 0; i < submenu.DropDownItems.Count; i++)
            {
                if (submenu.DropDownItems[i].Text == menuName)
                    return i;
            }
            return -1;
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
            label1.Left = Screen.PrimaryScreen.Bounds.Width / 2 - label1.Width / 2;
        }

        private void exit()
        {
            Blackout.Visible = false;
            Blackout.Dispose();
        }
    }
}