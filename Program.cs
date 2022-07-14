using apiDev.Models;
using apiDev.Models.DiscordClientTools;
using Discord;
using Discord.WebSocket;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace apiDev{
    class Program{

        public static Task Main(string[] args) {
            return new Program().MainAsync();
        } 
        
        public async Task MainAsync(){
            DiscordClient discordClient = new DiscordClient();
            
            await discordClient.AuthenticateClient();
            await discordClient.StartClient();

            await Task.Delay(-1);
        }
    }
}
