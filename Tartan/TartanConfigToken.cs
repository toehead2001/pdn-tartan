using PaintDotNet.Effects;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;

namespace TartanEffect
{
    public class TartanConfigToken : EffectConfigToken
    {
        private List<Item> horLines = new List<Item>();
        private List<Item> verLines = new List<Item>();
        bool oneSet = true;
        Color backColor = Color.White;

        public TartanConfigToken() : base()
        {
            this.HorLines = horLines;
            this.VerLines = verLines;
            this.OneSet = oneSet;
            this.BackColor = backColor;
        }

        private TartanConfigToken(TartanConfigToken copyMe)
        {
            this.HorLines = copyMe.HorLines;
            this.VerLines = copyMe.VerLines;
            this.OneSet = copyMe.OneSet;
            this.BackColor = copyMe.BackColor;
        }

        public override object Clone()
        {
            return new TartanConfigToken(this);
        }

        public List<Item> HorLines
        {
            get;
            set;
        }
        public List<Item> VerLines
        {
            get;
            set;
        }
        public bool OneSet
        {
            get;
            set;
        }
        [XmlIgnore]
        public Color BackColor
        {
            get;
            set;
        }        
        [XmlElement("BackColor")]
        public string ClrGridHtml
        {
            get { return ColorTranslator.ToHtml(BackColor); }
            set { BackColor = ColorTranslator.FromHtml(value); }
        }
    }
}
