using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/CameraSystem/CameraVariable")]
    public class CameraVariable : ScriptableObject
    {
        public Camera cam = default;
    }
}