using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA {
    [CreateAssetMenu(menuName = "CRAB MAGA/Cameras/CameraManagerVariable")]
    public class CameraManagerVariable : ScriptableObject
    {
        public CameraManager Value = default;

        public void SetCurrentTarget(string name)
        {
            Value.SetCurrentTarget(name);
        }

        public void TransitionTo(string name)
        {
            Value.TransitionTo(name);
        }

        public void TransitionTo(VagueData vague)
        {

        }
    }
}