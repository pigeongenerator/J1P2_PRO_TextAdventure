﻿using J1P2_PRO_TextAdventure.Assets.Environment;
using J1P2_PRO_TextAdventure.GameScripts.Loops;
using System.Runtime.InteropServices;

namespace J1P2_PRO_TextAdventure.GameScripts
{
    internal class Game : GameScript
    {
        protected override void Script()
        {
            World world = new World();
            MainLoop mainLoop = new(world);
            Dialogue endDialogue;
            Dialogue finalDialogue;

            Welcome();
            mainLoop.Start();

            endDialogue = new(
                "it was a excruciating climb, but Jesse managed it just because of the beans.",
                "Jesse inspected the RV, the equipment didn't survive but luckily the built cool-box protected some food and water from the flames.",
                "Jesse started walking.",
                "and walking..",
                "and walking...",
                "after a full week of walking Jesse ran out of water",
                "Then finally, a car drove by.",
                "Jesse tried to hitch hike and the car stopped",
                "Jesse explained the situation and the person was glad to help");
            endDialogue.Start();

            finalDialogue = new("Finally when reaching Jesse's family, Jesse was very happy to see them and told them all about his adventure.");
            finalDialogue.ContinuePrompt = "the end.";
            finalDialogue.Start();
        }

        /// <summary>
        /// shows the game's title.
        /// </summary>
        private void Welcome()
        {
            Dialogue dialogue;
            Random random = new();
            string[] dialogueLines = {
                "After waking up, Jesse started preparing for a trip to their family.",
                "Jesse stepped in the RV and drove off.",
                "The sight was beautiful here in the mountains.",
                "There were lakes and trees everywhere.",
                "While distracted, Jesse didn't see the tree he was about to crash into",
                "Suddenly, Jesse realized their impending doom.",
                "Without thinking Jesse jumped out of the RV",
                "But not realizing that Jesse was on a mountain and rolled off the cliff",
                "A few moments later Jesse heard the fiery explosion which used to be the RV",
                "Then Jesse passed out.",
                "When waking up, Jesse felt very hungry."
            };


            if (random.Next(100) < 25) //returns true a curtain percentage of the time
            {
                dialogueLines[3] = "A potoo flew by, it was so majestic.";
            }

            dialogue = new Dialogue(dialogueLines);

            ShowTitle();
            Console.Clear();
            dialogue.Start();
        }

        /// <summary>
        /// shows the game's title screen
        /// </summary>
        private void ShowTitle()
        {
            Dialogue dialogue = new("");
            dialogue.ContinuePrompt = "<press any key to start>";

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                throw new PlatformNotSupportedException($"the platform {RuntimeInformation.OSDescription} is not supported, sorry!");
            }

            Console.Clear();
            Console.Title = "Jesse and the terrible crash of the recreational vehicle" +
                ": the survival outside civilization underneath the great crystal blue sky";
            Console.SetBufferSize(135, Console.WindowHeight);
            Console.SetWindowSize(135, Console.WindowHeight);

            WriteFromFile("./Assets/ASCII/title.txt");

            dialogue.Start();
        }

        /// <summary>
        /// writes all the lines from a file to console
        /// </summary>
        /// <param name="_filePath">specifies the path that should be written from</param>
        private void WriteFromFile(string _filePath)
        {
            string[] titleLines = File.ReadAllLines(_filePath);
            string title = string.Empty;

            foreach (string line in titleLines)
            {
                title += line + '\n';
            }

            Console.WriteLine(title);
        }
    }
}
