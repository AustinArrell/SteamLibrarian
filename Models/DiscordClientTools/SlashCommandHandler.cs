using apiDev.Models.DiscordClient;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiDev.Models{
    class SlashCommandHandler {

        SocketSlashCommand slashCommand { get; set; }
        Utils utils = new Utils();

        public async Task SlashCommandExecuted(SocketSlashCommand command)
        {
            try {
                slashCommand = command;
                await RunCommand();
            } catch (Exception e){
                await slashCommand.FollowupAsync($"{e.Message}");
            }
        }

        private async Task RunCommand(){
            switch (slashCommand.Data.Name)
            {
                case "compare-libraries":
                    await CompareLibraries();
                    break;
            }
        }

        private async Task CompareLibraries(){
            await Respond("Comparing Libraries...");
            CommandCompareLibraries commandCompareLibraries = new CommandCompareLibraries();

            string optionDataFromUser = (string)slashCommand.Data.Options.First().Value;
            List<string> sharedGames = commandCompareLibraries.Compare(optionDataFromUser);

            List<string> messagesToSend = utils.ConvertToMaxCharSafeMessages(sharedGames);
            await SendFollowUpMessages(messagesToSend);
        }

        private async Task Respond(string message){
            await slashCommand.RespondAsync(message);
        }

        private async Task SendFollowUpMessages(List<string> messages){
            foreach (var message in messages) {
                await slashCommand.FollowupAsync(message);
            }
        }
    }
}
