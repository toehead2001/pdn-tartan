namespace Controlz
{
    partial class PdnColor
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
            this.colorWheelBox = new System.Windows.Forms.PictureBox();
            this.bLabel = new System.Windows.Forms.Label();
            this.gLabel = new System.Windows.Forms.Label();
            this.rLabel = new System.Windows.Forms.Label();
            this.blueBox = new System.Windows.Forms.NumericUpDown();
            this.greenBox = new System.Windows.Forms.NumericUpDown();
            this.redBox = new System.Windows.Forms.NumericUpDown();
            this.swatchBox = new System.Windows.Forms.PictureBox();
            this.vColorSlider = new Controlz.ColorSlider();
            this.sColorSlider = new Controlz.ColorSlider();
            ((System.ComponentModel.ISupportInitialize)(this.colorWheelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swatchBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vColorSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sColorSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // colorWheelBox
            // 
            this.colorWheelBox.Location = new System.Drawing.Point(30, 0);
            this.colorWheelBox.Name = "colorWheelBox";
            this.colorWheelBox.Size = new System.Drawing.Size(108, 108);
            this.colorWheelBox.TabIndex = 17;
            this.colorWheelBox.TabStop = false;
            this.colorWheelBox.Tag = "0";
            this.colorWheelBox.Paint += new System.Windows.Forms.PaintEventHandler(this.colorWheel_Paint);
            this.colorWheelBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorWheel_MouseDown);
            this.colorWheelBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColorWheel_MouseMove);
            this.colorWheelBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ColorWheel_MouseUp);
            // 
            // bLabel
            // 
            this.bLabel.AutoSize = true;
            this.bLabel.Location = new System.Drawing.Point(188, 63);
            this.bLabel.Name = "bLabel";
            this.bLabel.Size = new System.Drawing.Size(17, 13);
            this.bLabel.TabIndex = 5;
            this.bLabel.Text = "B:";
            // 
            // gLabel
            // 
            this.gLabel.AutoSize = true;
            this.gLabel.Location = new System.Drawing.Point(188, 35);
            this.gLabel.Name = "gLabel";
            this.gLabel.Size = new System.Drawing.Size(18, 13);
            this.gLabel.TabIndex = 4;
            this.gLabel.Text = "G:";
            // 
            // rLabel
            // 
            this.rLabel.AutoSize = true;
            this.rLabel.Location = new System.Drawing.Point(188, 7);
            this.rLabel.Name = "rLabel";
            this.rLabel.Size = new System.Drawing.Size(17, 13);
            this.rLabel.TabIndex = 3;
            this.rLabel.Text = "R:";
            // 
            // blueBox
            // 
            this.blueBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blueBox.Location = new System.Drawing.Point(211, 61);
            this.blueBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blueBox.Name = "blueBox";
            this.blueBox.Size = new System.Drawing.Size(49, 22);
            this.blueBox.TabIndex = 2;
            this.blueBox.Tag = "0";
            this.blueBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.blueBox.ValueChanged += new System.EventHandler(this.ARGB_ValueChanged);
            this.blueBox.Leave += new System.EventHandler(this.ARGB_Leave);
            this.blueBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ARGB_MouseUp);
            // 
            // greenBox
            // 
            this.greenBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.greenBox.Location = new System.Drawing.Point(211, 33);
            this.greenBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.greenBox.Name = "greenBox";
            this.greenBox.Size = new System.Drawing.Size(49, 22);
            this.greenBox.TabIndex = 1;
            this.greenBox.Tag = "0";
            this.greenBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.greenBox.ValueChanged += new System.EventHandler(this.ARGB_ValueChanged);
            this.greenBox.Leave += new System.EventHandler(this.ARGB_Leave);
            this.greenBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ARGB_MouseUp);
            // 
            // redBox
            // 
            this.redBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.redBox.Location = new System.Drawing.Point(211, 5);
            this.redBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.redBox.Name = "redBox";
            this.redBox.Size = new System.Drawing.Size(49, 22);
            this.redBox.TabIndex = 0;
            this.redBox.Tag = "0";
            this.redBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.redBox.ValueChanged += new System.EventHandler(this.ARGB_ValueChanged);
            this.redBox.Leave += new System.EventHandler(this.ARGB_Leave);
            this.redBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ARGB_MouseUp);
            // 
            // swatchBox
            // 
            this.swatchBox.Location = new System.Drawing.Point(0, 5);
            this.swatchBox.Name = "swatchBox";
            this.swatchBox.Size = new System.Drawing.Size(28, 28);
            this.swatchBox.TabIndex = 47;
            this.swatchBox.TabStop = false;
            this.swatchBox.Paint += new System.Windows.Forms.PaintEventHandler(this.swatchBox_Paint);
            // 
            // vColorSlider
            // 
            this.vColorSlider.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.White,
        System.Drawing.Color.Black};
            this.vColorSlider.Location = new System.Drawing.Point(165, 4);
            this.vColorSlider.MaxValue = 100;
            this.vColorSlider.Name = "vColorSlider";
            this.vColorSlider.Size = new System.Drawing.Size(20, 102);
            this.vColorSlider.TabIndex = 46;
            this.vColorSlider.TabStop = false;
            this.vColorSlider.Value = 0F;
            this.vColorSlider.ValueChanged += new System.EventHandler(this.HSV_Sliders_ValueChanged);
            // 
            // sColorSlider
            // 
            this.sColorSlider.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.White,
        System.Drawing.Color.Black};
            this.sColorSlider.Location = new System.Drawing.Point(140, 4);
            this.sColorSlider.MaxValue = 100;
            this.sColorSlider.Name = "sColorSlider";
            this.sColorSlider.Size = new System.Drawing.Size(20, 102);
            this.sColorSlider.TabIndex = 45;
            this.sColorSlider.TabStop = false;
            this.sColorSlider.Value = 0F;
            this.sColorSlider.ValueChanged += new System.EventHandler(this.HSV_Sliders_ValueChanged);
            // 
            // PdnColor
            // 
            this.Controls.Add(this.swatchBox);
            this.Controls.Add(this.vColorSlider);
            this.Controls.Add(this.sColorSlider);
            this.Controls.Add(this.blueBox);
            this.Controls.Add(this.greenBox);
            this.Controls.Add(this.redBox);
            this.Controls.Add(this.colorWheelBox);
            this.Controls.Add(this.rLabel);
            this.Controls.Add(this.gLabel);
            this.Controls.Add(this.bLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PdnColor";
            this.Size = new System.Drawing.Size(260, 110);
            ((System.ComponentModel.ISupportInitialize)(this.colorWheelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swatchBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vColorSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sColorSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox colorWheelBox;
        private System.Windows.Forms.NumericUpDown blueBox;
        private System.Windows.Forms.NumericUpDown greenBox;
        private System.Windows.Forms.NumericUpDown redBox;
        private System.Windows.Forms.Label rLabel;
        private System.Windows.Forms.Label gLabel;
        private System.Windows.Forms.Label bLabel;
        private Controlz.ColorSlider vColorSlider;
        private Controlz.ColorSlider sColorSlider;
        private System.Windows.Forms.PictureBox swatchBox;
    }
}
