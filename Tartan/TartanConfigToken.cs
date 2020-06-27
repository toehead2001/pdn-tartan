using PaintDotNet.Effects;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;

namespace TartanEffect
{
    public class TartanConfigToken : EffectConfigToken
    {
        internal TartanConfigToken()
        {
            this.HorLines = new List<Item>();
            this.VerLines = new List<Item>();
            this.OneSet = true;
            this.BackColor = Color.White;
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

        public List<Item> HorLines { get; set; }
        public List<Item> VerLines { get; set; }
        public bool OneSet { get; set; }
        [XmlIgnore]
        public Color BackColor { get; set; }
        [XmlElement(nameof(BackColor))]
        public string BackColorHtml
        {
            get => ColorTranslator.ToHtml(BackColor);
            set => BackColor = ColorTranslator.FromHtml(value);
        }
    }
}
