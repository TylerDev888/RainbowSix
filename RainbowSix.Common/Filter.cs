using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RainbowSix.Common
{
    public class Filter
    {
        public List<string> Types { get; set; } = new();
        public List<List<string>> Tags { get; set; } = new()
        {
            new List<string>(), // 0 = Rarity
            new List<string>(), // 1 = Season
            new List<string>(), // 2 = Operator
            new List<string>(), // 3 = Weapon
            new List<string>(), // 4 = Event
            new List<string>(), // 5 = Esports
            new List<string>()  // 6 = Other
        };
    }

    //public class Program
    //{
    //    public static void Main()
    //    {
    //        var filter = new Filter
    //        {
    //            Types = new List<string>
    //        {
    //            FilterType.WeaponSkin.ToApiValue(),
    //            FilterType.Pack.ToApiValue()
    //        },
    //            Tags = new List<List<string>>
    //        {
    //            new List<string> { FilterRarity.Legendary.ToApiValue() },  // rarity
    //            new List<string> { FilterSeason.Y10S3.ToApiValue() },      // season
    //            new List<string> { FilterOperator.ACE.ToApiValue() },      // operator
    //            new List<string> { FilterWeapon.USG_45.ToApiValue() },     // weapon
    //            new List<string> { FilterEvent.Beret.ToApiValue() },       // event
    //            new List<string> { FilterEsports._00Nation.ToApiValue() }, // esports
    //            new List<string> { FilterOther.BattlePass.ToApiValue() }   // other
    //        }
    //        };

    //        string json = JsonSerializer.Serialize(filter, new JsonSerializerOptions { WriteIndented = true });
    //        Console.WriteLine(json);
    //    }
    //}
}
