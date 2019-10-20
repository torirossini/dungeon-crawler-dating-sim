using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class asciiDungeon
    {
        Dictionary<string, char> objects = new Dictionary<string, char>
        {
            ["Wall"] = 'X',
            ["Hallway"] = 'O',
            ["Room"] = 'R',
            ["Stairs"] = 'S',
        };

        public Dictionary<string,char> DungeonObjects
        {
            get { return objects; }
        }

        char[,] dungeon;
        int xLength = 50;
        int yLength = 50;

    }
}
