using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using QRTools.Utilities.Singleton;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/System/Language")]
    public class LanguageEnum : SingletonScriptableObject<LanguageEnum>
    {
        [EnumPaging]
        public Language language = Language.ENGLISH;
    }

    public enum Language
    {
        FRANCAIS,
        ENGLISH
    }
}
