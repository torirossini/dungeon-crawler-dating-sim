using Assets.Scripts.DungeonGen;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonLayoutManager : MonoBehaviour
{
    public GameObject roomsObject;
    public GameObject baseCube;

    List<DungeonRoom> dungeonRooms = new List<DungeonRoom>();
    const int MIN_NUM_OF_ROOMS = 3;
    const int MAX_NUM_OF_ROOMS = 20;

    [SerializeField]
    int DungeonHeight = 50;
    [SerializeField]
    int DungeonWidth = 50;

    public GameObject BaseCube { get => baseCube; set => baseCube = value; }

    // Start is called before the first frame update
    void Start()
    {
        GenerateRooms(20);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerateRooms(int numRooms)
    {
        if(numRooms > MAX_NUM_OF_ROOMS)
        {
            numRooms = MAX_NUM_OF_ROOMS;
        }
        if (numRooms < MIN_NUM_OF_ROOMS)
        {
            numRooms = MIN_NUM_OF_ROOMS;
        }
        for( int i = 0; i < numRooms; i++)
        {
            dungeonRooms.Add(new DungeonRoom(RandomLocationInBox(DungeonWidth, DungeonHeight), baseCube));
            dungeonRooms[dungeonRooms.Count - 1].RoomCube.transform.SetParent(roomsObject.transform);
        }
    }

    private Vector3 RandomLocationInBox(int widthBox, int heightBox)
    {
        return new Vector3(Random.Range(0, widthBox/2), 0, Random.Range(0, heightBox/2));
    }
}
