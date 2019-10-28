using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Utility;

namespace Assets
{
    class CameraViewCollider:MonoBehaviour
    {
        
        public CurrentView OuterView;
        public CurrentView CenterView;
        PlayerFollowCamera camera;

        private void Start()
        {
            camera = TownManager.Instance.PlayerCamera.GetComponent<PlayerFollowCamera>();
        }

        public void ChangeView()
        {
            // If the camera is currently on the first view, switch to the second view. 
            // Otherwise, switch to the first view.
            CurrentView toView = camera.CurrentlyFacing == OuterView ? CenterView : OuterView;
            camera.ChangeView(toView);
        }
    }
}
