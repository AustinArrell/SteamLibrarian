using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiDev.Models
{
    class SteamAPI
    {

        SteamAPICallURLs steamAPICallURLs = new SteamAPICallURLs();
        WebRequestHandler webRequestHandler = new WebRequestHandler();
        JsonParser jsonParser = new JsonParser();
        JObject response;
        string requestUrl { get; set; }

        public dynamic GetSupportedApiList() 
        {
            requestUrl = steamAPICallURLs.GetSupportedApiList();
            ProcessRequest();
            return response["apilist"];
        }

        public dynamic GetAppDetails(string appId)
        {
            requestUrl = steamAPICallURLs.GetAppDetails(appId);
            ProcessRequest();
            if (checkCallValidity(appId))
                return response[appId]["data"];
            
            return "";
        }

        public string GetSteamIDFromVanityURL(string vanityURL){
            requestUrl = steamAPICallURLs.GetSteamIDFromVanityURL(vanityURL);
            ProcessRequest();

            if ((int)response["response"]["success"] == 42)
                throw (new Exception($"Vanity URL Error: {vanityURL}"));

            return (string)response["response"]["steamid"];
        }

        public dynamic GetFriendList(string steamID){
            requestUrl = steamAPICallURLs.GetFriendList(steamID);
            ProcessRequest();
            return response["friendslist"]["friends"];
        }

        public dynamic GetPlayerSummary(string steamID){
            requestUrl = steamAPICallURLs.GetPlayerSummary(steamID);
            ProcessRequest();
            return response["response"]["players"];
        }

        public List<string> GetOwnedGameNames(string steamID){ 
            List<string> games = new List<string>();
            dynamic gamesList = GetOwnedGames(steamID);
            foreach (dynamic game in gamesList){
                games.Add((string)game["name"]);
            }
            return games;
        }
        
        public dynamic GetOwnedGames(string steamID)
        {
            requestUrl = steamAPICallURLs.GetOwnedGames(steamID);
            ProcessRequest();
            if (response["response"].HasValues)
                return response["response"]["games"];
            else
                throw (new Exception($"No Games Found For User: {steamID}"));
            
        }

        void ProcessRequest(){
            try
            {
                string webResponse = webRequestHandler.GetWebRequestResponse(requestUrl);
                jsonParser.DeserializeString(webResponse);
                response = jsonParser.deserializedJson;
            }
            catch (Exception e) {
                throw (new Exception(e.Message));
            }
        }

        bool checkCallValidity(string topLevelJsonField){
            return (string)response[topLevelJsonField]["success"] == "True";
        }

    }
}
