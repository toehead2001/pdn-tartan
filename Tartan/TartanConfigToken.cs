using PaintDotNet.Effects;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;

namespace TartanEffect
{
    public class TartanConfigToken : EffectConfigToken
    {
        private List<Item> t_horLines;
        private List<Item> t_verLines;
        bool t_oneSet;
        Color t_backColor;

        /// <summary>
        /// Initializes the configuration token with empty dictionaries
        /// </summary>
        public TartanConfigToken() : base()
        {
            t_horLines = new List<Item>();
            t_verLines = new List<Item>();
            t_oneSet = true;
            t_backColor = Color.White;
        }

        private TartanConfigToken(List<Item> horLines, List<Item> verLines, bool oneSet, Color backColor)
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

        public List<Item> HorLines
        {
            get
            {
                return t_horLines;
            }
        }
        public List<Item> VerLines
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
        [XmlIgnore]
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
        [XmlElement("BackColor")]
        public string ClrGridHtml
        {
            get { return ColorTranslator.ToHtml(BackColor); }
            set { BackColor = ColorTranslator.FromHtml(value); }
        }
    }
}
