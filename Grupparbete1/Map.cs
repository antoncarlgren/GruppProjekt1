using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupparbete1.GameObjects;
using Grupparbete1.Tiles;

namespace Grupparbete1
{
    /// <summary>
    /// Innehåller all information om spelkartan, och rendererar den bild som visas för spelaren.
    /// </summary>
    public class Map
    {
        // Själva spelkartan i form av Tiles, där varje Tile innehåller information om den går att gå på eller inte, och vilket tecken som representerar den rutan.
        public TileBase[][] TileGrid { get; set; } 

        // Alla spelobjekt som existerar på planen, dvs spelaren, alla fiender och items.
        public List<GameObject> GameObjects { get; set; }

        // Det objekt som kontrolleras av spelaren.
        public Player Player { get; set; }

        public int Width { get; }
        public int Height { get; }

        // Används för att slumpa fram koordinater för nya spelobjekt.
        private readonly Random rng;

        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            rng = new Random();

            TileGrid = new TileBase[width][];
            GameObjects = new List<GameObject>();

            for(int x = 0; x < width; x++)
            {
              TileGrid[x] = new TileBase[height];
            }

            Init();       
        }

        // Genererar en ny spelkarta när spelet startas, och lägger till spelare och fiender.
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

        /// <summary>
        /// Används för att kolla om det finns ett GameObjekt av en viss typ på de angivna koordinater.
        /// Används bland annat när spelaren flyttas, för att kolla om det finns en fiende att attackera på den Tile som spelaren försöker gå till.
        /// </summary>
        /// <typeparam name="T">Den typ av GameObject som eftersöks.</typeparam>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public T GetEntityAtLoc<T>(int x, int y) where T : GameObject 
        {
            return GameObjects.Where(e => e.X == x && e.Y == y && e is T).FirstOrDefault() as T;
        }

        /// <summary>
        /// Fyller hela kartan med TileFloor.
        /// </summary>
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

        /// <summary>
        /// Slumpar fram koordinater tills en Tile som går att gå på slumpas fram, och skapar spelaren på den rutan.
        /// </summary>
        /// <param name="name">Namnet på spelaren som ska skapas.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Skapar ett antal fiender på slumpade koordinater.
        /// </summary>
        /// <param name="count">Antalet fiender som ska slumpas fram.</param>
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

        /// <summary>
        /// Skapar en rektangel med väggar av angiven storlek på spelkartan.
        /// </summary>
        /// <param name="originColumn">Den X-koordinat som rektangeln utgår ifrån.</param>
        /// <param name="originRow">Den Y-koordinat som rektangeln utgår ifrån.</param>
        /// <param name="sizeX">Rektangelns bredd.</param>
        /// <param name="sizeY">Rektangelns höjd.</param>
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

        /// <summary>
        /// Kollar om de angivna koordinaterna existerar på spelbrädet. Returnererar true om det existerar, och false om det inte existerar.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsWithinBounds(int x, int y)
        {
            return (x >= 0 && x < Width && y >= 0 && y < Height);
        }

        /// <summary>
        /// Ritar kartan på skärmen.
        /// </summary>
        public void DrawMap()
        {
            // Används för att konstruera en stärng för varje rad som ska renderas.
            var sb = new StringBuilder();

            // Itererar över varje ruta i varje rad.
            for(int y = 0; y < Height; y++)
            {               
                for (int x = 0; x < Width; x++)
                {
                    // Kollar om det finns något GameObject med koordinaterna på rutan som ska renderas.
                    var gameObjectAtLoc = GetEntityAtLoc<GameObject>(x, y);

                    // Om det finns ett GameObject på koordinaterna så läggs objektets tecken till i StringBuildern. Om inte, så läggs tecknet för den rutan till.
                    sb.Append(gameObjectAtLoc is null ? TileGrid[x][y].Glyph : gameObjectAtLoc.Glyph);
                }

                // Flyttar pekaren till den rad som ska skrivas ut.
                Console.SetCursorPosition(0, y);

                // Skriver ut strängen som konstruerats för att representera raden.
                Console.Write(sb.ToString());

                // Återställer StringBuildern så att den kan användas igen för nästa rad.
                sb.Clear();
            }
        }

        /// <summary>
        /// Uppdaterar kartan när en Actors position ändras, så att det som visas för spelaren stämmer överrens med Actorns nya position.
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="lastLocation">Actorns förra position. Används för att uppdatera rutan med dess förra koordinater.</param>
        public void UpdateAfterActorMove(Actor actor, Point lastLocation)
        {
            if (GameObjects.Contains(actor))
            {
                var gameObjectAtLoc = GetEntityAtLoc<GameObject>(lastLocation.X, lastLocation.Y);

                Console.SetCursorPosition(lastLocation.X, lastLocation.Y);
                Console.Write(gameObjectAtLoc is null ? TileGrid[lastLocation.X][lastLocation.Y].Glyph : gameObjectAtLoc.Glyph);
                Console.SetCursorPosition(actor.X, actor.Y);
                Console.Write(actor.Health > 0 ? actor.Glyph : TileGrid[actor.X][actor.Y].Glyph);
            }
        }
    }
}
