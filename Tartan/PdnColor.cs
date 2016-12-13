﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Controlz
{
    public partial class PdnColor : UserControl
    {
        bool mouseDown;
        bool ignore;
        double MasterHue;
        double MasterSat;
        double MasterVal;
        int MasterAlpha;
        Bitmap wheelBmp;
        Color[] HsvRainbow;

        public PdnColor()
        {
            InitializeComponent();

            HsvRainbow = new Color[65];
            for (float i = 0; i < 65; i++)
            {
                Color c = HSVtoRGB(255, i / 65, 1, 1);
                HsvRainbow[(int)i] = c;
            }
        }

        #region Control Properties
        public double Hue
        {
            get { return MasterHue * 360; }
        }
        public double Sat
        {
            get { return MasterSat * 100; }
        }
        public double Val
        {
            get { return MasterVal * 100; }
        }
        public int Alpha
        {
            get { return MasterAlpha; }
        }
        public Color Argb
        {
            get { return HSVtoRGB(MasterAlpha, MasterHue, MasterSat, MasterVal); }
            set
            {
                Color _colorval = value;
                MasterHue = RGBtoHSV(_colorval, MasterHue).Hue;
                MasterSat = RGBtoHSV(_colorval, MasterHue).Sat;
                MasterVal = RGBtoHSV(_colorval, MasterHue).Value;
                MasterAlpha = _colorval.A;
                setColors();
                UpdateColorSliders();
                colorWheelBox.Refresh();
                swatchBox.Refresh();
                OnValueChanged(_colorval);
            }
        }
        #endregion

        #region Event Handler
        public delegate void ValueChangedEventHandler(object sender, Color e);
        public event ValueChangedEventHandler ValueChanged;
        protected void OnValueChanged(Color e)
        {
            this.ValueChanged?.Invoke(this, e);
        }
        #endregion

        #region HSV/RGB Conversion functions
        private Color HSVtoRGB(int alpha, double h, double s, double v)
        {

            double r, g, b;
            if (s == 0)
            {
                r = v;
                g = v;
                b = v;
            }
            else
            {
                double varH = h * 6;
                double varI = Math.Floor(varH);
                double var1 = v * (1 - s);
                double var2 = v * (1 - (s * (varH - varI)));
                double var3 = v * (1 - (s * (1 - (varH - varI))));

                if (varI == 0)
                {
                    r = v;
                    g = var3;
                    b = var1;
                }
                else if (varI == 1)
                {
                    r = var2;
                    g = v;
                    b = var1;
                }
                else if (varI == 2)
                {
                    r = var1;
                    g = v;
                    b = var3;
                }
                else if (varI == 3)
                {
                    r = var1;
                    g = var2;
                    b = v;
                }
                else if (varI == 4)
                {
                    r = var3;
                    g = var1;
                    b = v;
                }
                else
                {
                    r = v;
                    g = var1;
                    b = var2;
                }
            }
            return Color.FromArgb(alpha, (int)(r * 255), (int)(g * 255), (int)(b * 255));
        }

        private HSVColor RGBtoHSV(Color c, double oldHue)
        {
            double r = (double)c.R / 255;
            double g = (double)c.G / 255;
            double b = (double)c.B / 255;
            double varMin = Math.Min(r, Math.Min(g, b));
            double varMax = Math.Max(r, Math.Max(g, b));
            double delMax = varMax - varMin;
            HSVColor hsv = new HSVColor();

            hsv.Value = varMax;

            if (delMax == 0)
            {
                hsv.Hue = oldHue;
                hsv.Sat = 0;
            }
            else
            {
                double delR = (((varMax - r) / 6) + (delMax / 2)) / delMax;
                double delG = (((varMax - g) / 6) + (delMax / 2)) / delMax;
                double delB = (((varMax - b) / 6) + (delMax / 2)) / delMax;

                hsv.Sat = delMax / varMax;

                if (r == varMax)
                {
                    hsv.Hue = delB - delG;
                }
                else if (g == varMax)
                {
                    hsv.Hue = (1.0 / 3) + delR - delB;
                }
                else //// if (b == varMax) 
                {
                    hsv.Hue = (2.0 / 3) + delG - delR;
                }

                if (hsv.Hue < 0)
                {
                    hsv.Hue += 1;
                }

                if (hsv.Hue > 1)
                {
                    hsv.Hue -= 1;
                }
            }

            return hsv;
        }
        #endregion

        #region Color Wheel functions
        private void ColorWheel_Paint()
        {
            float Padding = colorWheelBox.ClientRectangle.Width * 3 / 108;
            float Radius = colorWheelBox.ClientRectangle.Width / 2 - Padding;

            RectangleF wheelRect = new RectangleF(Padding, Padding, Radius * 2, Radius * 2);

            #region create wheel
            GraphicsPath wheel_path = new GraphicsPath();
            wheel_path.AddEllipse(wheelRect);
            wheel_path.Flatten();

            float num_pts = wheel_path.PointCount;
            Color[] surround_colors = new Color[wheel_path.PointCount];
            for (float i = 0; i < num_pts; i++)
            {
                Color c = HSVtoRGB(255, i / num_pts, 1, 1);
                surround_colors[(int)i] = c;
            }
            #endregion
            if (wheelBmp == null)
                wheelBmp = new Bitmap(colorWheelBox.ClientRectangle.Width, colorWheelBox.ClientRectangle.Width);
            using (Graphics g = Graphics.FromImage(wheelBmp))
            {
                g.Clear(Color.Transparent);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (PathGradientBrush path_brush = new PathGradientBrush(wheel_path))
                {
                    path_brush.CenterColor = Color.White;
                    path_brush.SurroundColors = surround_colors;

                    g.FillPath(path_brush, wheel_path);
                    using (Pen thick_pen = new Pen(this.BackColor, 2.0f))
                    {
                        g.DrawPath(thick_pen, wheel_path);
                    }
                }

                //set _hue and sat marker
                double hlfht = Radius + Padding;
                double radius = MasterSat * (hlfht - 1 - Padding);

                PointF _huePoint = new PointF();
                _huePoint.X = (float)(hlfht + radius * Math.Cos(MasterHue * Math.PI / .5) - Padding);
                _huePoint.Y = (float)(hlfht + radius * Math.Sin(MasterHue * Math.PI / .5) - Padding);
                SizeF _hueSize = new SizeF(Padding * 2, Padding * 2);
                RectangleF _hueMark = new RectangleF(_huePoint, _hueSize);
                using (SolidBrush markBrush = new SolidBrush(HSVtoRGB(MasterAlpha, MasterHue, MasterSat, 1)))
                    g.FillEllipse(markBrush, _hueMark);

                using (Pen markPen = new Pen(Color.White))
                {
                    g.DrawEllipse(markPen, _hueMark.X + 1, _hueMark.Y + 1, _hueMark.Width - 2, _hueMark.Height - 2);
                    markPen.Color = Color.Black;
                    g.DrawEllipse(markPen, _hueMark);
                }
            }

        }

        private void ColorWheel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            ColorWheel_MouseMove(sender, e);
        }

        private void ColorWheel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown) return;

            float Padding = colorWheelBox.ClientRectangle.Width * 3 / 100;
            float Radius = colorWheelBox.ClientRectangle.Width / 2 - Padding;

            float hlfht = Radius + Padding;
            double offset;
            offset = Math.Sqrt((e.Y - hlfht) * (e.Y - hlfht) + (e.X - hlfht) * (e.X - hlfht)) / (double)hlfht;


            double rad = Math.Atan2(e.Y - hlfht, e.X - hlfht) * .5 / Math.PI;
            MasterHue = (rad < 0) ? rad + 1 : rad;
            MasterSat = (offset > 1) ? 1 : offset;
            MasterVal = 1;

            Color _colorval = HSVtoRGB(MasterAlpha, MasterHue, MasterSat, MasterVal);
            UpdateColorSliders();
            setColors();
            OnValueChanged(_colorval);
            colorWheelBox.Refresh();
            swatchBox.Refresh();
        }

        private void ColorWheel_MouseUp(object sender, MouseEventArgs e)
        {
            Color _colorval = HSVtoRGB(MasterAlpha, MasterHue, MasterSat, MasterVal);
            UpdateColorSliders();
            OnValueChanged(_colorval);
            mouseDown = false;
            colorWheelBox.Refresh();
            swatchBox.Refresh();
        }

        private void colorWheel_Paint(object sender, PaintEventArgs e)
        {
            ColorWheel_Paint();
            e.Graphics.DrawImage(wheelBmp, 0, 0);
        }
        #endregion

        #region Swatch Box functions
        private void swatchBox_Paint(object sender, PaintEventArgs e)
        {
            //draw colorsample
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.None;

            Color _colorval = HSVtoRGB(MasterAlpha, MasterHue, MasterSat, MasterVal);
            Rectangle SwatchRect = e.ClipRectangle;
            SwatchRect.Width -= 1;
            SwatchRect.Height -= 1;

            using (SolidBrush SB = new SolidBrush(_colorval))
            using (HatchBrush hb = new HatchBrush(HatchStyle.LargeCheckerBoard, Color.LightGray, Color.White))
            {
                g.FillRectangle(hb, SwatchRect);
                g.FillRectangle(SB, SwatchRect);
            }
            g.DrawRectangle(Pens.Black, SwatchRect);
            SwatchRect.Width -= 2;
            SwatchRect.Height -= 2;
            SwatchRect.Offset(1, 1);
            g.DrawRectangle(Pens.White, SwatchRect);
        }
        #endregion

        #region ARGB Controls functions
        private void rgb_ValueChanged()
        {
            if (!ignore)
            {
                Color _colorval = Color.FromArgb((int)redBox.Value, (int)greenBox.Value, (int)blueBox.Value);
                MasterHue = RGBtoHSV(_colorval, MasterHue).Hue;
                MasterSat = RGBtoHSV(_colorval, MasterHue).Sat;
                MasterVal = RGBtoHSV(_colorval, MasterHue).Value;
                //MasterAlpha = _colorval.A;

                UpdateColorSliders();

                colorWheelBox.Refresh();
                swatchBox.Refresh();
                OnValueChanged(_colorval);
            }
        }

        private void ARGB_ValueChanged(object sender, EventArgs e)
        {
            rgb_ValueChanged();
        }

        private void ARGB_MouseUp(object sender, MouseEventArgs e)
        {
            rgb_ValueChanged();
        }

        private void ARGB_Leave(object sender, EventArgs e)
        {
            rgb_ValueChanged();
        }
        #endregion

        #region HSV Controls functions
        private void HSV_Sliders_ValueChanged(object sender, float value)
        {
            if (!ignore)
            {
                //MasterHue = hColorSlider.Value / 360f;
                MasterSat = sColorSlider.Value / 100f;
                MasterVal = vColorSlider.Value / 100f;
                //MasterAlpha = (int)aColorSlider.Value;

                setColors();
                UpdateColorSliders();
                colorWheelBox.Refresh();
                swatchBox.Refresh();
                Color _colorval = HSVtoRGB(MasterAlpha, MasterHue, MasterSat, MasterVal);
                OnValueChanged(_colorval);
            }
        }
        #endregion

        #region Update controls with new Values
        private void setColors()
        {
            ignore = true;

            Color _colorval = HSVtoRGB(MasterAlpha, MasterHue, MasterSat, MasterVal);
            redBox.Value = _colorval.R;
            greenBox.Value = _colorval.G;
            blueBox.Value = _colorval.B;

            ignore = false;
        }

        private void UpdateColorSliders()
        {
            ignore = true;

            Color minSaturation = HSVtoRGB(byte.MaxValue, MasterHue, 0, MasterVal);
            Color maxSaturation = HSVtoRGB(byte.MaxValue, MasterHue, 1, MasterVal);
            sColorSlider.Colors = new Color[] { maxSaturation, minSaturation };
            sColorSlider.Value = (float)(MasterSat * 100);

            Color minValue = HSVtoRGB(byte.MaxValue, MasterHue, MasterSat, 0);
            Color maxValue = HSVtoRGB(byte.MaxValue, MasterHue, MasterSat, 1);
            vColorSlider.Colors = new Color[] { maxValue, minValue };
            vColorSlider.Value = (float)(MasterVal * 100);

            ignore = false;
        }
        #endregion
    }

    public class HSVColor
    {
        public double Hue
        {
            get;
            set;
        }
        public double Sat
        {
            get;
            set;
        }
        public double Value
        {
            get;
            set;
        }
    }

    public class ColorSlider : PictureBox
    {
        public float Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
                ValueChanged?.Invoke(this, this.value);
                this.Refresh();
            }
        }
        public int MaxValue
        {
            get
            {
                return this.maxValue;
            }
            set
            {
                this.maxValue = value;
            }
        }
        public Color[] Colors
        {
            get
            {
                return this.colors;
            }
            set
            {
                this.colors = value;
                DrawColors();
            }
        }

        #region Event handler
        public delegate void ValueChangedEventHandler(object sender, float value);
        public event ValueChangedEventHandler ValueChanged;
        #endregion

        float value = 0;
        int maxValue = byte.MaxValue;
        Color[] colors = { Color.White, Color.Black };
        Bitmap markerBmp;
        bool isMouseOver;
        bool isMouseDown;


        public ColorSlider()
        {
            this.Width = 20;
            this.Height = 102;

            this.Paint += ColorSlider_Paint;
            this.MouseEnter += ColorSlider_MouseEnter;
            this.MouseLeave += ColorSlider_MouseLeave;
            this.MouseDown += ColorSlider_MouseDown;
            this.MouseMove += ColorSlider_MouseMove;
            this.MouseUp += ColorSlider_MouseUp;
        }

        private void ColorSlider_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void ColorSlider_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouseDown)
                return;

            float range = this.ClientSize.Height * 0.9216f;
            float offset = this.ClientSize.Height * 0.039f;

            value = e.Y / range * maxValue - offset;
            value = Clamp(value, 0, maxValue);
            value = Math.Abs(value - maxValue);
            this.Refresh();
            ValueChanged?.Invoke(this, this.value);
        }

        private void ColorSlider_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            ColorSlider_MouseMove(sender, e);
        }

        private void ColorSlider_MouseEnter(object sender, System.EventArgs e)
        {
            isMouseOver = true;
            this.Refresh();
        }

        private void ColorSlider_MouseLeave(object sender, System.EventArgs e)
        {
            isMouseOver = false;
            this.Refresh();
        }

        private void ColorSlider_Paint(object sender, PaintEventArgs e)
        {
            DrawMarker();
            e.Graphics.DrawImage(markerBmp, 0, 0);
        }


        private void DrawMarker()
        {
            if (this.markerBmp == null || this.Image.Size != this.ClientSize)
                this.markerBmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);

            using (Graphics g = Graphics.FromImage(this.markerBmp))
            {
                g.CompositingMode = CompositingMode.SourceOver;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.CompositingQuality = CompositingQuality.HighQuality;

                // clear bitmap
                g.Clear(Color.Transparent);

                if (maxValue == 0)
                    maxValue = 1;

                float dpi = g.DpiX / 96f;
                float markPos = Math.Abs(value - maxValue) / maxValue * (g.VisibleClipBounds.Height - (9 * dpi)) + (4 * dpi);

                PointF right  = new PointF(g.VisibleClipBounds.Left + (7f * dpi), markPos);
                PointF bottom = new PointF(g.VisibleClipBounds.Left, markPos - (3.5f * dpi));
                PointF top = new PointF(g.VisibleClipBounds.Left, markPos + (3.5f * dpi));
                PointF[] marker1 = { top, right, bottom };

                PointF left = new PointF(g.VisibleClipBounds.Right - 1 - (7 * dpi), markPos);
                PointF bottom2 = new PointF(g.VisibleClipBounds.Right - 1, markPos - (3.5f * dpi));
                PointF top2 = new PointF(g.VisibleClipBounds.Right - 1, markPos + (3.5f * dpi));
                PointF[] marker2 = { top2, left, bottom2 };

                Color markerColor = Color.Black;
                if (isMouseOver)
                    markerColor = Color.Blue;

                using (SolidBrush markerBrush = new SolidBrush(markerColor))
                using (Pen markerPen = new Pen(this.BackColor, 1))
                {
                    if (isMouseOver)
                    {
                        g.FillPolygon(markerBrush, marker1);
                        g.FillPolygon(markerBrush, marker2);
                        g.DrawPolygon(markerPen, marker1);
                        g.DrawPolygon(markerPen, marker2);
                    }
                    else
                    {
                        g.DrawPolygon(markerPen, marker1);
                        g.DrawPolygon(markerPen, marker2);
                        g.FillPolygon(markerBrush, marker1);
                        g.FillPolygon(markerBrush, marker2);
                    }
                }
            }
        }


        private void DrawColors()
        {
            if (this.Image == null || this.Image.Size != this.ClientSize)
                this.Image = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);

            using (Graphics g = Graphics.FromImage(this.Image))
            {
                g.Clear(Color.Transparent);
                float dpi = g.DpiX / 96f;
                RectangleF colorRect = new RectangleF(g.VisibleClipBounds.X + (4 * dpi), g.VisibleClipBounds.Y + (4 * dpi), g.VisibleClipBounds.Width - (8 * dpi), g.VisibleClipBounds.Height - (8 * dpi));

                using (LinearGradientBrush brush = new LinearGradientBrush(colorRect, colors[0], colors[1], LinearGradientMode.Vertical))
                {
                    g.FillRectangle(brush, colorRect);
                }
            }
        }

        private static float Clamp(float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

    }
}