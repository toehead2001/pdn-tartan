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
            comboBox1.SelectedIndex = 0;
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

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Create the item and add it to the list box
            Item lineItem = new Item(trackBar1.Value, trackBar2.Value, comboBox1.SelectedIndex, colorWheelTR1.colorval);
            listBox1.Items.Add(lineItem);

            FinishTokenUpdate();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Create the item and add it to the list box
            Item lineItem = new Item(trackBar1.Value, trackBar2.Value, comboBox1.SelectedIndex, colorWheelTR1.colorval);
            listBox2.Items.Add(lineItem);

            FinishTokenUpdate();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Create the item and add it to the list box
            Item lineItem = new Item(trackBar1.Value, trackBar2.Value, comboBox1.SelectedIndex, colorWheelTR1.colorval);
            listBox1.Items.Add(lineItem);
            listBox2.Items.Add(lineItem);

            FinishTokenUpdate();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorDialog1.ShowDialog())
            {
                panel5.BackColor = colorDialog1.Color;

                FinishTokenUpdate();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = !checkBox1.Checked;
            button8.Enabled = !checkBox1.Checked;
            button9.Enabled = !checkBox1.Checked;

            FinishTokenUpdate();
        }


        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool selected = listBox1.SelectedIndex == e.Index;

            if (-1 == e.Index)
            {
                // Fill with background color and return
                using (SolidBrush temp = new SolidBrush(e.BackColor))
                {
                    e.Graphics.FillRectangle(temp, e.Bounds);
                }
                return;
            }

            // Get the item
            Item item = (Item)listBox1.Items[e.Index];

            // Start by filling the backgorund
            if (selected)
            {
                using (SolidBrush hiLighB = new SolidBrush(SystemColors.Highlight))
                {
                    e.Graphics.FillRectangle(hiLighB, e.Bounds);
                }
            }
            else
            {
                using (SolidBrush backB = new SolidBrush(e.BackColor))
                {
                    e.Graphics.FillRectangle(backB, e.Bounds);
                }
            }

            Brush styleB;
            switch (item.Style)
            {
                case 0:
                    styleB = new SolidBrush(item.Color);
                    break;
                case 1:
                    styleB = new SolidBrush(Color.FromArgb(170, item.Color));
                    break;
                case 2:
                    styleB = new SolidBrush(Color.FromArgb(85, item.Color));
                    break;
                case 3:
                    styleB = new HatchBrush(HatchStyle.DarkUpwardDiagonal, item.Color, Color.Transparent);
                    break;
                case 4:
                    styleB = new HatchBrush(HatchStyle.DarkDownwardDiagonal, item.Color, Color.Transparent);
                    break;
                case 5:
                    styleB = new HatchBrush(HatchStyle.Percent50, item.Color, Color.Transparent);
                    break;
                default:
                    styleB = new SolidBrush(item.Color);
                    break;
            }

            // Draw a small box for the item's color
            Rectangle box = e.Bounds;
            box.Height -= 4;
            box.Width = box.Height;
            box.X += 2;
            box.Y += 2;
            e.Graphics.FillRectangle(new SolidBrush(panel5.BackColor), box);
            e.Graphics.FillRectangle(styleB, box);

            // Draw the item's text
            SolidBrush textB = new SolidBrush(e.ForeColor);
            string itemText = item.Width + "px W - " + item.Spacing + "px S";
            e.Graphics.DrawString(itemText, listBox1.Font, textB, box.Right + 2, e.Bounds.Y);
        }

        private void listBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool selected = listBox2.SelectedIndex == e.Index;

            if (-1 == e.Index)
            {
                // Fill with background color and return
                using (SolidBrush temp = new SolidBrush(e.BackColor))
                {
                    e.Graphics.FillRectangle(temp, e.Bounds);
                }
                return;
            }

            // Get the item
            Item item = (Item)listBox2.Items[e.Index];

            // Start by filling the backgorund
            if (selected)
            {
                using (SolidBrush hiLighB = new SolidBrush(SystemColors.Highlight))
                {
                    e.Graphics.FillRectangle(hiLighB, e.Bounds);
                }
            }
            else
            {
                using (SolidBrush backB = new SolidBrush(e.BackColor))
                {
                    e.Graphics.FillRectangle(backB, e.Bounds);
                }
            }

            Brush styleB;
            switch (item.Style)
            {
                case 0:
                    styleB = new SolidBrush(item.Color);
                    break;
                case 1:
                    styleB = new SolidBrush(Color.FromArgb(170, item.Color));
                    break;
                case 2:
                    styleB = new SolidBrush(Color.FromArgb(85, item.Color));
                    break;
                case 3:
                    styleB = new HatchBrush(HatchStyle.DarkUpwardDiagonal, item.Color, Color.Transparent);
                    break;
                case 4:
                    styleB = new HatchBrush(HatchStyle.DarkDownwardDiagonal, item.Color, Color.Transparent);
                    break;
                case 5:
                    styleB = new HatchBrush(HatchStyle.Percent50, item.Color, Color.Transparent);
                    break;
                default:
                    styleB = new SolidBrush(item.Color);
                    break;
            }

            // Draw a small box for the item's color
            Rectangle box = e.Bounds;
            box.Height -= 4;
            box.Width = box.Height;
            box.X += 2;
            box.Y += 2;
            e.Graphics.FillRectangle(new SolidBrush(panel5.BackColor), box);
            e.Graphics.FillRectangle(styleB, box);

            // Draw the item's text
            SolidBrush textB = new SolidBrush(e.ForeColor);
            string itemText = item.Width + "px W - " + item.Spacing + "px S";
            e.Graphics.DrawString(itemText, listBox2.Font, textB, box.Right + 2, e.Bounds.Y);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Refresh();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Refresh();
        }

        // Remove Horizontal Line
        private void button2_Click(object sender, EventArgs e)
        {
            if ((listBox1.SelectedIndex != -1) && (listBox1.Items.Count == 1))
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);

                FinishTokenUpdate();
            }
            else if ((listBox1.SelectedIndex != -1) && (listBox1.SelectedIndex < listBox1.Items.Count - 1))
            {
                listBox1.SelectedIndex += 1;
                listBox1.Items.RemoveAt(listBox1.SelectedIndex - 1);

                FinishTokenUpdate();
            }
            else if ((listBox1.SelectedIndex != -1) && (listBox1.SelectedIndex == listBox1.Items.Count - 1))
            {
                listBox1.SelectedIndex -= 1;
                listBox1.Items.RemoveAt(listBox1.SelectedIndex + 1);

                FinishTokenUpdate();
            }
        }

        // Move Up Horizontal Line
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                listBox1.Items.Insert(listBox1.SelectedIndex - 1, listBox1.SelectedItem);
                listBox1.SelectedIndex -= 2;
                listBox1.Items.RemoveAt(listBox1.SelectedIndex + 2);

                FinishTokenUpdate();
            }
        }

        //Move Down Horizontal Line
        private void button3_Click(object sender, EventArgs e)
        {
            if ((listBox1.SelectedIndex != -1) && (listBox1.SelectedIndex < listBox1.Items.Count - 1))
            {
                listBox1.Items.Insert(listBox1.SelectedIndex + 2, listBox1.SelectedItem);
                listBox1.SelectedIndex += 2;
                listBox1.Items.RemoveAt(listBox1.SelectedIndex - 2);

                FinishTokenUpdate();
            }
        }

        // Remove Vertical Line
        private void button5_Click(object sender, EventArgs e)
        {
            if ((listBox2.SelectedIndex != -1) && (listBox2.Items.Count == 1))
            {
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);

                FinishTokenUpdate();
            }
            else if ((listBox2.SelectedIndex != -1) && (listBox2.SelectedIndex < listBox2.Items.Count - 1))
            {
                listBox2.SelectedIndex += 1;
                listBox2.Items.RemoveAt(listBox2.SelectedIndex - 1);

                FinishTokenUpdate();
            }
            else if ((listBox2.SelectedIndex != -1) && (listBox2.SelectedIndex == listBox2.Items.Count - 1))
            {
                listBox2.SelectedIndex -= 1;
                listBox2.Items.RemoveAt(listBox2.SelectedIndex + 1);

                FinishTokenUpdate();
            }
        }

        // Move Up Vertical Line
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex > 0)
            {
                listBox2.Items.Insert(listBox2.SelectedIndex - 1, listBox2.SelectedItem);
                listBox2.SelectedIndex -= 2;
                listBox2.Items.RemoveAt(listBox2.SelectedIndex + 2);

                FinishTokenUpdate();
            }
        }

        //Move Down Vertical Line
        private void button6_Click(object sender, EventArgs e)
        {
            if ((listBox2.SelectedIndex != -1) && (listBox2.SelectedIndex < listBox2.Items.Count - 1))
            {
                listBox2.Items.Insert(listBox2.SelectedIndex + 2, listBox2.SelectedItem);
                listBox2.SelectedIndex += 2;
                listBox2.Items.RemoveAt(listBox2.SelectedIndex - 2);

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

           panel5.BackColor = effectTokenCopy.BackColor;

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

           writeValuesHere.BackColor = panel5.BackColor;

           writeValuesHere.OneSet = checkBox1.Checked;
       }

       #endregion

    }

    public class Item
    {
        public int Width;
        public int Spacing;
        public int Style;

        [XmlIgnore]
        public Color Color;

        [XmlElement("Color")]
        public string ClrGridHtml
        {
            get { return ColorTranslator.ToHtml(Color); }
            set { Color = ColorTranslator.FromHtml(value); }
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
