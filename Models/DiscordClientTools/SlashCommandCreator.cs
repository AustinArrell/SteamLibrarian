using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiDev.Models.APITools{
    class SlashCommandCreator{
        SlashCommandBuilder commandBuilder = new SlashCommandBuilder();

        public void CreateSlashCommand(string name, string description)
        {
            commandBuilder.WithName(name);
            commandBuilder.WithDescription(description);
        }

        public void AddOption(string optionName, ApplicationCommandOptionType optionType, string description, bool required) {
            commandBuilder.AddOption(optionName, optionType, description, isRequired: required);
        }

        public async Task LoadCommandIntoClient(DiscordSocketClient socketClient) {
            await socketClient.CreateGlobalApplicationCommandAsync(commandBuilder.Build());
        }


    }
}
