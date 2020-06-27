using PaintDotNet.Effects;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TartanEffect
{
    internal partial class TartanConfigDialog : EffectConfigDialog<TartanEffectPlugin, TartanConfigToken>
    {
        public TartanConfigDialog()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LineWidthNumBox.ForeColor = this.ForeColor;
            LineWidthNumBox.BackColor = this.BackColor;
            LineSpaceNumBox.ForeColor = this.ForeColor;
            LineSpaceNumBox.BackColor = this.BackColor;
            VerListBox.ForeColor = this.ForeColor;
            VerListBox.BackColor = this.BackColor;
            HorListBox.ForeColor = this.ForeColor;
            HorListBox.BackColor = this.BackColor;
            LoadSaveToolStrip.ForeColor = this.ForeColor;
            LoadSaveToolStrip.BackColor = this.BackColor;

            LineColorWheel.Color = Effect.EnvironmentParameters.PrimaryColor;
            LineStyleComboBox.SelectedIndex = 0;
            ListButtonStates(0);

            SizeF DPI = new SizeF(this.AutoScaleDimensions.Width / 96f, this.AutoScaleDimensions.Height / 96f);
            HorListBox.ItemHeight = (int)Math.Round(HorListBox.ItemHeight * DPI.Height);
            HorListBox.Height = HorDelete.Bottom - HorMoveUp.Top;
            VerListBox.ItemHeight = (int)Math.Round(VerListBox.ItemHeight * DPI.Height);
            VerListBox.Height = VerDelete.Bottom - VerMoveUp.Top;
        }

        private void LineWidthTrackBar_Scroll(object sender, EventArgs e)
        {
            LineWidthNumBox.Value = LineWidthTrackBar.Value;
        }

        private void LineWidthNumBox_ValueChanged(object sender, EventArgs e)
        {
            LineWidthTrackBar.Value = (int)LineWidthNumBox.Value;
        }

        private void LineSpaceTrackBar_Scroll(object sender, EventArgs e)
        {
            LineSpaceNumBox.Value = LineSpaceTrackBar.Value;
        }

        private void LineSpaceNumBox_ValueChanged(object sender, EventArgs e)
        {
            LineSpaceTrackBar.Value = (int)LineSpaceNumBox.Value;
        }

        private void LineStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LineStylePreviewBox.Refresh();
        }

        private void LineColorWheel_ValueChanged(object sender, EventArgs e)
        {
            LineStylePreviewBox.Refresh();
        }

        private void LineStylePreviewBox_Paint(object sender, PaintEventArgs e)
        {
            Rectangle boxRect = e.ClipRectangle;
            boxRect.Width--;
            boxRect.Height--;

            using (HatchBrush checkered = new HatchBrush(HatchStyle.LargeCheckerBoard, Color.White, Color.Silver))
                e.Graphics.FillRectangle(checkered, boxRect);
            using (Brush style = GetItemBrush(LineStyleComboBox.SelectedIndex, LineColorWheel.Color))
                e.Graphics.FillRectangle(style, boxRect);
            e.Graphics.DrawRectangle(Pens.Black, boxRect);
            boxRect.Width -= 2;
            boxRect.Height -= 2;
            boxRect.Offset(1, 1);
            e.Graphics.DrawRectangle(Pens.White, boxRect);
        }

        private void AddToHor_Click(object sender, EventArgs e)
        {
            // Create the item and add it to the list box
            Item lineItem = new Item(LineWidthTrackBar.Value, LineSpaceTrackBar.Value, LineStyleComboBox.SelectedIndex, LineColorWheel.Color);
            HorListBox.Items.Add(lineItem);

            ListButtonStates(1);

            FinishTokenUpdate();
        }

        private void AddToVer_Click(object sender, EventArgs e)
        {
            // Create the item and add it to the list box
            Item lineItem = new Item(LineWidthTrackBar.Value, LineSpaceTrackBar.Value, LineStyleComboBox.SelectedIndex, LineColorWheel.Color);
            VerListBox.Items.Add(lineItem);

            ListButtonStates(2);

            FinishTokenUpdate();
        }

        private void AddToBoth_Click(object sender, EventArgs e)
        {
            // Create the item and add it to the list box
            Item lineItem = new Item(LineWidthTrackBar.Value, LineSpaceTrackBar.Value, LineStyleComboBox.SelectedIndex, LineColorWheel.Color);
            HorListBox.Items.Add(lineItem);
            VerListBox.Items.Add(lineItem);

            ListButtonStates(0);

            FinishTokenUpdate();
        }

        private void BackgroundColorBox_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorDialog1.ShowDialog())
            {
                BackgroundColorBox.BackColor = colorDialog1.Color;

                FinishTokenUpdate();
            }
        }

        private void BackgroundColorBox_Paint(object sender, PaintEventArgs e)
        {
            Rectangle boxRect = e.ClipRectangle;
            boxRect.Width--;
            boxRect.Height--;
            e.Graphics.DrawRectangle(Pens.Black, boxRect);
            boxRect.Width -= 2;
            boxRect.Height -= 2;
            boxRect.Offset(1, 1);
            e.Graphics.DrawRectangle(Pens.White, boxRect);
        }

        private void UseHorForVer_CheckedChanged(object sender, EventArgs e)
        {
            VerListBox.Enabled = !UseHorForVer.Checked;
            VerMoveUp.Enabled = !UseHorForVer.Checked;
            VerMoveDown.Enabled = !UseHorForVer.Checked;
            VerDelete.Enabled = !UseHorForVer.Checked;
            AddToVer.Enabled = !UseHorForVer.Checked;
            AddToBoth.Enabled = !UseHorForVer.Checked;

            FinishTokenUpdate();
        }

        private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;

            e.DrawBackground();
            e.DrawFocusRectangle();

            // Get the item
            ListBox listBox = (sender as ListBox);
            Item item = (Item)listBox.Items[e.Index];

            // Draw a small box for the item's color
            Rectangle box = e.Bounds;
            box.Height -= 4;
            box.Width = box.Height;
            box.X += 2;
            box.Y += 2;
            using (SolidBrush backColorB = new SolidBrush(BackgroundColorBox.BackColor))
                e.Graphics.FillRectangle(backColorB, box);
            using (Brush styleB = GetItemBrush(item.Style, item.Color))
                e.Graphics.FillRectangle(styleB, box);

            // Draw the item's text
            string itemText = $"{item.Width} px W - {item.Spacing} px S";
            using (SolidBrush textB = new SolidBrush(e.ForeColor))
                e.Graphics.DrawString(itemText, e.Font, textB, box.Right + 2, box.Top - (4 * (e.Graphics.DpiY / 96f)));
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListButtonStates((sender == HorListBox) ? 1 : 2);
        }

        // Remove Line
        private void Delete_Click(object sender, EventArgs e)
        {
            ListBox listBox = (sender == HorDelete) ? HorListBox : VerListBox;

            if (listBox.SelectedIndex == -1)
                return;

            if (listBox.Items.Count == 1)
            {
                listBox.Items.RemoveAt(listBox.SelectedIndex);
            }
            else if (listBox.SelectedIndex < listBox.Items.Count - 1)
            {
                listBox.SelectedIndex++;
                listBox.Items.RemoveAt(listBox.SelectedIndex - 1);
            }
            else if (listBox.SelectedIndex == listBox.Items.Count - 1)
            {
                listBox.SelectedIndex--;
                listBox.Items.RemoveAt(listBox.SelectedIndex + 1);
            }
            else
            {
                return;
            }

            ListButtonStates((listBox == HorListBox) ? 1 : 2);

            FinishTokenUpdate();
        }

        // Move Line Up
        private void MoveUp_Click(object sender, EventArgs e)
        {
            ListBox listBox = (sender == HorMoveUp) ? HorListBox : VerListBox;

            if (listBox.SelectedIndex > 0)
            {
                listBox.Items.Insert(listBox.SelectedIndex - 1, listBox.SelectedItem);
                listBox.SelectedIndex -= 2;
                listBox.Items.RemoveAt(listBox.SelectedIndex + 2);

                FinishTokenUpdate();
            }
        }

        //Move Line Down
        private void MoveDown_Click(object sender, EventArgs e)
        {
            ListBox listBox = (sender == HorMoveDown) ? HorListBox : VerListBox;

            if (listBox.SelectedIndex != -1 && listBox.SelectedIndex < listBox.Items.Count - 1)
            {
                listBox.Items.Insert(listBox.SelectedIndex + 2, listBox.SelectedItem);
                listBox.SelectedIndex += 2;
                listBox.Items.RemoveAt(listBox.SelectedIndex - 2);

                FinishTokenUpdate();
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(TartanConfigToken));
                    TartanConfigToken token = (TartanConfigToken)serializer.Deserialize(fs);

                    this.InitDialogFromToken(token);
                }

                FinishTokenUpdate();
            }
            catch (IOException ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                string message = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show(this, message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(TartanConfigToken));
                    serializer.Serialize(fs, (TartanConfigToken)theEffectToken);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region EffectConfigDialog stuff
        protected override TartanConfigToken CreateInitialToken()
        {
            return new TartanConfigToken();
        }

        protected override void InitDialogFromToken(TartanConfigToken effectTokenCopy)
        {
            HorListBox.Items.Clear();
            VerListBox.Items.Clear();

            foreach (Item lineItem in effectTokenCopy.HorLines)
                HorListBox.Items.Add(lineItem);

            foreach (Item lineItem in effectTokenCopy.VerLines)
                VerListBox.Items.Add(lineItem);

            BackgroundColorBox.BackColor = effectTokenCopy.BackColor;

            UseHorForVer.Checked = effectTokenCopy.OneSet;
        }

        protected override void LoadIntoTokenFromDialog(TartanConfigToken writeValuesHere)
        {
            writeValuesHere.HorLines = HorListBox.Items.OfType<Item>().ToList();
            writeValuesHere.VerLines = VerListBox.Items.OfType<Item>().ToList();
            writeValuesHere.BackColor = BackgroundColorBox.BackColor;
            writeValuesHere.OneSet = UseHorForVer.Checked;
        }
        #endregion

        private void ListButtonStates(int listBox)
        {
            if (listBox == 1 || listBox == 0)
            {
                HorMoveUp.Enabled = (HorListBox.SelectedIndex > 0 && HorListBox.Items.Count > 1);
                HorMoveDown.Enabled = (HorListBox.SelectedIndex < HorListBox.Items.Count - 1 && HorListBox.Items.Count > 1 && HorListBox.SelectedIndex != -1);
                HorDelete.Enabled = (HorListBox.SelectedIndex != -1);
            }

            if (listBox == 2 || listBox == 0)
            {
                VerMoveUp.Enabled = (VerListBox.SelectedIndex > 0 && VerListBox.Items.Count > 1);
                VerMoveDown.Enabled = (VerListBox.SelectedIndex < VerListBox.Items.Count - 1 && VerListBox.Items.Count > 1 && VerListBox.SelectedIndex != -1);
                VerDelete.Enabled = (VerListBox.SelectedIndex != -1);
            }
        }

        private static Brush GetItemBrush(int style, Color color)
        {
            LineStyle lineStyle = Enum.IsDefined(typeof(LineStyle), 50) ? (LineStyle)style : 0;
            return GetItemBrush(lineStyle, color);
        }

        private static Brush GetItemBrush(LineStyle style, Color color)
        {
            switch (style)
            {
                case LineStyle.Solid100:
                    return new SolidBrush(color);
                case LineStyle.Solid66:
                    return new SolidBrush(Color.FromArgb(170, color));
                case LineStyle.Solid33:
                    return new SolidBrush(Color.FromArgb(85, color));
                case LineStyle.DiagonalUp:
                    return new HatchBrush(HatchStyle.DarkUpwardDiagonal, color, Color.Transparent);
                case LineStyle.DiagonalDown:
                    return new HatchBrush(HatchStyle.DarkDownwardDiagonal, color, Color.Transparent);
                case LineStyle.Dots:
                    return new HatchBrush(HatchStyle.Percent50, color, Color.Transparent);
                default:
                    return new SolidBrush(color);
            }
        }
    }

    public struct Item
    {
        public int Width { get; set; }
        public int Spacing { get; set; }

        [XmlIgnore]
        public LineStyle Style { get; set; }

        [XmlElement(nameof(Style))]
        public int StyleInt
        {
            get => (int)Style;
            set => Style = GetLineStyle(value);
        }

        [XmlIgnore]
        public Color Color { get; set; }

        [XmlElement(nameof(Color))]
        public string ColorHtml
        {
            get => ColorTranslator.ToHtml(Color);
            set => Color = ColorTranslator.FromHtml(value);
        }

        public Item(int width, int spacing, int style, Color color)
        {
            Spacing = spacing;
            Width = width;
            Style = GetLineStyle(style);
            Color = color;
        }

        private static LineStyle GetLineStyle(int integer)
        {
            return Enum.IsDefined(typeof(LineStyle), integer) ? (LineStyle)integer : 0;
        }
    }
}
