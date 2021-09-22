using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1
{
    public class Riddle
    {
        public string Text { get; }
        public List<string> AnswerOptions { get; }
        public ConsoleKey CorrectAnswerIndex { get; }

        public Riddle(string text, List<string> answerOptions, ConsoleKey correctAnswerIndex)
        {
            Text = text;
            AnswerOptions = answerOptions;
            CorrectAnswerIndex = correctAnswerIndex;
        }

        public void PrintRiddle()
        {
            Program.Game.MessageLog.Add(Text);

            for (int i = 0; i < AnswerOptions.Count; i++)
            {
                Program.Game.MessageLog.Add($"{i + 1}. {AnswerOptions[i]}");
            }
        }

        public void Guess(ConsoleKey input)
        {
            if(input == CorrectAnswerIndex)
            {
                Program.Game.MessageLog.Add("Rätt svar!");
                Program.Game.CurrentMode = ControlMode.Movement;
                Program.Game.GameMap.CurrentRoom.ExitDoor.Open();
            }

        }
    }
}
