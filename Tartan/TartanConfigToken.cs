using PaintDotNet.Effects;
using System.Collections.Generic;
using System.Drawing;

namespace TartanEffect
{
    class TartanConfigToken : EffectConfigToken
    {
        private List<TartanConfigDialog.Item> t_horLines;
        private List<TartanConfigDialog.Item> t_verLines;
        bool t_oneSet;
        Color t_backColor;

        /// <summary>
        /// Initializes the configuration token with empty dictionaries
        /// </summary>
        public TartanConfigToken() : base()
        {
            t_horLines = new List<TartanConfigDialog.Item>();
            t_verLines = new List<TartanConfigDialog.Item>();
            t_oneSet = true;
            t_backColor = Color.White;
        }

        private TartanConfigToken(List<TartanConfigDialog.Item> horLines, List<TartanConfigDialog.Item> verLines, bool oneSet, Color backColor)
        {
            t_horLines = horLines;
            t_verLines = verLines;
            t_oneSet = oneSet;
            t_backColor = backColor;
        }

        public override object Clone()
        {
            return new TartanConfigToken(t_horLines, t_verLines, t_oneSet, t_backColor);
        }

        public List<TartanConfigDialog.Item> HorLines
        {
            get
            {
                return t_horLines;
            }
        }
        public List<TartanConfigDialog.Item> VerLines
        {
            get
            {
                return t_verLines;
            }
        }
        public bool OneSet
        {
            get
            {
                return t_oneSet;
            }
            set
            {
                t_oneSet = value;
            }
        }
        public Color BackColor
        {
            get
            {
                return t_backColor;
            }
            set
            {
                t_backColor = value;
            }
        }
    }
}
