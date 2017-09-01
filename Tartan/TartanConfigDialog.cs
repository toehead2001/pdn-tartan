using PaintDotNet.Effects;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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

        private void TartanConfigDialog_Load(object sender, EventArgs e)
        {
            LineColorWheel.Color = Effect.EnvironmentParameters.PrimaryColor;
            LineStyleComboBox.SelectedIndex = 0;
            ListButtonStates(0);

            float DPI = this.AutoScaleDimensions.Width / 96f;
            HorListBox.ItemHeight = (int)(HorListBox.ItemHeight * DPI);
            HorListBox.Size = new Size((int)(126 * DPI), (int)(95 * DPI));
            VerListBox.ItemHeight = (int)(VerListBox.ItemHeight * DPI);
            VerListBox.Size = new Size((int)(126 * DPI), (int)(95 * DPI));
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

        private void LineColorWheel_ValueChanged(object sender, Color e)
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
            VerGroupBox.Enabled = !UseHorForVer.Checked;
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
            string itemText = item.Width + "px W - " + item.Spacing + "px S";
            using (SolidBrush textB = new SolidBrush(e.ForeColor))
                e.Graphics.DrawString(itemText, listBox.Font, textB, box.Right + 2, box.Top - (4 * (e.Graphics.DpiY / 96f)));
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
                listBox.SelectedIndex += 1;
                listBox.Items.RemoveAt(listBox.SelectedIndex - 1);
            }
            else if (listBox.SelectedIndex == listBox.Items.Count - 1)
            {
                listBox.SelectedIndex -= 1;
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
            writeValuesHere.HorLines.Clear();
            for (int i = 0; i < HorListBox.Items.Count; i++)
                writeValuesHere.HorLines.Add((Item)HorListBox.Items[i]);

            writeValuesHere.VerLines.Clear();
            for (int i = 0; i < VerListBox.Items.Count; i++)
                writeValuesHere.VerLines.Add((Item)VerListBox.Items[i]);

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
            Brush itemBrush;
            switch (style)
            {
                case 0:
                    itemBrush = new SolidBrush(color);
                    break;
                case 1:
                    itemBrush = new SolidBrush(Color.FromArgb(170, color));
                    break;
                case 2:
                    itemBrush = new SolidBrush(Color.FromArgb(85, color));
                    break;
                case 3:
                    itemBrush = new HatchBrush(HatchStyle.DarkUpwardDiagonal, color, Color.Transparent);
                    break;
                case 4:
                    itemBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, color, Color.Transparent);
                    break;
                case 5:
                    itemBrush = new HatchBrush(HatchStyle.Percent50, color, Color.Transparent);
                    break;
                default:
                    itemBrush = new SolidBrush(color);
                    break;
            }
            return itemBrush;
        }
    }

    public struct Item
    {
        public int Width { get; set; }
        public int Spacing { get; set; }
        public int Style { get; set; }

        [XmlIgnore]
        public Color Color { get; set; }

        [XmlElement("Color")]
        public string ColorHtml
        {
            get => ColorTranslator.ToHtml(Color);
            set => Color = ColorTranslator.FromHtml(value);
        }

        public Item(int width, int spacing, int style, Color color)
        {
            Spacing = spacing;
            Width = width;
            Style = style;
            Color = color;
        }
    }
}
