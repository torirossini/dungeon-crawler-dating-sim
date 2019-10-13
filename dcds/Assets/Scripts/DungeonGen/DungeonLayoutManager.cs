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
    const int MAX_NUM_OF_ROOMS = 50;

    [SerializeField]
    int roomSpawnX = 5;
    [SerializeField]
    int roomSpawnZ = 20;

    [SerializeField]
    Material mainMaterial;

    public GameObject BaseCube { get => baseCube; set => baseCube = value; }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateRooms(50));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator GenerateRooms(int numRooms)
    {
        int avgWidth = 0;
        int avgHeight = 0;
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
            dungeonRooms.Add(new DungeonRoom(RandomLocationInBox(roomSpawnZ, roomSpawnX), baseCube));
            dungeonRooms[dungeonRooms.Count - 1].RoomCube.transform.SetParent(roomsObject.transform);
            avgHeight += dungeonRooms[dungeonRooms.Count - 1].RoomHeight;
            avgWidth += dungeonRooms[dungeonRooms.Count - 1].RoomWidth;
        }

        avgHeight = avgHeight / numRooms;
        avgWidth = avgWidth / numRooms;

        yield return new WaitWhile(() => !RoomsSettled());
        
        for(int i = 0; i < dungeonRooms.Count - 1; i++)
        {
            if (dungeonRooms[i].RoomHeight > avgHeight && dungeonRooms[i].RoomWidth > avgWidth)
            {
                dungeonRooms[i].RoomCube.GetComponent<Renderer>().material = mainMaterial;
            }

            dungeonRooms[i].RoomRigidBody.isKinematic = true;
            dungeonRooms[i].RoomCube.transform.position = new Vector3(Mathf.RoundToInt(dungeonRooms[i].RoomCube.transform.position.x),
                0,
                Mathf.RoundToInt(dungeonRooms[i].RoomCube.transform.position.z));

        }

    }

    //TODO Add Timeout: if it takes too long, retry. 
    private bool RoomsSettled()
    {
        foreach(DungeonRoom room in dungeonRooms)
        {
            if (!room.RoomRigidBody.IsSleeping())
            {
                return false;
            }
        }
        return true;
    }

    private Vector3 RandomLocationInBox(int widthBox, int heightBox)
    {
        return new Vector3(Random.Range(0, widthBox/2), 0, Random.Range(0, heightBox/2));
    }
}
