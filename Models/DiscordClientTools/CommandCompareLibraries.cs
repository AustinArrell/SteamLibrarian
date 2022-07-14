using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiDev.Models.DiscordClient{
    class CommandCompareLibraries{
        SteamAPI steamApi = new SteamAPI();
        Utils utils = new Utils();

        public List<string> Compare(string usersToCompare){
            string[] users = ConvertToCleanArray(usersToCompare);
            List<List<string>> userGameLists = BuildUserGameLists(users);
            List<string> sharedGames = utils.GetSharedStrings(userGameLists);

            if (sharedGames.Count == 0)
                throw (new Exception("No Shared Games Found!"));
            return sharedGames;
        }

        public List<string> Compare(string usersToCompare, string filters){
            List<string> sharedGames = new List<string>();
            Compare(usersToCompare);

            return new List<string>();
        }

        private string[] ConvertToCleanArray(string usersToCompare)
        {
            string usersNoSpaces = usersToCompare.Replace(" ", "");
            return usersNoSpaces.Split(',');
        }

        private List<List<string>> BuildUserGameLists(string[] users){
            List<List<string>> userGameLists = new List<List<string>>();
            foreach (string user in users)
            {
                string userID = ConvertNameIfVanityUrl(user);
                List<string> gameList = steamApi.GetOwnedGameNames(userID);
                gameList.Sort();
                userGameLists.Add(gameList);
            }
            return userGameLists;
        }

        private string ConvertNameIfVanityUrl(string user){
            if (!utils.isNumeric(user))
                return steamApi.GetSteamIDFromVanityURL(user);
            return user;
        }
    }
}
