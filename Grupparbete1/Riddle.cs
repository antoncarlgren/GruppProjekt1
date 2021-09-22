using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupparbete1.GameObjects;
using Grupparbete1.MapData;

namespace Grupparbete1
{
    public class Riddle
    {
        private string _text;
        private ConsoleKey _correctAnswerKey;
        private string _answerString;
        private bool _wasLastAnswerWrong;

        public static List<Riddle> Generate()
        {
            var riddleList = new List<Riddle>();

            List<string> riddleTexts = new List<string>()
            {
                "gåta 1",
                "gåta 2",
                "gåta 3"
            };

            List<ConsoleKey> riddleAnswerKeys = new List<ConsoleKey>()
            {
                ConsoleKey.D1,
                ConsoleKey.D1,
                ConsoleKey.D1
            };

            List<string> riddleAnswerStrings = new List<string>()
            {
                "svar#svar#svar#svar",
                "svar#svar#svar#svar",
                "svar#svar#svar#svar"
            };

            if (riddleTexts.Count == riddleAnswerKeys.Count && riddleTexts.Count == riddleAnswerStrings.Count)
            {
                for(int i = 0; i < riddleTexts.Count; i++)
                {
                    riddleList.Add(new Riddle(riddleTexts[i], riddleAnswerKeys[i], riddleAnswerStrings[i]));
                }
            }

            return riddleList;
        }

        public Riddle(string text, ConsoleKey correctAnswerKey, string answerString)
        {
            _text = text;
            _correctAnswerKey = correctAnswerKey;
            _answerString = answerString;
            _wasLastAnswerWrong = false;
        }

        public void PrintRiddle()
        {
            Program.Game.MessageLog.ClearQueue();

            if (_wasLastAnswerWrong) 
            {
                Program.Game.MessageLog.Add("Fel svar, gissa igen.");
            }

            Program.Game.MessageLog.Add(_text);

            var answerOptions = _answerString.Split('#');

            for (int i = 0; i < answerOptions.Length; i++)
            {
                Program.Game.MessageLog.Add($"{i + 1}. {answerOptions[i]}");
            }
        }
        public void Guess(ConsoleKey input)
        {
            Console.SetCursorPosition(1, Console.GetCursorPosition().Top + 5);
            Console.CursorVisible = true;

            if (input == _correctAnswerKey)
            {
                Program.Game.MessageLog.Add("Rätt svar!");
                Program.Game.CurrentMode = ControlMode.Movement;
                Program.Game.GameMap.CurrentRoom.ExitDoor.Open();
                Program.Game.GameMap.GameObjects.Remove(Program.Game.GameMap.CurrentRiddleTablet);
            }
            else
            {
                _wasLastAnswerWrong = true;
                PrintRiddle();
            }

            Console.CursorVisible = false;
        }
    }
}
