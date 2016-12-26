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
            RegisterBlockifyCommand();
            RegisterChristmasTreeCommand();

            //Execute
            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjU2NjU2MTIzMjUwMDgxNzky.C0C0bA.eJp5Y-9TZrpPn5zIGfAnTHEJgYM", TokenType.Bot);
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

        private void RegisterBlockifyCommand()
        {
            command.CreateCommand("blockify")
                .Parameter("message", ParameterType.Multiple)
                .Do(async (e) =>
                {
                    var message = e.Args;
                    StringBuilder blockifiedMessage = new StringBuilder();


                    foreach(string x in message)
                    {
                        foreach(char c in x)
                        {
                            if (Char.IsLetter(c))
                                blockifiedMessage.Append(":regional_indicator_" + Char.ToLower(c) + ": ");
                            else
                                blockifiedMessage.Append(c);
                        }
                        blockifiedMessage.Append("    ");
                    }

                    await e.Channel.SendMessage(blockifiedMessage.ToString());
                });
        }

        private void RegisterChristmasTreeCommand()
        {
            command.CreateCommand("merryChristmas")
                .Do(async (e) =>
                {
                    String currentDateMonth = System.DateTime.Today.ToString().Split(' ')[0].Split('-')[1] + "-" + System.DateTime.Today.ToString().Split(' ')[0].Split('-')[2];
                    if (currentDateMonth == "12-25")
                    {
                        await e.Channel.SendMessage("```" +
                                                    "           *             ,\n" +
                                                    "                       _/^\\_\n" +
                                                    "                      <     >\n" +
                                                    "     *                 /.-.\\         *\n" +
                                                    "              *        `/&\\`                   *\n" +
                                                    "                      ,@.*;@,\n" +
                                                    "                     /_o.I %_\\    *\n" +
                                                    "        *           (`'--:o(_@;\n" +
                                                    "                   /`;--.,__ `')             *\n" +
                                                    "                  ;@`o % O,*`'`&\\ \n" +
                                                    "            *    (`'--)_@ ;o %'()\\      *\n" +
                                                    "                 /`;--._`''--._O'@;\n" +
                                                    "                /&*,()~o`;-.,_ `\"\"`)\n" +
                                                    "     *          /`,@ ;+& () o*`;-';\\ \n" +
                                                    "               (`\"\"--.,_0 +% @' &()\\ \n" +
                                                    "               /-.,_    ``''--....-'`)  *\n" +
                                                    "          *    /@%;o`:;'--,.__   __.'\\ \n" +
                                                    "              ;*,&(); @ % &^;~`~`o;@(); *\n" +
                                                    "              /(); o^~; & ().o@*&`;&%O\\ \n" +
                                                    "             `' = '==''==,,,.,=' == '==='`\n" +
                                                    "           __.----.----''#####---...___...-----._\n" +
                                                    "         '`             `'''''`" +
                                                    "\n" +
                                                    "```");
                    }
                    else
                        await e.Channel.SendMessage("It aint Christmas, sorry D:");
                });
        }

        //Log handler
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
