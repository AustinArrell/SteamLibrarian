using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiDev.Models.APITools{
    class DiscordCommands{
        SlashCommandCreator commandCreator = new SlashCommandCreator();

        public async Task LoadIntoClient(DiscordSocketClient socketClient) {
            CompareLibraries();
            await commandCreator.LoadCommandIntoClient(socketClient);

            CompareLibrariesVoice();
            await commandCreator.LoadCommandIntoClient(socketClient);
        }
        
        private void CompareLibraries() {
            commandCreator.CreateSlashCommand("compare-libraries", "Compare your Steam Library using vanity URLs or steamIDs");
            commandCreator.AddOption("users", ApplicationCommandOptionType.String, "Comma separated list of steamIDs or VanityUrls to compare", true);
            commandCreator.AddOption("genre", ApplicationCommandOptionType.String, "Comma separated list of genres", false);
        }

        private void CompareLibrariesVoice() {
            string name = "compare-libraries-voice";
            string description = "Compare your Steam Library with users that have linked steam accounts in your current voice channel";
            commandCreator.CreateSlashCommand(name, description);
        }

    }
}
