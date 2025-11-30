using RainbowSix.Common.Enums;

namespace RainbowSix.Common
{
    public static class FilterEnumExtensions
    {
        public static string ToApiValue(this FilterType type) => type switch
        {
            FilterType.WeaponSkin => "WeaponSkin",
            FilterType.Headgear => "Headgear",
            FilterType.Uniform => "Uniform",
            FilterType.AttachmentSkin => "AttachmentSkin",
            FilterType.Charm => "Charm",
            FilterType.OperatorPortrait => "OperatorPortrait",
            FilterType.CardBackground => "CardBackground",
            FilterType.DroneSkin => "DroneSkin",
            FilterType.GadgetSkin => "GadgetSkin",
            FilterType.Pack => "Pack",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };

        public static string ToApiValue(this FilterRarity rarity) => rarity switch
        {
            FilterRarity.Common => "rarity_common",
            FilterRarity.Uncommon => "rarity_uncommon",
            FilterRarity.Rare => "rarity_rare",
            FilterRarity.Epic => "rarity_epic",
            FilterRarity.Legendary => "rarity_legendary",
            _ => throw new ArgumentOutOfRangeException(nameof(rarity), rarity, null)
        };

        public static string ToApiValue(this FilterSeason season) => season.ToString();

        public static string ToApiValue(this FilterOperator op)
        {
            string opName = op.ToString().ToUpper(); // Convert enum name to API format

            string season = op switch
            {
                FilterOperator.Frost or FilterOperator.Buck => "Y1S1",
                FilterOperator.Valkyrie or FilterOperator.Blackbeard => "Y1S2",
                FilterOperator.Caveira or FilterOperator.Capitao => "Y1S3",
                FilterOperator.Echo or FilterOperator.Hibana => "Y1S4",
                FilterOperator.Mira or FilterOperator.Jackal => "Y2S1",
                FilterOperator.Lesion or FilterOperator.Ying or FilterOperator.Ela => "Y2S3",
                FilterOperator.Vigil or FilterOperator.Dokkaebi or FilterOperator.Zofia => "Y2S4",
                FilterOperator.Finka or FilterOperator.Lion => "Y3S1",
                FilterOperator.Maestro or FilterOperator.Alibi => "Y3S2",
                FilterOperator.Clash or FilterOperator.Maverick => "Y3S3",
                FilterOperator.Kaid or FilterOperator.Nomad => "Y3S4",
                FilterOperator.Mozzie or FilterOperator.Gridlock => "Y4S1",
                FilterOperator.Warden or FilterOperator.Nokk => "Y4S2",
                FilterOperator.Goyo or FilterOperator.Amaru => "Y4S3",
                FilterOperator.Wamai or FilterOperator.Kali => "Y4S4",
                FilterOperator.Oryx or FilterOperator.Iana => "Y5S1",
                FilterOperator.Melusi or FilterOperator.Ace => "Y5S2",
                FilterOperator.Zero => "Y5S3",
                FilterOperator.Aruni => "Y5S4",
                FilterOperator.Flores => "Y6S1",
                FilterOperator.Thunderbird => "Y6S2",
                FilterOperator.Osa => "Y6S3",
                FilterOperator.Thorn => "Y6S4",
                FilterOperator.Azami => "Y7S1",
                FilterOperator.Sens => "Y7S2",
                FilterOperator.Grim => "Y7S3",
                FilterOperator.Solis => "Y7S4",
                FilterOperator.Brava => "Y8S1",
                FilterOperator.Fenrir => "Y8S2",
                FilterOperator.Ram => "Y8S3",
                FilterOperator.Tubarao => "Y8S4",
                FilterOperator.Deimos => "Y9S1",
                FilterOperator.Striker or FilterOperator.Sentry => "Y9S2",
                FilterOperator.Skopos => "Y9S3",
                FilterOperator.Rauora => "Y10S1",
                FilterOperator.Denari => "Y10S3",
                _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
            };

            return $"Character.{season}.{opName}";
        }

        public static string ToApiValue(this FilterWeapon weapon) => weapon switch
        {
            FilterWeapon.USG_45 => "57_USG",
            FilterWeapon.AK12 => "ak12",
            FilterWeapon.M4 => "m4",
            FilterWeapon.MP5 => "mp5",
            FilterWeapon.M590A1 => "m590a1",
            _ => throw new ArgumentOutOfRangeException(nameof(weapon), weapon, null)
        };

        public static string ToApiValue(this FilterEvent ev) => ev.ToString().ToLower();

        public static string ToApiValue(this FilterEsports team) => team switch
        {
            FilterEsports._00Nation => "00_NATION",
            FilterEsports.G2Esports => "G2",
            FilterEsports.FaZeClan => "FAZE",
            FilterEsports.TeamLiquid => "LIQUID",
            FilterEsports.NinjasInPyjamas => "NIP",
            FilterEsports.DarkZeroEsports => "DZ",
            _ => throw new ArgumentOutOfRangeException(nameof(team), team, null)
        };

        public static string ToApiValue(this FilterOther other) => other switch
        {
            FilterOther.BattlePass => "acq_battlepass",
            FilterOther.AlphaPack => "alpha_pack",
            FilterOther.UbisoftConnect => "ubi_connect",
            _ => throw new ArgumentOutOfRangeException(nameof(other), other, null)
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
