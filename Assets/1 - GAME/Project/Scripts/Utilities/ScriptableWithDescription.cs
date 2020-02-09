using UnityEngine;
using Sirenix.OdinInspector;

namespace CRABMAGA
{
    /// <summary>
    /// Scriptable Object with a description to never forget !
    /// </summary>
    public class ScriptableWithDescription : SerializedScriptableObject
    {
        [SerializeField, TextArea(3,5)] private string description = default;
    }
}
