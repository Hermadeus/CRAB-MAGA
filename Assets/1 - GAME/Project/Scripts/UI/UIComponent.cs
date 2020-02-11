using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA
{
    public class UIComponent : MonoBehaviour, IUITilable
    {
        [HideInInspector] public RectTransform contener => GetComponent<RectTransform>();

        public void OnClick()
        {
            throw new System.NotImplementedException();
        }
    }
}
