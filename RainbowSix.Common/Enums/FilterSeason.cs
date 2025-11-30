namespace RainbowSix.Common.Enums
{
    public enum FilterSeason
    {
        Y10S3,
        Y10S2,
        Y10S1,
        Y9S4
        // TODO: add remaining 40
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
