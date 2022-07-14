using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiDev.Models
{
    class SteamAPICallURLs{
        protected string apiKey { get; set; }

        public SteamAPICallURLs(){
            apiKey = GetAPIKeyFromTxtFile(@"G:\API Keys\steamAPI.txt");
        }

        public string GetAPIKeyFromTxtFile(string filepath)
        {
            return System.IO.File.ReadAllText(filepath);
        }

        public string GetSteamIDFromVanityURL(string vanityUrl){
            return $"http://api.steampowered.com/ISteamUser/ResolveVanityURL/v0001/?key={apiKey}&vanityurl={vanityUrl}";
        }
        
        public string GetFriendList(string SteamID){
            return $"http://api.steampowered.com/ISteamUser/GetFriendList/v0001/?key={apiKey}&steamid={SteamID}&relationship=friend";
        }

        public string GetPlayerSummary(string SteamID){
            return $"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={apiKey}&steamids={SteamID}";
        }

        public string GetOwnedGames(string SteamID){
            return $"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={apiKey}&steamid={SteamID}&format=json&include_appinfo=true";
        }

        public string GetRecentlyPlayedGames(string SteamID){
            return $"http://api.steampowered.com/IPlayerService/GetRecentlyPlayedGames/v0001/?key={apiKey}&steamid={SteamID}";
        }

        public string GetPlayerAchievements(string SteamID, string appID){
            return $"http://api.steampowered.com/ISteamUserStats/GetPlayerAchievements/v0001/?appid={appID}&key={apiKey}&steamid={SteamID}";
        }

        public string GetNewsForApp(string appID){
            return $"http://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid={appID}";
        }

        public string GetGlobalAchievementPercentagesForApp(string appID){
            return $"http://api.steampowered.com/ISteamUserStats/GetGlobalAchievementPercentagesForApp/v0002/?gameid={appID}";
        }

        public string GetSupportedApiList(){
            return $"http://api.steampowered.com/ISteamWebAPIUtil/GetSupportedAPIList/v0001/?key={apiKey}";
        }

        public string GetAppDetails(string appId){
            return $"https://store.steampowered.com/api/appdetails?key={apiKey}&appids={appId}";
        }
    }
}
