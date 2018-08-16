namespace TartanEffect
{
    partial class TartanConfigDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TartanConfigDialog));
            this.HorListBox = new System.Windows.Forms.ListBox();
            this.VerListBox = new System.Windows.Forms.ListBox();
            this.LineWidthNumBox = new System.Windows.Forms.NumericUpDown();
            this.HorMoveDown = new System.Windows.Forms.Button();
            this.HorDelete = new System.Windows.Forms.Button();
            this.HorMoveUp = new System.Windows.Forms.Button();
            this.VerMoveDown = new System.Windows.Forms.Button();
            this.VerDelete = new System.Windows.Forms.Button();
            this.VerMoveUp = new System.Windows.Forms.Button();
            this.LineWidthLabel = new System.Windows.Forms.Label();
            this.LineWidthTrackBar = new System.Windows.Forms.TrackBar();
            this.LineSpaceLabel = new System.Windows.Forms.Label();
            this.LineSpaceTrackBar = new System.Windows.Forms.TrackBar();
            this.LineSpaceNumBox = new System.Windows.Forms.NumericUpDown();
            this.LineStyleComboBox = new System.Windows.Forms.ComboBox();
            this.LineStyleLabel = new System.Windows.Forms.Label();
            this.LineColorLabel = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.AddToHor = new System.Windows.Forms.Button();
            this.AddToVer = new System.Windows.Forms.Button();
            this.AddToBoth = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Ok = new System.Windows.Forms.Button();
            this.Divider2 = new System.Windows.Forms.Panel();
            this.Divider1 = new System.Windows.Forms.Panel();
            this.UseHorForVer = new System.Windows.Forms.CheckBox();
            this.BackgroundColorBox = new System.Windows.Forms.Panel();
            this.BackgroundLabel = new System.Windows.Forms.Label();
            this.AddToLabel = new System.Windows.Forms.Label();
            this.LineColorWheel = new Controlz.PdnColor();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.LoadSaveToolStrip = new System.Windows.Forms.ToolStrip();
            this.LoadButton = new System.Windows.Forms.ToolStripButton();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.LineStylePreviewBox = new System.Windows.Forms.PictureBox();
            this.HorSetLabel = new System.Windows.Forms.Label();
            this.VerSetLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.LineWidthNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineWidthTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineSpaceTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineSpaceNumBox)).BeginInit();
            this.LoadSaveToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LineStylePreviewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // HorListBox
            // 
            this.HorListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HorListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.HorListBox.FormattingEnabled = true;
            this.HorListBox.Location = new System.Drawing.Point(302, 26);
            this.HorListBox.Name = "HorListBox";
            this.HorListBox.Size = new System.Drawing.Size(138, 106);
            this.HorListBox.TabIndex = 0;
            this.HorListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox_DrawItem);
            this.HorListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // VerListBox
            // 
            this.VerListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VerListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.VerListBox.FormattingEnabled = true;
            this.VerListBox.Location = new System.Drawing.Point(302, 154);
            this.VerListBox.Name = "VerListBox";
            this.VerListBox.Size = new System.Drawing.Size(138, 106);
            this.VerListBox.TabIndex = 0;
            this.VerListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox_DrawItem);
            this.VerListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // LineWidthNumBox
            // 
            this.LineWidthNumBox.Location = new System.Drawing.Point(222, 26);
            this.LineWidthNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LineWidthNumBox.Name = "LineWidthNumBox";
            this.LineWidthNumBox.Size = new System.Drawing.Size(50, 22);
            this.LineWidthNumBox.TabIndex = 1;
            this.LineWidthNumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LineWidthNumBox.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.LineWidthNumBox.ValueChanged += new System.EventHandler(this.LineWidthNumBox_ValueChanged);
            // 
            // HorMoveDown
            // 
            this.HorMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.HorMoveDown.Location = new System.Drawing.Point(446, 55);
            this.HorMoveDown.Name = "HorMoveDown";
            this.HorMoveDown.Size = new System.Drawing.Size(26, 23);
            this.HorMoveDown.TabIndex = 2;
            this.HorMoveDown.Text = "▼";
            this.HorMoveDown.UseVisualStyleBackColor = true;
            this.HorMoveDown.Click += new System.EventHandler(this.MoveDown_Click);
            // 
            // HorDelete
            // 
            this.HorDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.HorDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HorDelete.Location = new System.Drawing.Point(446, 109);
            this.HorDelete.Name = "HorDelete";
            this.HorDelete.Size = new System.Drawing.Size(26, 23);
            this.HorDelete.TabIndex = 3;
            this.HorDelete.Text = "X";
            this.HorDelete.UseVisualStyleBackColor = true;
            this.HorDelete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // HorMoveUp
            // 
            this.HorMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.HorMoveUp.Location = new System.Drawing.Point(446, 26);
            this.HorMoveUp.Name = "HorMoveUp";
            this.HorMoveUp.Size = new System.Drawing.Size(26, 23);
            this.HorMoveUp.TabIndex = 1;
            this.HorMoveUp.Text = "▲";
            this.HorMoveUp.UseVisualStyleBackColor = true;
            this.HorMoveUp.Click += new System.EventHandler(this.MoveUp_Click);
            // 
            // VerMoveDown
            // 
            this.VerMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.VerMoveDown.Location = new System.Drawing.Point(446, 183);
            this.VerMoveDown.Name = "VerMoveDown";
            this.VerMoveDown.Size = new System.Drawing.Size(26, 23);
            this.VerMoveDown.TabIndex = 2;
            this.VerMoveDown.Text = "▼";
            this.VerMoveDown.UseVisualStyleBackColor = true;
            this.VerMoveDown.Click += new System.EventHandler(this.MoveDown_Click);
            // 
            // VerDelete
            // 
            this.VerDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.VerDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerDelete.Location = new System.Drawing.Point(446, 237);
            this.VerDelete.Name = "VerDelete";
            this.VerDelete.Size = new System.Drawing.Size(26, 23);
            this.VerDelete.TabIndex = 3;
            this.VerDelete.Text = "X";
            this.VerDelete.UseVisualStyleBackColor = true;
            this.VerDelete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // VerMoveUp
            // 
            this.VerMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.VerMoveUp.Location = new System.Drawing.Point(446, 154);
            this.VerMoveUp.Name = "VerMoveUp";
            this.VerMoveUp.Size = new System.Drawing.Size(26, 23);
            this.VerMoveUp.TabIndex = 1;
            this.VerMoveUp.Text = "▲";
            this.VerMoveUp.UseVisualStyleBackColor = true;
            this.VerMoveUp.Click += new System.EventHandler(this.MoveUp_Click);
            // 
            // LineWidthLabel
            // 
            this.LineWidthLabel.AutoSize = true;
            this.LineWidthLabel.Location = new System.Drawing.Point(9, 9);
            this.LineWidthLabel.Name = "LineWidthLabel";
            this.LineWidthLabel.Size = new System.Drawing.Size(63, 13);
            this.LineWidthLabel.TabIndex = 16;
            this.LineWidthLabel.Text = "Line Width";
            // 
            // LineWidthTrackBar
            // 
            this.LineWidthTrackBar.AutoSize = false;
            this.LineWidthTrackBar.Location = new System.Drawing.Point(12, 26);
            this.LineWidthTrackBar.Maximum = 100;
            this.LineWidthTrackBar.Minimum = 1;
            this.LineWidthTrackBar.Name = "LineWidthTrackBar";
            this.LineWidthTrackBar.Size = new System.Drawing.Size(204, 24);
            this.LineWidthTrackBar.TabIndex = 0;
            this.LineWidthTrackBar.TickFrequency = 10;
            this.LineWidthTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.LineWidthTrackBar.Value = 4;
            this.LineWidthTrackBar.Scroll += new System.EventHandler(this.LineWidthTrackBar_Scroll);
            // 
            // LineSpaceLabel
            // 
            this.LineSpaceLabel.AutoSize = true;
            this.LineSpaceLabel.Location = new System.Drawing.Point(9, 58);
            this.LineSpaceLabel.Name = "LineSpaceLabel";
            this.LineSpaceLabel.Size = new System.Drawing.Size(100, 13);
            this.LineSpaceLabel.TabIndex = 18;
            this.LineSpaceLabel.Text = "Spacing After Line";
            // 
            // LineSpaceTrackBar
            // 
            this.LineSpaceTrackBar.AutoSize = false;
            this.LineSpaceTrackBar.Location = new System.Drawing.Point(12, 75);
            this.LineSpaceTrackBar.Maximum = 100;
            this.LineSpaceTrackBar.Name = "LineSpaceTrackBar";
            this.LineSpaceTrackBar.Size = new System.Drawing.Size(203, 24);
            this.LineSpaceTrackBar.TabIndex = 2;
            this.LineSpaceTrackBar.TickFrequency = 10;
            this.LineSpaceTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.LineSpaceTrackBar.Value = 16;
            this.LineSpaceTrackBar.Scroll += new System.EventHandler(this.LineSpaceTrackBar_Scroll);
            // 
            // LineSpaceNumBox
            // 
            this.LineSpaceNumBox.Location = new System.Drawing.Point(222, 75);
            this.LineSpaceNumBox.Name = "LineSpaceNumBox";
            this.LineSpaceNumBox.Size = new System.Drawing.Size(50, 22);
            this.LineSpaceNumBox.TabIndex = 3;
            this.LineSpaceNumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LineSpaceNumBox.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.LineSpaceNumBox.ValueChanged += new System.EventHandler(this.LineSpaceNumBox_ValueChanged);
            // 
            // LineStyleComboBox
            // 
            this.LineStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LineStyleComboBox.FormattingEnabled = true;
            this.LineStyleComboBox.Items.AddRange(new object[] {
            "Solid - 100% Opacity",
            "Solid - 66% Opacity",
            "Solid - 33% Opacity",
            "Diagonal - Upward",
            "Diagonal - Downward",
            "Dots - 50/50"});
            this.LineStyleComboBox.Location = new System.Drawing.Point(11, 260);
            this.LineStyleComboBox.Name = "LineStyleComboBox";
            this.LineStyleComboBox.Size = new System.Drawing.Size(140, 21);
            this.LineStyleComboBox.TabIndex = 5;
            this.LineStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.LineStyleComboBox_SelectedIndexChanged);
            // 
            // LineStyleLabel
            // 
            this.LineStyleLabel.AutoSize = true;
            this.LineStyleLabel.Location = new System.Drawing.Point(9, 241);
            this.LineStyleLabel.Name = "LineStyleLabel";
            this.LineStyleLabel.Size = new System.Drawing.Size(55, 13);
            this.LineStyleLabel.TabIndex = 22;
            this.LineStyleLabel.Text = "Line Style";
            // 
            // LineColorLabel
            // 
            this.LineColorLabel.AutoSize = true;
            this.LineColorLabel.Location = new System.Drawing.Point(9, 107);
            this.LineColorLabel.Name = "LineColorLabel";
            this.LineColorLabel.Size = new System.Drawing.Size(59, 13);
            this.LineColorLabel.TabIndex = 20;
            this.LineColorLabel.Text = "Line Color";
            // 
            // AddToHor
            // 
            this.AddToHor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddToHor.Location = new System.Drawing.Point(11, 305);
            this.AddToHor.Name = "AddToHor";
            this.AddToHor.Size = new System.Drawing.Size(75, 23);
            this.AddToHor.TabIndex = 6;
            this.AddToHor.Text = "Horizontal";
            this.AddToHor.UseVisualStyleBackColor = true;
            this.AddToHor.Click += new System.EventHandler(this.AddToHor_Click);
            // 
            // AddToVer
            // 
            this.AddToVer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddToVer.Location = new System.Drawing.Point(104, 305);
            this.AddToVer.Name = "AddToVer";
            this.AddToVer.Size = new System.Drawing.Size(75, 23);
            this.AddToVer.TabIndex = 7;
            this.AddToVer.Text = "Vertical";
            this.AddToVer.UseVisualStyleBackColor = true;
            this.AddToVer.Click += new System.EventHandler(this.AddToVer_Click);
            // 
            // AddToBoth
            // 
            this.AddToBoth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddToBoth.Location = new System.Drawing.Point(197, 305);
            this.AddToBoth.Name = "AddToBoth";
            this.AddToBoth.Size = new System.Drawing.Size(75, 23);
            this.AddToBoth.TabIndex = 8;
            this.AddToBoth.Text = "Both";
            this.AddToBoth.UseVisualStyleBackColor = true;
            this.AddToBoth.Click += new System.EventHandler(this.AddToBoth_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Cancel.Location = new System.Drawing.Point(397, 347);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 15;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Ok
            // 
            this.Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Ok.Location = new System.Drawing.Point(316, 347);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 14;
            this.Ok.Text = "OK";
            this.Ok.UseVisualStyleBackColor = true;
            // 
            // Divider2
            // 
            this.Divider2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Divider2.Location = new System.Drawing.Point(12, 337);
            this.Divider2.Name = "Divider2";
            this.Divider2.Size = new System.Drawing.Size(460, 1);
            this.Divider2.TabIndex = 28;
            // 
            // Divider1
            // 
            this.Divider1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Divider1.Location = new System.Drawing.Point(287, 12);
            this.Divider1.Name = "Divider1";
            this.Divider1.Size = new System.Drawing.Size(1, 325);
            this.Divider1.TabIndex = 29;
            // 
            // UseHorForVer
            // 
            this.UseHorForVer.AutoSize = true;
            this.UseHorForVer.Location = new System.Drawing.Point(302, 266);
            this.UseHorForVer.Name = "UseHorForVer";
            this.UseHorForVer.Size = new System.Drawing.Size(179, 17);
            this.UseHorForVer.TabIndex = 11;
            this.UseHorForVer.Text = "Use Horizontal set for Vertical";
            this.UseHorForVer.UseVisualStyleBackColor = true;
            this.UseHorForVer.CheckedChanged += new System.EventHandler(this.UseHorForVer_CheckedChanged);
            // 
            // BackgroundColorBox
            // 
            this.BackgroundColorBox.BackColor = System.Drawing.Color.White;
            this.BackgroundColorBox.Location = new System.Drawing.Point(302, 306);
            this.BackgroundColorBox.Name = "BackgroundColorBox";
            this.BackgroundColorBox.Size = new System.Drawing.Size(80, 20);
            this.BackgroundColorBox.TabIndex = 12;
            this.BackgroundColorBox.Click += new System.EventHandler(this.BackgroundColorBox_Click);
            this.BackgroundColorBox.Paint += new System.Windows.Forms.PaintEventHandler(this.BackgroundColorBox_Paint);
            // 
            // BackgroundLabel
            // 
            this.BackgroundLabel.AutoSize = true;
            this.BackgroundLabel.Location = new System.Drawing.Point(299, 289);
            this.BackgroundLabel.Name = "BackgroundLabel";
            this.BackgroundLabel.Size = new System.Drawing.Size(101, 13);
            this.BackgroundLabel.TabIndex = 26;
            this.BackgroundLabel.Text = "Background Color";
            // 
            // AddToLabel
            // 
            this.AddToLabel.AutoSize = true;
            this.AddToLabel.Location = new System.Drawing.Point(9, 289);
            this.AddToLabel.Name = "AddToLabel";
            this.AddToLabel.Size = new System.Drawing.Size(51, 13);
            this.AddToLabel.TabIndex = 24;
            this.AddToLabel.Text = "Add to...";
            // 
            // LineColorWheel
            // 
            this.LineColorWheel.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LineColorWheel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineColorWheel.Location = new System.Drawing.Point(12, 124);
            this.LineColorWheel.Margin = new System.Windows.Forms.Padding(0);
            this.LineColorWheel.Name = "LineColorWheel";
            this.LineColorWheel.Size = new System.Drawing.Size(260, 110);
            this.LineColorWheel.TabIndex = 4;
            this.LineColorWheel.ValueChanged += new System.EventHandler(this.LineColorWheel_ValueChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Location = new System.Drawing.Point(13, 63);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(260, 1);
            this.panel4.TabIndex = 19;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel6.Location = new System.Drawing.Point(11, 246);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(260, 1);
            this.panel6.TabIndex = 23;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel7.Location = new System.Drawing.Point(13, 112);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(260, 1);
            this.panel7.TabIndex = 21;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel8.Location = new System.Drawing.Point(13, 294);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(260, 1);
            this.panel8.TabIndex = 25;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(13, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 1);
            this.panel1.TabIndex = 17;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel9.Location = new System.Drawing.Point(302, 294);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(170, 1);
            this.panel9.TabIndex = 27;
            // 
            // LoadSaveToolStrip
            // 
            this.LoadSaveToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.LoadSaveToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.LoadSaveToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadButton,
            this.SaveButton});
            this.LoadSaveToolStrip.Location = new System.Drawing.Point(12, 347);
            this.LoadSaveToolStrip.Name = "LoadSaveToolStrip";
            this.LoadSaveToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.LoadSaveToolStrip.Size = new System.Drawing.Size(107, 25);
            this.LoadSaveToolStrip.TabIndex = 13;
            this.LoadSaveToolStrip.Text = "toolStrip1";
            // 
            // LoadButton
            // 
            this.LoadButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadButton.Image")));
            this.LoadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(53, 22);
            this.LoadButton.Text = "Load";
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(51, 22);
            this.SaveButton.Text = "Save";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "XML Files (*.xml) | *.xml";
            this.openFileDialog1.Title = "Load Tartan";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "XML Files (*.xml) | *.xml";
            this.saveFileDialog1.Title = "Save Tartan";
            // 
            // LineStylePreviewBox
            // 
            this.LineStylePreviewBox.Location = new System.Drawing.Point(160, 260);
            this.LineStylePreviewBox.Name = "LineStylePreviewBox";
            this.LineStylePreviewBox.Size = new System.Drawing.Size(20, 20);
            this.LineStylePreviewBox.TabIndex = 36;
            this.LineStylePreviewBox.TabStop = false;
            this.LineStylePreviewBox.Paint += new System.Windows.Forms.PaintEventHandler(this.LineStylePreviewBox_Paint);
            // 
            // HorSetLabel
            // 
            this.HorSetLabel.AutoSize = true;
            this.HorSetLabel.Location = new System.Drawing.Point(299, 9);
            this.HorSetLabel.Name = "HorSetLabel";
            this.HorSetLabel.Size = new System.Drawing.Size(80, 13);
            this.HorSetLabel.TabIndex = 37;
            this.HorSetLabel.Text = "Horizontal Set";
            // 
            // VerSetLabel
            // 
            this.VerSetLabel.AutoSize = true;
            this.VerSetLabel.Location = new System.Drawing.Point(299, 137);
            this.VerSetLabel.Name = "VerSetLabel";
            this.VerSetLabel.Size = new System.Drawing.Size(64, 13);
            this.VerSetLabel.TabIndex = 38;
            this.VerSetLabel.Text = "Vertical Set";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Location = new System.Drawing.Point(302, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 1);
            this.panel2.TabIndex = 39;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Location = new System.Drawing.Point(302, 14);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(170, 1);
            this.panel3.TabIndex = 40;
            // 
            // TartanConfigDialog
            // 
            this.AcceptButton = this.Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(484, 377);
            this.Controls.Add(this.VerSetLabel);
            this.Controls.Add(this.HorSetLabel);
            this.Controls.Add(this.VerMoveDown);
            this.Controls.Add(this.HorMoveDown);
            this.Controls.Add(this.VerDelete);
            this.Controls.Add(this.LineStylePreviewBox);
            this.Controls.Add(this.VerMoveUp);
            this.Controls.Add(this.HorDelete);
            this.Controls.Add(this.VerListBox);
            this.Controls.Add(this.LoadSaveToolStrip);
            this.Controls.Add(this.HorMoveUp);
            this.Controls.Add(this.BackgroundLabel);
            this.Controls.Add(this.HorListBox);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.LineWidthLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AddToLabel);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.LineColorLabel);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.LineStyleLabel);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.LineSpaceLabel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.LineColorWheel);
            this.Controls.Add(this.BackgroundColorBox);
            this.Controls.Add(this.UseHorForVer);
            this.Controls.Add(this.Divider1);
            this.Controls.Add(this.Divider2);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.AddToBoth);
            this.Controls.Add(this.AddToVer);
            this.Controls.Add(this.AddToHor);
            this.Controls.Add(this.LineStyleComboBox);
            this.Controls.Add(this.LineSpaceNumBox);
            this.Controls.Add(this.LineSpaceTrackBar);
            this.Controls.Add(this.LineWidthTrackBar);
            this.Controls.Add(this.LineWidthNumBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TartanConfigDialog";
            this.Text = "Tartan";
            this.UseAppThemeColors = true;
            this.Load += new System.EventHandler(this.TartanConfigDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LineWidthNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineWidthTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineSpaceTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineSpaceNumBox)).EndInit();
            this.LoadSaveToolStrip.ResumeLayout(false);
            this.LoadSaveToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LineStylePreviewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox HorListBox;
        private System.Windows.Forms.ListBox VerListBox;
        private System.Windows.Forms.NumericUpDown LineWidthNumBox;
        private System.Windows.Forms.Button HorMoveDown;
        private System.Windows.Forms.Button HorDelete;
        private System.Windows.Forms.Button HorMoveUp;
        private System.Windows.Forms.Button VerMoveDown;
        private System.Windows.Forms.Button VerDelete;
        private System.Windows.Forms.Button VerMoveUp;
        private System.Windows.Forms.Label LineWidthLabel;
        private System.Windows.Forms.TrackBar LineWidthTrackBar;
        private System.Windows.Forms.Label LineSpaceLabel;
        private System.Windows.Forms.TrackBar LineSpaceTrackBar;
        private System.Windows.Forms.NumericUpDown LineSpaceNumBox;
        private System.Windows.Forms.ComboBox LineStyleComboBox;
        private System.Windows.Forms.Label LineStyleLabel;
        private System.Windows.Forms.Label LineColorLabel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button AddToHor;
        private System.Windows.Forms.Button AddToVer;
        private System.Windows.Forms.Button AddToBoth;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Panel Divider2;
        private System.Windows.Forms.Panel Divider1;
        private System.Windows.Forms.CheckBox UseHorForVer;
        private System.Windows.Forms.Panel BackgroundColorBox;
        private System.Windows.Forms.Label BackgroundLabel;
        private System.Windows.Forms.Label AddToLabel;
        private Controlz.PdnColor LineColorWheel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ToolStrip LoadSaveToolStrip;
        private System.Windows.Forms.ToolStripButton LoadButton;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox LineStylePreviewBox;
        private System.Windows.Forms.Label HorSetLabel;
        private System.Windows.Forms.Label VerSetLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}