using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MtgTracker.Models
{
    public class Set
    {
        public int setID { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public DateTime releaseDate { get; set; }
        public string border { get; set; }
        public string type { get; set; }
        public string block { get; set; }
        public List<Card> cards { get; set; }
    }

    public class Printing
    {
        public int printingID { get; set; }
        public int setID { get; set; }
        public string cardID { get; set; }
        public string artist { get; set; }
    }

    public class Card
    {
        public int cardID { get; set; }
        public string layout { get; set; }
        public string name { get; set; }
        public string[] names { get; set; }
        public string manaCost { get; set; }
        public decimal cmc { get; set; }
        public List<Colours> colors { get; set; }
        public string[] supertypes { get; set; }
        public string[] types { get; set; }
        public string[] subtypes { get; set; }
        public string rarity { get; set; }
        public string text { get; set; }
        public string flavor { get; set; }
        public string artist { get; set; }
        public string number { get; set; }
        public string power { get; set; }
        public string toughness { get; set; }
        public string loyalty { get; set; }
        public string multiverseid { get; set; }
        public string[] variations { get; set; }
        public string imageName { get; set; }
        public string watermark { get; set; }
        public string border { get; set; }
        public List<Rulings> rulings { get; set; }
        public List<ForeignNames> foreignNames { get; set; }
        public string[] printings { get; set; }
    }

    public class Rulings
    {
        public DateTime date { get; set; }
        public string text { get; set; }
    }

    public class ForeignNames
    {
        public string language { get; set; }
        public string name { get; set; }
    }

    public enum Colours
    {
        White,
        Blue,
        Black,
        Red,
        Green,
        Colorless
    }
}