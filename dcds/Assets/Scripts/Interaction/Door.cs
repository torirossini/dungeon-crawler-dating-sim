using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Interaction
{
    class Door : InteractionObject
    {
        [Header("Door Variables")]
        [SerializeField]
        public int SceneToLoad = 0;
        public override void Interact()
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}
