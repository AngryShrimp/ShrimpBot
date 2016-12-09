using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace ShrimpBot
{
    class MyBot
    {
        DiscordClient discord;
        CommandService command;

        public MyBot()
        {
            //Make a new client, get any errors and send the to Log
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            //Create our command service! 
            command = discord.GetService<CommandService>();

            /*  
             *  >>>>>>>>>>>>>>>>
             *  COMMANDS GO HERE
             *  <<<<<<<<<<<<<<<<
             */

            RegisterBlameShrimpCommand();
            RegisterEverythingIsFineCommand();

            //Execute
            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjU2NjU2MTIzMjUwMDgxNzky.CyvZfw.4mEAARWZTZVy9EfrLIBqHg5bFM0", TokenType.Bot);
            });
        }

        private void RegisterBlameShrimpCommand()
        {
            command.CreateCommand("blameShrimp")
                .Do(async (e) => 
                {
                    await e.Channel.SendMessage(":regional_indicator_b: " +
                                                ":regional_indicator_l: " +
                                                ":regional_indicator_a: " +
                                                ":regional_indicator_m: " +
                                                ":regional_indicator_e: " +
                                                ":regional_indicator_s: " +
                                                ":regional_indicator_h: " +
                                                ":regional_indicator_r: " +
                                                ":regional_indicator_i: " +
                                                ":regional_indicator_m: " +
                                                ":regional_indicator_p: ");
                });
        }

        private void RegisterEverythingIsFineCommand()
        {
            command.CreateCommand("everythingisfine")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("images/everythingIsFine.png");
                });
        }

        //Log handler
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
