using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA
{
    public class OnEnable_AssignActionPhaseManager : MonoBehaviour
    {
        public ActionPhaseManagerVariable actionPhaseVariable = default;
        private void OnEnable()
        {
            actionPhaseVariable.Value = GetComponent<ActionPhaseManager>();
            Destroy(this);
        }
    }
}
