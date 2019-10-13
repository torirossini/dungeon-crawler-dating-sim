
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.DungeonGen
{
    class DungeonRoom
    {
        const int MAX_HEIGHT = 20;
        const int MAX_WIDTH = 30;
        const int MIN_HEIGHT = 10;
        const int MIN_WIDTH = 10;
        int roomWidth;
        int roomHeight;

        [SerializeField]
        private GameObject roomCube;

        private Rigidbody roomRigidBody;
        private SphereCollider sphereCollider;

        public GameObject RoomCube { get => roomCube; set => roomCube = value; }
        public int RoomWidth { get => roomWidth; set => roomWidth = value; }
        public int RoomHeight { get => roomHeight; set => roomHeight = value; }
        public Rigidbody RoomRigidBody { get => roomRigidBody; set => roomRigidBody = value; }

        public DungeonRoom(GameObject baseCube)
        {
            roomWidth = Random.Range(MIN_WIDTH, MAX_WIDTH);
            roomHeight = Random.Range(MIN_HEIGHT, MAX_HEIGHT);
            Vector3 location = Vector3.zero;
            roomCube = GameObject.Instantiate(baseCube, location, Quaternion.identity);
            roomCube.transform.localScale = new Vector3(roomWidth, 1, roomHeight);
            roomRigidBody = roomCube.AddComponent<Rigidbody>();
            roomRigidBody.useGravity = false;
            roomRigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
            roomRigidBody.drag = 5;

        }

        public DungeonRoom(Vector3 loc, GameObject baseCube)
        {
            roomWidth = Random.Range(MIN_WIDTH, MAX_WIDTH);
            roomHeight = Random.Range(MIN_HEIGHT, MAX_HEIGHT);
            Vector3 location = loc;

            roomCube = GameObject.Instantiate(baseCube, location, Quaternion.identity) as GameObject;
            roomCube.transform.localScale = new Vector3(roomWidth, 1, roomHeight);
            roomRigidBody = roomCube.AddComponent<Rigidbody>();
            roomRigidBody.useGravity = false;
            roomRigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
            sphereCollider = roomCube.AddComponent<SphereCollider>();
            sphereCollider.radius = sphereCollider.radius * 2;
            roomRigidBody.drag = 50f;
            roomRigidBody.mass = 20f;
        }

    }
}
