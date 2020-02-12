using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

using DG.Tweening;

namespace QRTools.UI
{
    public class UIMenu : UIElement, IUIMenu
    {
        [SerializeField] private CanvasGroup menu = default;
        public CanvasGroup Menu { get => menu; set { menu = value; } }

        public ApparitionMode apparitionMode = ApparitionMode.FADE;

        [ShowIf("apparitionMode", ApparitionMode.FADE)]
        public float fadeTimer = .5f;
        [ShowIf("apparitionMode", ApparitionMode.FADE)]
        public Ease ease = Ease.Linear;

        public override void Init()
        {
            TryGetComponent<CanvasGroup>(out menu);
        }

        public override void Show()
        {
            switch (apparitionMode)
            {
                case ApparitionMode.FADE:
                    float to = 1;
                    DOTween.To(() => menu.alpha, x => menu.alpha = x, to, fadeTimer).SetEase(ease).OnComplete(OnHide.Invoke);
                    break;
                case ApparitionMode.ANIMATION:
                    // implementer avec du easing et en choisissant la direction
                    throw new System.NotImplementedException("implementer avec du easing et en choisissant la direction");
                    break;
            }
        }

        public override void Hide()
        {
            switch (apparitionMode)
            {
                case ApparitionMode.FADE:
                    float to = 0;
                    DOTween.To(() => menu.alpha, x => menu.alpha = x, to, fadeTimer).SetEase(ease).OnComplete(OnHide.Invoke);
                    break;
                case ApparitionMode.ANIMATION:
                    throw new System.NotImplementedException("implementer avec du easing et en choisissant la direction");
                    break;
            }
        }

        
    }

    public enum ApparitionMode
    {
        FADE,
        ANIMATION,
    }
}