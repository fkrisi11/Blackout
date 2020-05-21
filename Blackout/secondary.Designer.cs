namespace Blackout
{
    partial class secondary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(secondary));
            this.label1 = new System.Windows.Forms.Label();
            this.Move = new System.Windows.Forms.Timer(this.components);
            this.Time = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 108);
            this.label1.TabIndex = 1;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // Move
            // 
            this.Move.Interval = 300000;
            this.Move.Tick += new System.EventHandler(this.Move_Tick);
            // 
            // Time
            // 
            this.Time.Interval = 500;
            this.Time.Tick += new System.EventHandler(this.Time_Tick);
            // 
            // secondary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "secondary";
            this.ShowInTaskbar = false;
            this.Text = "secondary";
            this.Load += new System.EventHandler(this.secondary_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.secondary_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.secondary_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Timer Time;
        public new System.Windows.Forms.Timer Move;
        public System.Windows.Forms.Label label1;
    }
}