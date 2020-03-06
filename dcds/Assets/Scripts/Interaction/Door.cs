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

        [SerializeField]
        bool CanEnter;

        [SerializeField]
        

        public override void Interact()
        {
            if (CanEnter)
            {
                CanvasManager.Instance.DestroyIcons();
                SceneManager.LoadScene(SceneToLoad);
            }
            else
            {

            }

        }
    }
}
