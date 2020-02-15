using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA
{
    public class OnEnable_AssignCamera : MonoBehaviour
    {
        public CameraVariable cam;
        private void OnEnable()
        {
            cam.Value = GetComponent<Camera>();
            Destroy(this);
        }
    }
}
