namespace RainbowSix.Common
{
    public static class UbisoftPublicAPI
    {
        public static Uri Domain = new Uri("https://public-ubiservices.ubi.com");

        public static string Auth = $"/v3/profiles/sessions";

        public static string MarketPlace = $"/v1/profiles/me/uplay/graphql";
    }
}
