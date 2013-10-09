using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MtgTracker.Models;
using System.Web.Script.Serialization;
using System.IO;
using System.Data.SqlServerCe;
using System.Data;

namespace ClassLibrary1
{
    public class Class1
    {
        static void Main(string[] args)
        {
            SqlCeConnection connection = new SqlCeConnection("data source=D:\\Git\\MTGCardTracker\\Data\\MyDatabase#1.sdf");
            connection.Open();
            string setSQL = "INSERT INTO SETS(Name, Code, ReleaseDate, Border, Type, Block) VALUES ('{1}', '{2}', @ReleaseDate, '{3}', '{4}', '{5}')";
            string cardSQL = "INSERT INTO CARD(Name, CMC, Rarity, Text, Flavor, Layout, MultiverseID, Printing, Names, ManaCost, Colours, SuperTypes, Types, SubTypes, Artist, Number, Power, Toughness, Loyalty, Variations, imageName, watermark, border, rulings, foreignNames, printings) VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}')";
            int cardID = 0;
            int setID = 0;
            var jsd = new JavaScriptSerializer();
            string[] files = Directory.GetFiles("D:\\Git\\mtgjson\\json", "*.json", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                setID++;
                string json = new StreamReader(file).ReadToEnd();
                Set set = jsd.Deserialize<Set>(json);
                SqlCeParameter param = new SqlCeParameter("@ReleaseDate", SqlDbType.DateTime, 32, "ReleaseDate");
                param.Value = set.releaseDate;
                SqlCeCommand setCommand = new SqlCeCommand(String.Format(setSQL, setID, set.name, set.code, set.border, set.type, set.block));
                setCommand.Parameters.Add(param);
                setCommand.Connection = connection;
                setCommand.ExecuteNonQuery();
                foreach (Card card in set.cards)
                {
                    cardID++;
                    
                    SqlCeCommand cardCommand = new SqlCeCommand(String.Format(cardSQL,
                        cardID, card.name.Replace("'", @"\'"), card.cmc, card.rarity, card.text != null ? card.text.Replace("'", @"\'") : null, card.flavor != null ? card.flavor.Replace("'", @"\'") : null, card.layout, card.multiverseid, card.printings, card.names, card.manaCost, card.colors, card.supertypes, card.types, card.subtypes, card.artist, card.number, card.power, card.toughness, card.loyalty, card.variations, card.imageName, card.watermark != null ? card.watermark.Replace("'", @"\'") : null, card.border, "", "", ""));
                    
                    cardCommand.Connection = connection;
                    cardCommand.ExecuteNonQuery();
                }
            }
            connection.Close();
        }
    }
}
