
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1.Engine
{
    public class MessageLog
    {
        public Coord Position { get; }
        private Queue<string> _messages;
        private int _maxLines;

        public MessageLog(Coord position, int maxLines)
        {
            Position = position;
            _maxLines = maxLines;
            _messages = new Queue<string>();

        }

        public void Add(string message)
        {
            _messages.Enqueue(message);

            if(_messages.Count > _maxLines)
            {
                _messages.Dequeue();
            }

            for(int i = 0; i < _messages.Count; i++)
            {
                Console.SetCursorPosition(Position.X, Position.Y + i);
                Console.Write(" ", Console.WindowWidth);

                Console.SetCursorPosition(Position.X, Position.Y + i);
                Console.Write(_messages.ToList()[i]);
            }
        }
    }
}
