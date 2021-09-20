using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1
{
    public class Map
    {
        public TileBase[][] TileGrid { get; set; }
        public List<Entity> GameObjects { get; set; }

        public Player Player { get; set; }

        public int Width { get; }
        public int Height { get; }

        private readonly Random rng;

        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            TileGrid = new TileBase[width][];
            GameObjects = new List<Entity>();

            for(int x = 0; x < width; x++)
            {
              TileGrid[x] = new TileBase[height];
            }

            Player = new Player(0, 0, "Player");
            rng = new Random();

            Init();
        }

        public void Init()
        {
            FillWithFloor();
            CreatePlayer();
            GameObjects.Add(Player);
            DrawMap();
        }

        //public T GetEntityAtLoc<T>(int x, int y) where T : Entity 
        //{
        //    return GameObjects.Where(e => e.X == x && e.Y == y && e is T).FirstOrDefault() as T;
        //}

        private void FillWithFloor()
        {
            for(int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    TileGrid[x][y] = new TileFloor();
                }
            }
        }

        private void CreatePlayer()
        {
            int tempX;
            int tempY;

            do
            {
                tempX = rng.Next(Width);
                tempY = rng.Next(Height);
            } while (!TileGrid[tempX][tempY].IsWalkable);

            Player.X = tempX;
            Player.Y = tempY;
        }

        public void DrawMap()
        {
            var sb = new StringBuilder();

            for(int y = 0; y < Height; y++)
            {               
                for (int x = 0; x < Width; x++)
                {
                    sb.Append(TileGrid[x][y].Glyph);
                }

                Console.SetCursorPosition(0, y);
                Console.Write(sb.ToString());
                sb.Clear();
            }
        }
    }
}
