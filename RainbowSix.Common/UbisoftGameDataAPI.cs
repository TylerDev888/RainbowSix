namespace RainbowSix.Common
{
    public static class UbisoftGameDataAPI
    {
        public static Uri Domain = new Uri("https://prod.datadev.ubisoft.com");
        public static string AccountStats(string userId) 
            => $"/v1/users/{userId}/playerstats";
        
        public static string LevelData(string userId) 
            => $"/v1/spaces/{UbisoftVariables.SpaceId}/title/r6s/rewards/public_profile?profile_id={userId}";
    }
}
