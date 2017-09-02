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
        public string Author => ((AssemblyCopyrightAttribute)base.GetType().Assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0]).Copyright;
        public string Copyright => ((AssemblyDescriptionAttribute)base.GetType().Assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0]).Description;
        public string DisplayName => ((AssemblyProductAttribute)base.GetType().Assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0]).Product;
        public Version Version => base.GetType().Assembly.GetName().Version;
        public Uri WebsiteUri => new Uri("https://forums.getpaint.net/index.php?showtopic=32450");
    }

    [PluginSupportInfo(typeof(PluginSupportInfo), DisplayName = "Tartan")]

    internal class TartanEffectPlugin : Effect<TartanConfigToken>
    {
        private static readonly Bitmap StaticIcon = new Bitmap(typeof(TartanEffectPlugin), "Tartan.png");

        public TartanEffectPlugin()
            : base("Tartan", StaticIcon, SubmenuNames.Render, EffectFlags.Configurable)
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
            Graphics tartanGraphics = Graphics.FromImage(tartanBitmap);

            // Fill in background color
            Rectangle backgroundRect = new Rectangle(0, 0, selection.Width, selection.Height);
            using (SolidBrush backBrush = new SolidBrush(backColor))
                tartanGraphics.FillRectangle(backBrush, backgroundRect);

            int horGroupHeight = 0;
            try
            {
                foreach (Item lineItem in horLines)
                {
                    horGroupHeight += lineItem.Width + lineItem.Spacing;
                }
            }
            catch
            {
            }

            int verGroupWidth = 0;
            try
            {
                foreach (Item lineItem in verLines)
                {
                    verGroupWidth += lineItem.Width + lineItem.Spacing;
                }
            }
            catch
            {
            }

            int xLoops = (int)Math.Ceiling((double)selection.Height / horGroupHeight);
            int yLoops = (int)Math.Ceiling((double)selection.Width / verGroupWidth);

            int yOffset = 0;
            for (int i = 0; i < xLoops; i++)
            {
                try
                {
                    foreach (Item lineItem in horLines)
                    {
                        // Create points that define line.
                        Point pointA = new Point(0, lineItem.Width / 2 + yOffset);
                        Point pointB = new Point(selection.Width, lineItem.Width / 2 + yOffset);

                        // Draw line to screen.
                        using (Pen lineItemPen = getItemPen(lineItem.Style, lineItem.Color, lineItem.Width, 0))
                            tartanGraphics.DrawLine(lineItemPen, pointA, pointB);

                        yOffset += lineItem.Width + lineItem.Spacing;
                    }
                }
                catch
                {
                }
            }

            int xOffset = 0;
            for (int i = 0; i < yLoops; i++)
            {
                try
                {
                    foreach (Item lineItem in verLines)
                    {
                        // Create points that define line.
                        Point pointA = new Point(lineItem.Width / 2 + xOffset, 0);
                        Point pointB = new Point(lineItem.Width / 2 + xOffset, selection.Height);

                        // Draw line to screen.
                        using (Pen lineItemPen = getItemPen(lineItem.Style, lineItem.Color, lineItem.Width, 1))
                            tartanGraphics.DrawLine(lineItemPen, pointA, pointB);

                        xOffset += lineItem.Width + lineItem.Spacing;
                    }
                }
                catch
                {
                }
            }

            tartanSurface = Surface.CopyFromBitmap(tartanBitmap);
            tartanBitmap.Dispose();


            base.OnSetRenderInfo(newToken, dstArgs, srcArgs);
        }

        protected override void OnRender(Rectangle[] renderRects, int startIndex, int length)
        {
            if (length == 0) return;
            for (int i = startIndex; i < startIndex + length; ++i)
            {
                Render(DstArgs.Surface, SrcArgs.Surface, renderRects[i]);
            }
        }

        static Pen getItemPen(int style, Color color, int width, byte orientation)
        {
            Color color1 = color;
            Color color2 = Color.Transparent;

            if (orientation == 1)
            {
                color1 = Color.Transparent;
                color2 = color;
            }

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
                    itemBrush = new HatchBrush(HatchStyle.DarkUpwardDiagonal, color1, color2);
                    break;
                case 4:
                    itemBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, color1, color2);
                    break;
                case 5:
                    itemBrush = new HatchBrush(HatchStyle.Percent50, color1, color2);
                    break;
                default:
                    itemBrush = new SolidBrush(color);
                    break;
            }

            Pen itemPen = new Pen(itemBrush, width);
            itemBrush.Dispose();

            return itemPen;
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