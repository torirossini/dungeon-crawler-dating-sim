
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class AsciiRoom : asciiDungeon
    {
        private int roomX;
        private int roomY;
        private char[,] room;

        public int RoomWidth
        {
            get { return roomX; }
        }

        public int RoomHeight
        {
            get { return roomY; }
        }

        public char[,] RoomLayout
        {
            get { return room; }
            set { room = value; }
        }

        private char[,] GenerateRoom(int width, int height, int connections)
        {
            Random rnd = new Random();
            char[,] roomLayout = new char[width, height];

            List<int[]> borderCoordinates = new List<int[]>();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if ((x == 0 || x == width - 1 || y == 0 || y == height - 1) && (x != 0 && y != 0))
                    {
                        borderCoordinates.Add(new int[] { x, y });
                        roomLayout[x, y] = DungeonObjects["Wall"];
                    }
                    else
                    {
                        roomLayout[x,y] = DungeonObjects["Room"];
                    }

                }
            }

            for (int i = 0; i < connections; i++)
            {
                int[] coordForHall = borderCoordinates[rnd.Next(0, borderCoordinates.Count - 1)];
                room[coordForHall[0], coordForHall[1]] = DungeonObjects["Hallway"];
                if (coordForHall[0] == 0)
                {
                    room[coordForHall[0], coordForHall[1] - 1] = DungeonObjects["Hallway"];
                }
                else
                {
                    room[coordForHall[0] - 1, coordForHall[1]] = DungeonObjects["Hallway"];
                }
            }

            return roomLayout;
        }

        private void PrintRoom(char[,] room)
        {
            for(int x = 0; x< room.GetLength(0); x++)
            {
                for (int y = 0; y < room.GetLength(1); y++)
                {
                    Console.Write(room[x, y]);
                }
            }

        }
    }
}
