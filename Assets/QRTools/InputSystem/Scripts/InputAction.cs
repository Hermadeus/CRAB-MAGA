using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QRTools.Variables;

namespace QRTools.Inputs
{
    public abstract class InputAction : ScriptableObject
    {
        [TextArea(3, 5)]
        [SerializeField] string description;
        public bool isActive = true;
        [Tooltip("Input name (see Unity Input Manager)")]
        public string inputName;

        public abstract void Init();
        public abstract void Execute();
    }
}
