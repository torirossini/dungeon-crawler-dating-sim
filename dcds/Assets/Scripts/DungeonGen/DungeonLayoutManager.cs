using Assets.Scripts.DungeonGen;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HullDelaunayVoronoi.Delaunay;
using HullDelaunayVoronoi.Primitives;


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

    private DelaunayTriangulation2 delaunay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateMap(50));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator GenerateMap(int numRooms)
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

        List<DungeonRoom> mainRooms = new List<DungeonRoom>();
        
        for(int i = 0; i < dungeonRooms.Count - 1; i++)
        {
            if (dungeonRooms[i].RoomHeight > avgHeight && dungeonRooms[i].RoomWidth > avgWidth)
            {
                dungeonRooms[i].RoomCube.GetComponent<Renderer>().material = mainMaterial;
                mainRooms.Add(dungeonRooms[i]);
            }

            dungeonRooms[i].RoomRigidBody.isKinematic = true;
            dungeonRooms[i].RoomCube.transform.position = new Vector3(Mathf.RoundToInt(dungeonRooms[i].RoomCube.transform.position.x),
                0,
                Mathf.RoundToInt(dungeonRooms[i].RoomCube.transform.position.z));
        }

        List<Vertex2> vertices = new List<Vertex2>();
        foreach (DungeonRoom room in dungeonRooms)
        {
            vertices.Add(new Vertex2(room.RoomCube.transform.position.x, room.RoomCube.transform.position.z));
        }
        delaunay = new DelaunayTriangulation2();
        delaunay.Generate(vertices);


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
