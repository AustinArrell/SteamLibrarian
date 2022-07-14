using apiDev.Models.APITools;
using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiDev.Models.DiscordClientTools{
    class DiscordClient{
        
        DiscordSocketClient socketClient = new DiscordSocketClient();
        SlashCommandHandler commandHandler = new SlashCommandHandler();

        public DiscordClient(){
            DelegateEvents();
        }

        private void DelegateEvents() {
            socketClient.Log += DiscordLogger.Log;
            socketClient.Ready += ClientReady;
            socketClient.SlashCommandExecuted += commandHandler.SlashCommandExecuted;
        }

        private async Task ClientReady(){
            DiscordCommands commands = new DiscordCommands();
            await commands.LoadIntoClient(socketClient);
        }

        public async Task ClearAllCommands(){
            ApplicationCommandProperties[] applicationCommandProperties = new ApplicationCommandProperties[0];
            await socketClient.BulkOverwriteGlobalApplicationCommandsAsync(applicationCommandProperties);
        }

        public async Task AuthenticateClient(){
            DiscordAuthenticator authenticator = new DiscordAuthenticator();
            await authenticator.Authenticate(socketClient);
        }

        public async Task StartClient() {
            await socketClient.StartAsync();
        }

    }
}
