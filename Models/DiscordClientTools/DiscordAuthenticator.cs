using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiDev.Models.APITools{
    class DiscordAuthenticator{
        public async Task Authenticate(DiscordSocketClient socketClient) {
            string apiKey = GetAPIKeyFromTxtFile(@"G:\API Keys\discordAPI.txt");
            await socketClient.LoginAsync(TokenType.Bot, apiKey);
        }
        private string GetAPIKeyFromTxtFile(string filepath){
            return System.IO.File.ReadAllText(filepath);
        }
    }
}
