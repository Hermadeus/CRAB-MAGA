using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA
{
    public class OnEnable_AssignCameraManager : MonoBehaviour
    {
        public CameraManagerVariable CameraManagerVariable = default;
        private void OnEnable()
        {
            CameraManagerVariable.Value = GetComponent<CameraManager>();
        }
    }
}