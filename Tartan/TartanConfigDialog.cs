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
            pdnColor1.Color = Effect.EnvironmentParameters.PrimaryColor;
            comboBox1.SelectedIndex = 0;
            ListButtonStates(0);

            float DPI = this.AutoScaleDimensions.Width / 96f;
            listBox1.ItemHeight = (int)(listBox1.ItemHeight * DPI);
            listBox1.Size = new Size((int)(126 * DPI), (int)(95 * DPI));
            listBox2.ItemHeight = (int)(listBox2.ItemHeight * DPI);
            listBox2.Size = new Size((int)(126 * DPI), (int)(95 * DPI));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numericUpDown1.Value = trackBar1.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = (int)numericUpDown1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            numericUpDown2.Value = trackBar2.Value;

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            trackBar2.Value = (int)numericUpDown2.Value;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            styleBox.Refresh();
        }

        private void pdnColor1_ValueChanged(object sender, Color e)
        {
            styleBox.Refresh();
        }

        private void styleBox_Paint(object sender, PaintEventArgs e)
        {
            Rectangle boxRect = e.ClipRectangle;
            boxRect.Width--;
            boxRect.Height--;

            using (HatchBrush checkered = new HatchBrush(HatchStyle.LargeCheckerBoard, Color.White, Color.Silver))
                e.Graphics.FillRectangle(checkered, boxRect);
            using (Brush style = getItemBrush(comboBox1.SelectedIndex, pdnColor1.Color))
                e.Graphics.FillRectangle(style, boxRect);
            e.Graphics.DrawRectangle(Pens.Black, boxRect);
            boxRect.Width -= 2;
            boxRect.Height -= 2;
            boxRect.Offset(1, 1);
            e.Graphics.DrawRectangle(Pens.White, boxRect);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Create the item and add it to the list box
            Item lineItem = new Item(trackBar1.Value, trackBar2.Value, comboBox1.SelectedIndex, pdnColor1.Color);
            listBox1.Items.Add(lineItem);

            ListButtonStates(1);

            FinishTokenUpdate();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Create the item and add it to the list box
            Item lineItem = new Item(trackBar1.Value, trackBar2.Value, comboBox1.SelectedIndex, pdnColor1.Color);
            listBox2.Items.Add(lineItem);

            ListButtonStates(2);

            FinishTokenUpdate();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Create the item and add it to the list box
            Item lineItem = new Item(trackBar1.Value, trackBar2.Value, comboBox1.SelectedIndex, pdnColor1.Color);
            listBox1.Items.Add(lineItem);
            listBox2.Items.Add(lineItem);

            ListButtonStates(0);

            FinishTokenUpdate();
        }

        private void bgColorBox_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorDialog1.ShowDialog())
            {
                bgColorBox.BackColor = colorDialog1.Color;

                FinishTokenUpdate();
            }
        }

        private void bgColorBox_Paint(object sender, PaintEventArgs e)
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = !checkBox1.Checked;
            button8.Enabled = !checkBox1.Checked;
            button9.Enabled = !checkBox1.Checked;

            FinishTokenUpdate();
        }


        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
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
            using (SolidBrush backColorB = new SolidBrush(bgColorBox.BackColor))
                e.Graphics.FillRectangle(backColorB, box);
            using (Brush styleB = getItemBrush(item.Style, item.Color))
                e.Graphics.FillRectangle(styleB, box);

            // Draw the item's text
            string itemText = item.Width + "px W - " + item.Spacing + "px S";
            using (SolidBrush textB = new SolidBrush(e.ForeColor))
                e.Graphics.DrawString(itemText, listBox.Font, textB, box.Right + 2, box.Top - (4 * (e.Graphics.DpiY / 96f)));
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListButtonStates((sender == listBox1) ? 1 : 2);
        }

        // Remove Line
        private void Remove_Click(object sender, EventArgs e)
        {
            ListBox listBox = (sender == button2) ? listBox1 : listBox2;

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

            ListButtonStates((listBox == listBox1) ? 1 : 2);

            FinishTokenUpdate();
        }

        // Move Line Up
        private void MoveUp_Click(object sender, EventArgs e)
        {
            ListBox listBox = (sender == button1) ? listBox1 : listBox2;

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
            ListBox listBox = (sender == button3) ? listBox1 : listBox2;

            if ((listBox.SelectedIndex != -1) && (listBox.SelectedIndex < listBox.Items.Count - 1))
            {
                listBox.Items.Insert(listBox.SelectedIndex + 2, listBox.SelectedItem);
                listBox.SelectedIndex += 2;
                listBox.Items.RemoveAt(listBox.SelectedIndex - 2);

                FinishTokenUpdate();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(TartanConfigToken));
                        TartanConfigToken token = (TartanConfigToken)serializer.Deserialize(fs);

                        this.InitDialogFromToken(token);

                        FinishTokenUpdate();
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (InvalidOperationException ex)
                {
                    string message = ex.Message;
                    if (ex.InnerException != null)
                    {
                        message = ex.InnerException.Message; // The XMLSerializer class wraps most Exceptions in an InvalidOperationException.
                    }

                    MessageBox.Show(this, message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
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
        }

        #region EffectConfigDialog stuff

        protected override TartanConfigToken CreateInitialToken()
        {
            return new TartanConfigToken();
        }

        protected override void InitDialogFromToken(TartanConfigToken effectTokenCopy)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            foreach (Item lineItem in effectTokenCopy.HorLines)
            {
                Item item = new Item(lineItem.Width, lineItem.Spacing, lineItem.Style, lineItem.Color);
                listBox1.Items.Add(item);
            }

            foreach (Item lineItem in effectTokenCopy.VerLines)
            {
                Item item = new Item(lineItem.Width, lineItem.Spacing, lineItem.Style, lineItem.Color);
                listBox2.Items.Add(item);
            }

            bgColorBox.BackColor = effectTokenCopy.BackColor;

            checkBox1.Checked = effectTokenCopy.OneSet;
        }

        protected override void LoadIntoTokenFromDialog(TartanConfigToken writeValuesHere)
        {
            writeValuesHere.HorLines.Clear();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Item item = (Item)listBox1.Items[i];

                writeValuesHere.HorLines.Add(new Item(item.Width, item.Spacing, item.Style, item.Color));
            }

            writeValuesHere.VerLines.Clear();
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                Item item = (Item)listBox2.Items[i];

                writeValuesHere.VerLines.Add(new Item(item.Width, item.Spacing, item.Style, item.Color));
            }

            writeValuesHere.BackColor = bgColorBox.BackColor;

            writeValuesHere.OneSet = checkBox1.Checked;
        }

        #endregion

        private void ListButtonStates(int listBox)
        {
            if (listBox == 1 || listBox == 0)
            {
                button1.Enabled = (listBox1.SelectedIndex > 0 && listBox1.Items.Count > 1);
                button3.Enabled = (listBox1.SelectedIndex < listBox1.Items.Count - 1 && listBox1.Items.Count > 1 && listBox1.SelectedIndex != -1);
                button2.Enabled = (listBox1.SelectedIndex != -1);
            }

            if (listBox == 2 || listBox == 0)
            {
                button4.Enabled = (listBox2.SelectedIndex > 0 && listBox2.Items.Count > 1);
                button6.Enabled = (listBox2.SelectedIndex < listBox2.Items.Count - 1 && listBox2.Items.Count > 1 && listBox2.SelectedIndex != -1);
                button5.Enabled = (listBox2.SelectedIndex != -1);
            }
        }

        static Brush getItemBrush(int style, Color color)
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

    public class Item
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

        public Item()
        {
        }
    }
}
