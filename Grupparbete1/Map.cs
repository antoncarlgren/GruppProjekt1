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

            rng = new Random();

            TileGrid = new TileBase[width][];
            GameObjects = new List<Entity>();

            for(int x = 0; x < width; x++)
            {
              TileGrid[x] = new TileBase[height];
            }

            Init();       
        }

        public void Init()
        {
            FillWithFloor();
            CreateRoomWalls(0, 0, Width - 1, Height - 1);
            CreateRoomWalls(5, 10, 10, 5);
            Player = CreatePlayer("Player");
            CreateEnemies(10);
            GameObjects.Add(Player);
            DrawMap();
        }

        public T GetEntityAtLoc<T>(int x, int y) where T : Entity 
        {
            return GameObjects.Where(e => e.X == x && e.Y == y && e is T).FirstOrDefault() as T;
        }

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

        private Player CreatePlayer(string name)
        {
            int tempX;
            int tempY;

            do
            {
                tempX = rng.Next(Width);
                tempY = rng.Next(Height);
            } while (!TileGrid[tempX][tempY].IsWalkable);

            return new Player(tempX, tempY, name);
        }

        private void CreateEnemies(int count)
        {
            int tempX;
            int tempY;

            for(int i = 0; i < count; i++)
            {
                do
                {
                    tempX = rng.Next(Width);
                    tempY = rng.Next(Height);
                } while (!TileGrid[tempX][tempY].IsWalkable);
                GameObjects.Add(new Enemy(tempX, tempY, "Enemy"));
            }
        }

        private void CreateRoomWalls(int originColumn, int originRow, int sizeX, int sizeY)
        {
            if(IsWithinBounds(originColumn, originRow) && IsWithinBounds(originColumn + sizeX, originRow + sizeY))
            {
                for(int x = originColumn; x <= originColumn + sizeX; x++)
                {
                    TileGrid[x][originRow] = new TileWall();
                    TileGrid[x][originRow + sizeY] = new TileWall();
                }

                for(int y = originRow; y <= originRow + sizeY; y++)
                {
                    TileGrid[originColumn][y] = new TileWall();
                    TileGrid[originColumn + sizeX][y] = new TileWall();
                }
            }
        }

        private bool IsWithinBounds(int x, int y)
        {
            return (x >= 0 && x < Width && y >= 0 && y < Height);
        }

        public void DrawMap()
        {
            //Console.Clear();
            var sb = new StringBuilder();

            for(int y = 0; y < Height; y++)
            {               
                for (int x = 0; x < Width; x++)
                {
                    var entityAtLoc = GameObjects.Where(e => e.X == x && e.Y == y).ToList();

                    sb.Append(entityAtLoc.Count <= 0 ? TileGrid[x][y].Glyph : entityAtLoc[0].Glyph);
                }

                Console.SetCursorPosition(0, y);
                Console.Write(sb.ToString());
                sb.Clear();
            }
        }
    }
}
