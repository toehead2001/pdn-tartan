using PaintDotNet;
using PaintDotNet.Effects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace TartanEffect
{
    public class PluginSupportInfo : IPluginSupportInfo
    {
        public string Author
        {
            get
            {
                return ((AssemblyCopyrightAttribute)base.GetType().Assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0]).Copyright;
            }
        }
        public string Copyright
        {
            get
            {
                return ((AssemblyDescriptionAttribute)base.GetType().Assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0]).Description;
            }
        }

        public string DisplayName
        {
            get
            {
                return ((AssemblyProductAttribute)base.GetType().Assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0]).Product;
            }
        }

        public Version Version
        {
            get
            {
                return base.GetType().Assembly.GetName().Version;
            }
        }

        public Uri WebsiteUri
        {
            get
            {
                return new Uri("http://www.getpaint.net/redirect/plugins.html");
            }
        }
    }

    [PluginSupportInfo(typeof(PluginSupportInfo), DisplayName = "Tartan")]

    internal class TartanEffectPlugin : Effect<TartanConfigToken>
    {
        public static string StaticName
        {
            get
            {
                return "Tartan";
            }
        }

        public static Bitmap StaticIcon
        {
            get
            {
                return new Bitmap(typeof(TartanEffectPlugin), "Tartan.png");
            }
        }

        public static string SubmenuName
        {
            get
            {
                return SubmenuNames.Render;
            }
        }

        public TartanEffectPlugin()
            : base(StaticName, StaticIcon, SubmenuName, EffectFlags.Configurable)
        {
        }

        public override EffectConfigDialog CreateConfigDialog()
        {
            return new TartanConfigDialog();
        }

        protected override void OnSetRenderInfo(TartanConfigToken newToken, RenderArgs dstArgs, RenderArgs srcArgs)
        {
            backColor = newToken.BackColor;
            oneSet = newToken.OneSet;
            horLines = newToken.HorLines;
            verLines = oneSet ? newToken.HorLines : newToken.VerLines;

            Rectangle selection = EnvironmentParameters.GetSelection(srcArgs.Surface.Bounds).GetBoundsInt();

            Bitmap tartanBitmap = new Bitmap(selection.Width, selection.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(tartanBitmap);

            // Fill with white
            Rectangle backgroundRect = new Rectangle(0, 0, selection.Width, selection.Height);
            g.FillRectangle(new SolidBrush(backColor), backgroundRect);

            Brush brush;
            Pen pen;

            int xGroupWide = 0;
            foreach (Item lineItem in horLines)
            {
                xGroupWide += lineItem.Width + lineItem.Spacing;
            }

            int yGroupWide = 0;
            foreach (Item lineItem in verLines)
            {
                yGroupWide += lineItem.Width + lineItem.Spacing;
            }

            int xLoops = (int)Math.Ceiling((double)selection.Height / xGroupWide);
            int yLoops = (int)Math.Ceiling((double)selection.Width / yGroupWide);

            int h = 0;
            for (int i = 0; i < xLoops; i++)
            {
                foreach (Item lineItem in horLines)
                {
                    switch (lineItem.Style)
                    {
                        case 0:
                            brush = new SolidBrush(lineItem.Color);
                            break;
                        case 1:
                            brush = new SolidBrush(Color.FromArgb(170, lineItem.Color));
                            break;
                        case 2:
                            brush = new SolidBrush(Color.FromArgb(85, lineItem.Color));
                            break;
                        case 3:
                            brush = new HatchBrush(HatchStyle.DarkUpwardDiagonal, lineItem.Color, Color.Transparent);
                            break;
                        case 4:
                            brush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, lineItem.Color, Color.Transparent);
                            break;
                        case 5:
                            brush = new HatchBrush(HatchStyle.Percent50, lineItem.Color, Color.Transparent);
                            break;
                        default:
                            brush = new SolidBrush(lineItem.Color);
                            break;
                    }

                    pen = new Pen(brush, lineItem.Width);

                    // Create points that define line.
                    Point pointA = new Point(0, lineItem.Width / 2 + h);
                    Point pointB = new Point(selection.Width, lineItem.Width / 2 + h);

                    // Draw line to screen.
                    g.DrawLine(pen, pointA, pointB);

                    h += lineItem.Width + lineItem.Spacing;
                }
            }

            int v = 0;
            for (int i = 0; i < yLoops; i++)
            {
                foreach (Item lineItem in verLines)
                {
                    switch (lineItem.Style)
                    {
                        case 0:
                            brush = new SolidBrush(lineItem.Color);
                            break;
                        case 1:
                            brush = new SolidBrush(Color.FromArgb(170, lineItem.Color));
                            break;
                        case 2:
                            brush = new SolidBrush(Color.FromArgb(85, lineItem.Color));
                            break;
                        case 3:
                            brush = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.Transparent, lineItem.Color);
                            break;
                        case 4:
                            brush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.Transparent, lineItem.Color);
                            break;
                        case 5:
                            brush = new HatchBrush(HatchStyle.Percent50, Color.Transparent, lineItem.Color);
                            break;
                        default:
                            brush = new SolidBrush(lineItem.Color);
                            break;
                    }

                    pen = new Pen(brush, lineItem.Width);

                    // Create points that define line.
                    Point pointA = new Point(lineItem.Width / 2 + v, 0);
                    Point pointB = new Point(lineItem.Width / 2 + v, selection.Height);

                    // Draw line to screen.
                    g.DrawLine(pen, pointA, pointB);

                    v += lineItem.Width + lineItem.Spacing;
                }
            }

            tartanSurface = Surface.CopyFromBitmap(tartanBitmap);
            tartanBitmap.Dispose();
        }

        protected override void OnRender(Rectangle[] rois, int startIndex, int length)
        {
            if (length == 0) return;
            for (int i = startIndex; i < startIndex + length; ++i)
            {
                Render(DstArgs.Surface, SrcArgs.Surface, rois[i]);
            }
        }

        List<Item> horLines;
        List<Item> verLines;
        bool oneSet;
        Color backColor;

        private Surface tartanSurface;

        void Render(Surface dst, Surface src, Rectangle rect)
        {
            Rectangle selection = EnvironmentParameters.GetSelection(src.Bounds).GetBoundsInt();

            for (int y = rect.Top; y < rect.Bottom; y++)
            {
                if (IsCancelRequested) return;
                for (int x = rect.Left; x < rect.Right; x++)
                {
                    dst[x, y] = tartanSurface.GetBilinearSample(x - selection.Left, y - selection.Top);
                }
            }
        }
    }
}