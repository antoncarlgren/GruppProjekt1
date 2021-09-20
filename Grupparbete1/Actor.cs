using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1
{
    public class Actor : Entity
    {
        private int _health;
        public int MaxHealth { get; set; }
        public int Health
        {
            get => _health;
            set
            {
                if (value > MaxHealth)
                {
                    _health = MaxHealth;
                }
                else if (value < 0)
                {
                    _health = 0;
                }
                else
                {
                    _health = value;
                }
            
            }
        }

        public int Damage { get; set; }
        public int Defense { get; set; }
        private Random dice;

        public Actor(int x, int y, string name, char glyph, int maxHealth, int damage, int defense) : base(x, y, name, glyph)
        {
            dice = new Random();
            MaxHealth = maxHealth;
            Health = MaxHealth;
            Damage = damage;
            Defense = defense;
        }

        public bool MoveBy(int deltaX, int deltaY)
        {
            if (X + deltaX > 0 && X + deltaX < Program.Game.GameMap.Width && Y + deltaY > 0 && Y + deltaY < Program.Game.GameMap.Height)
            {                

                if (Program.Game.GameMap.TileGrid[X + deltaX][Y + deltaY].IsWalkable)
                {
                    var enemy = Program.Game.GameMap.GetEntityAtLoc<Enemy>(X + deltaX, Y + deltaY);
                    if (enemy is not null)
                    {
                        Attack(enemy);
                        return true;
                    }
                    else
                    {
                        X += deltaX;
                        Y += deltaY;
                        return true;
                    }
                }
            }
            return false;
        }

        public void Attack(Actor defender)
        {
            var attackRoll = dice.Next(1, 21);

            if(attackRoll > defender.Defense)
            {
                defender.Health -= Damage;

                if(defender.Health <= 0)
                {
                    Program.Game.GameMap.GameObjects.Remove(defender);
                }
            }
        }
    }
}
