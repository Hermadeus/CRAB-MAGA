using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace QRTools.UI
{
    public abstract class UIElement : MonoBehaviour, IUIElement
    {
        [HideInInspector] public RectTransform rectTransform;

        [SerializeField] private UnityEvent onShow = new UnityEvent();
        [SerializeField] private UnityEvent onHide = new UnityEvent();
        public UnityEvent OnHide { get => onHide; set => onHide = value; }
        public UnityEvent OnShow { get => onShow; set => onShow = value; }

        protected void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            Init();
        }

        public abstract void Hide();

        public abstract void Show();

        public abstract void Init();
    }
}
