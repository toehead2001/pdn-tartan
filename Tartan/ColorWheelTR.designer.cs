namespace Controlz
{
    partial class ColorWheelTR
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.blue1 = new System.Windows.Forms.NumericUpDown();
            this.green1 = new System.Windows.Forms.NumericUpDown();
            this.red1 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.blue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.green1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.red1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 105);
            this.panel2.TabIndex = 17;
            this.panel2.Tag = "0";
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GenColorWheel_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GenColorWheel_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GenColorWheel_MouseUp);
            // 
            // blue1
            // 
            this.blue1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blue1.Location = new System.Drawing.Point(211, 48);
            this.blue1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blue1.Name = "blue1";
            this.blue1.Size = new System.Drawing.Size(49, 20);
            this.blue1.TabIndex = 3;
            this.blue1.Tag = "0";
            this.blue1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.blue1.ValueChanged += new System.EventHandler(this.ARGB_ValueChanged);
            this.blue1.Leave += new System.EventHandler(this.ARGB_Leave);
            this.blue1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ARGB_MouseUp);
            // 
            // green1
            // 
            this.green1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.green1.Location = new System.Drawing.Point(211, 26);
            this.green1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.green1.Name = "green1";
            this.green1.Size = new System.Drawing.Size(49, 20);
            this.green1.TabIndex = 2;
            this.green1.Tag = "0";
            this.green1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.green1.ValueChanged += new System.EventHandler(this.ARGB_ValueChanged);
            this.green1.Leave += new System.EventHandler(this.ARGB_Leave);
            this.green1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ARGB_MouseUp);
            // 
            // red1
            // 
            this.red1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.red1.Location = new System.Drawing.Point(211, 3);
            this.red1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.red1.Name = "red1";
            this.red1.Size = new System.Drawing.Size(49, 20);
            this.red1.TabIndex = 1;
            this.red1.Tag = "0";
            this.red1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.red1.ValueChanged += new System.EventHandler(this.ARGB_ValueChanged);
            this.red1.Leave += new System.EventHandler(this.ARGB_Leave);
            this.red1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ARGB_MouseUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(191, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "R";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(190, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "G";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(190, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "B";
            // 
            // ColorWheelTR
            // 
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.blue1);
            this.Controls.Add(this.green1);
            this.Controls.Add(this.red1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(260, 105);
            this.MinimumSize = new System.Drawing.Size(260, 105);
            this.Name = "ColorWheelTR";
            this.Size = new System.Drawing.Size(260, 105);
            this.Load += new System.EventHandler(this.ColorWheelTR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.blue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.green1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.red1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown blue1;
        private System.Windows.Forms.NumericUpDown green1;
        private System.Windows.Forms.NumericUpDown red1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}
