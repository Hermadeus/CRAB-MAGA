using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA
{
    public class OnEnable_InitLineEditor : MonoBehaviour
    {
        public LineEditorVariable lineEditorVar = default;

        private void OnEnable()
        {
            lineEditorVar.Value = GetComponent<LineEditor>();
            Destroy(this);
        }
    }
}