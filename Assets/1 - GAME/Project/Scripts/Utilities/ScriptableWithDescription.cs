using UnityEngine;
using Sirenix.OdinInspector;

namespace CRABMAGA
{
    public class ScriptableWithDescription : SerializedScriptableObject
    {
        [SerializeField, TextArea(3,5)] private string description = default;
    }
}
