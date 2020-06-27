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
        private Surface tartanSurface;
        private static readonly Bitmap StaticIcon = new Bitmap(typeof(TartanEffectPlugin), "Tartan.png");

        public TartanEffectPlugin()
            : base("Tartan", StaticIcon, "Texture", new EffectOptions() { Flags = EffectFlags.Configurable })
        {
        }

        public override EffectConfigDialog CreateConfigDialog()
        {
            return new TartanConfigDialog();
        }

        protected override void OnSetRenderInfo(TartanConfigToken newToken, RenderArgs dstArgs, RenderArgs srcArgs)
        {
            Color backColor = newToken.BackColor;
            IReadOnlyCollection<Item> horLines = newToken.HorLines;
            IReadOnlyCollection<Item> verLines = newToken.OneSet ? newToken.HorLines : newToken.VerLines;

            Rectangle selection = EnvironmentParameters.SelectionBounds;

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

                if (horLines.Count > 0)
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

                if (verLines.Count > 0)
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

            DstArgs.Surface.CopySurface(tartanSurface, renderRects, startIndex, length);
        }

        private static Pen GetItemPen(LineStyle style, Color color, int width, bool isVertical)
        {
            Color color1 = isVertical ? Color.Transparent : color;
            Color color2 = isVertical ? color : Color.Transparent;

            Brush itemBrush;
            switch (style)
            {
                case LineStyle.Solid100:
                    itemBrush = new SolidBrush(color);
                    break;
                case LineStyle.Solid66:
                    itemBrush = new SolidBrush(Color.FromArgb(170, color));
                    break;
                case LineStyle.Solid33:
                    itemBrush = new SolidBrush(Color.FromArgb(85, color));
                    break;
                case LineStyle.DiagonalUp:
                    itemBrush = new HatchBrush(HatchStyle.DarkUpwardDiagonal, color1, color2);
                    break;
                case LineStyle.DiagonalDown:
                    itemBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, color1, color2);
                    break;
                case LineStyle.Dots:
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
