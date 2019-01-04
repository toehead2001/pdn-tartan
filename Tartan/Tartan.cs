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
        public string Author => base.GetType().Assembly.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
        public string Copyright => base.GetType().Assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
        public string DisplayName => base.GetType().Assembly.GetCustomAttribute<AssemblyProductAttribute>().Product;
        public Version Version => base.GetType().Assembly.GetName().Version;
        public Uri WebsiteUri => new Uri("https://forums.getpaint.net/index.php?showtopic=32450");
    }

    [PluginSupportInfo(typeof(PluginSupportInfo), DisplayName = "Tartan")]
    internal class TartanEffectPlugin : Effect<TartanConfigToken>
    {
        private Item[] horLines;
        private Item[] verLines;
        private bool oneSet;
        private Color backColor;

        private Surface tartanSurface;

        private static readonly Bitmap StaticIcon = new Bitmap(typeof(TartanEffectPlugin), "Tartan.png");

        public TartanEffectPlugin()
            : base("Tartan", StaticIcon, "Texture", EffectFlags.Configurable)
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
            horLines = newToken.HorLines.ToArray();
            verLines = oneSet ? newToken.HorLines.ToArray() : newToken.VerLines.ToArray();

            Rectangle selection = EnvironmentParameters.GetSelection(srcArgs.Surface.Bounds).GetBoundsInt();

            if (tartanSurface == null)
            {
                tartanSurface = new Surface(SrcArgs.Size);
            }

            using (Graphics tartanGraphics = new RenderArgs(tartanSurface).Graphics)
            {
                // Fill in background color
                using (SolidBrush backBrush = new SolidBrush(backColor))
                {
                    tartanGraphics.FillRectangle(backBrush, selection);
                }

                if (horLines.Length > 0)
                {
                    int yOffset = selection.Top;
                    while (yOffset <= selection.Bottom)
                    {
                        foreach (Item lineItem in horLines)
                        {
                            // Create points that define line.
                            Point pointA = new Point(selection.Left, lineItem.Width / 2 + yOffset);
                            Point pointB = new Point(selection.Right, lineItem.Width / 2 + yOffset);

                            // Draw line to screen.
                            using (Pen lineItemPen = GetItemPen(lineItem.Style, lineItem.Color, lineItem.Width, false))
                            {
                                tartanGraphics.DrawLine(lineItemPen, pointA, pointB);
                            }

                            yOffset += lineItem.Width + lineItem.Spacing;
                        }
                    }
                }

                if (verLines.Length > 0)
                {
                    int xOffset = selection.Left;
                    while (xOffset <= selection.Right)
                    {
                        foreach (Item lineItem in verLines)
                        {
                            // Create points that define line.
                            Point pointA = new Point(lineItem.Width / 2 + xOffset, selection.Top);
                            Point pointB = new Point(lineItem.Width / 2 + xOffset, selection.Bottom);

                            // Draw line to screen.
                            using (Pen lineItemPen = GetItemPen(lineItem.Style, lineItem.Color, lineItem.Width, true))
                            {
                                tartanGraphics.DrawLine(lineItemPen, pointA, pointB);
                            }

                            xOffset += lineItem.Width + lineItem.Spacing;
                        }
                    }
                }
            }

            base.OnSetRenderInfo(newToken, dstArgs, srcArgs);
        }

        protected override void OnRender(Rectangle[] renderRects, int startIndex, int length)
        {
            if (length == 0) return;
            for (int i = startIndex; i < startIndex + length; ++i)
            {
                DstArgs.Surface.CopySurface(tartanSurface, renderRects[i].Location, renderRects[i]);
            }
        }

        private static Pen GetItemPen(int style, Color color, int width, bool isVertical)
        {
            Color color1 = color;
            Color color2 = Color.Transparent;

            if (isVertical)
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
    }
}
