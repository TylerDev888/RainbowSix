namespace RainbowSix.Common.Enums
{
    public enum FilterOperator
    {
        // Year 1
        Frost,
        Buck,
        Valkyrie,
        Blackbeard,
        Caveira,
        Capitao,
        Echo,
        Hibana,

        // Year 2
        Mira,
        Jackal,
        Lesion,
        Ying,
        Ela,
        Vigil,
        Dokkaebi,
        Zofia,

        // Year 3
        Finka,
        Lion,
        Maestro,
        Alibi,
        Clash,
        Maverick,
        Kaid,
        Nomad,

        // Year 4
        Mozzie,
        Gridlock,
        Warden,
        Nokk,
        Goyo,
        Amaru,
        Wamai,
        Kali,

        // Year 5
        Oryx,
        Iana,
        Melusi,
        Ace,
        Zero,
        Aruni,

        // Year 6
        Flores,
        Thunderbird,
        Osa,
        Thorn,

        // Year 7
        Azami,
        Sens,
        Grim,
        Solis,

        // Year 8
        Brava,
        Fenrir,
        Ram,
        Tubarao,

        // Year 9
        Deimos,
        Striker,
        Sentry,
        Skopos,

        // Year 10
        Rauora,
        Denari
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
