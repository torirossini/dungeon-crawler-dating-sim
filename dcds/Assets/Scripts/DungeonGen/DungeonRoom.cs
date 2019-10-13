
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.DungeonGen
{
    class DungeonRoom
    {
        const int MAX_HEIGHT = 15;
        const int MAX_WIDTH = 15;
        const int MIN_HEIGHT = 5;
        const int MIN_WIDTH = 5;
        int width;
        int height;

        [SerializeField]
        private GameObject roomCube;

        private Rigidbody roomRigidBody;
        private SphereCollider sphereCollider;

        public GameObject RoomCube { get => roomCube; set => roomCube = value; }

        public DungeonRoom(GameObject baseCube)
        {
            width = Random.Range(MIN_WIDTH, MAX_WIDTH);
            height = Random.Range(MIN_HEIGHT, MAX_HEIGHT);
            Vector3 location = Vector3.zero;
            roomCube = GameObject.Instantiate(baseCube, location, Quaternion.identity);
            roomCube.transform.localScale = new Vector3(width, 1, height);
            roomRigidBody = roomCube.AddComponent<Rigidbody>();
            roomRigidBody.useGravity = false;
            roomRigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
            roomRigidBody.drag = 5;

        }

        public DungeonRoom(Vector3 loc, GameObject baseCube)
        {
            width = Random.Range(MIN_WIDTH, MAX_WIDTH);
            height = Random.Range(MIN_HEIGHT, MAX_HEIGHT);
            Vector3 location = loc;

            roomCube = GameObject.Instantiate(baseCube, location, Quaternion.identity) as GameObject;
            roomCube.transform.localScale = new Vector3(width, 1, height);
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
