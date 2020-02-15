using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/Cameras/CameraVariable")]
    public class CameraVariable : ScriptableObject
    {
        public Camera Value = default;
    }
}