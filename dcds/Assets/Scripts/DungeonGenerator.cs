using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator
{
    Dictionary<string, char> objects = new Dictionary<string, char>
    {
        ["Wall"] = 'X',
        ["Hallway"] = 'O',
        ["Room"] = 'R',
        ["Stairs"] = 'S',
    };

    char[,] dungeon;
    int xLength = 50;
    int yLength = 50;

    private char[,] GenerateRoom(int width, int height, int connections)
    {
        char[,] room = new char[width, height];

        List<int[]> borderCoordinates = new List<int[]>();

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                if((x==0 || x == width-1 || y == 0 || y == height-1) && (x != 0 && y != 0))
                {
                    borderCoordinates.Add(new int[] {x, y});
                }
                
            }
        }

        for(int i = 0; i < connections; i++)
        {
            int[] coordForHall = borderCoordinates[Random.Range(0, borderCoordinates.Count - 1)];
            room[coordForHall[0], coordForHall[1]] = objects["Hallway"];
            if(coordForHall[0] == 0)
            {
                room[coordForHall[0], coordForHall[1] - 1] = objects["Hallway"];
            }
            else
            {
                room[coordForHall[0]-1, coordForHall[1]] = objects["Hallway"];
            }
        }
        return null;

    }

    private void PrintRoom(char[,] room)
    {


    }



}
