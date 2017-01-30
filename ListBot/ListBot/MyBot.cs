using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace ListBot
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        string[] Tatsuya;
        Random tatsrand;

        string[] Fortune;
        string[] FortuneImage;
        string[] FortuneImageSurprised;
        Random fortunetextrand;
        Random fortuneimagerand;
        Random fortuneImageSurprisedRand;

        public MyBot()
        {
            tatsrand = new Random();
            Tatsuya = new string[]
            {"choosing the White ending","being pistol whipped by Goro","letting ya girl eat ya ass","returning the world to nothing","accidentally saving over your 130+ hour NG+ file with a new playthrough","being raped by Incubus","putting points into MAG","unironically watching Perofella","reposting from Top All Time","forgetting the Amano","cleaning the Schwarzwelt bathrooms","using buffs, retard","writing a super duper high-school - level essay on Persona 4","playing the WarioWare Shove-up - your - own - ass Game","getting shot by Goro","complaining about English dubs","mass genocide in the name of Law","having a fusion accident","getting the True Demon Ending","using the Sticky","reading the Wiki","paying me 200 Macca(edited)","getting half of your face melted by the Emblem curse","using .magik","karma whoring","challenging Demi-fiend to a duel","agreeing with SimplyDad","catching all these shitty adults by surprise and making yourself known to the world","playing on Apocalypse difficulty","killing YHVH, thereby committing the ultimate sin","getting stabbed in the chest by the Longinus Spear","playing a real Shin Megoomy Tensei game like Nocturne or Strange Journey","punching Philemon in the face","noticing your bulge owo","being a gay fucking faggot","waking up, getting up, getting out there","paying upwards of $300 for a small Jack Frost figure","never seeing it coming","making motorcycle noises to get demons to like you","thinking positive","dating Ulala for 2 weeks before realizing you've made a mistake","being a cat, in all candor","being the son of a fisherman, yet also being afraid of fish","getting eaten by Shesha","rending, slaughtering, devouring your enemies","oozing with style","shooting yourself in the head","jumping off a cliff with Shadow Yukino","beholding my demons","destroying the status quo","fusing away your dog","causing the conception"
            };

            fortunetextrand = new Random();
            fortuneimagerand = new Random();
            fortuneImageSurprisedRand = new Random();
            Fortune = new string[]
            {
                " good luck!",
                " great luck!",
                " a little luck.",
                " enough luck for two people!",
                " average luck.",
                " particularly good luck with money.",
                " particularly good luck with relationships.",
                "... horrible luck?!",
                " particularly bad luck with money...",
                " particularly bad luck with relationships..."

            };

            FortuneImage = new string[]
            {
                "portraits/jun.png",
                "portraits/ulala.png"
            };

            FortuneImageSurprised = new string[]
            {
                "portraits/surprisedjun.png",
                "portraits/surprisedulala.png"
            };
           

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

            commands = discord.GetService<CommandService>();

            TatsuyaCommand();
            FortuneCommand();
          
            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("Mjc1NzAzODU3MjQwMjExNDU2.C3ElAw.yOPqs1nABfGfVQwvg7hXrq8IDeg", TokenType.Bot);
            }); 
        }

        private void TatsuyaCommand()
        {
            commands.CreateCommand("man")
            .Do(async (e) =>
            {
                int index = tatsrand.Next(Tatsuya.Length); 
                string randomText = Tatsuya[index];
                await e.Channel.SendFile("portraits/tats.png");
                await e.Channel.SendMessage("Being a man means " + randomText + "...");     
            });
        }

        private void FortuneCommand()
        {
            commands.CreateCommand("fortune")
                .Do(async (e) =>
                {
                    int textIndex = fortunetextrand.Next(Fortune.Length);
                    string randomMessage = Fortune[textIndex];
                    
                    int imageIndex = fortunetextrand.Next(FortuneImage.Length);
                    string randomImage = FortuneImage[imageIndex];

                    int surprisedImageIndex = fortuneImageSurprisedRand.Next(FortuneImageSurprised.Length);
                    string randomSurprisedImage = FortuneImageSurprised[surprisedImageIndex];

                    if (textIndex < 7)
                    {
                        await e.Channel.SendFile(randomImage);
                    }
                    else
                    {
                        await e.Channel.SendFile(randomSurprisedImage);
                    }
                    await e.Channel.SendMessage("Today you'll have" + randomMessage);
                });
        }
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
