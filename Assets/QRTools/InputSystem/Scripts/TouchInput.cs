using UnityEngine;

using QRTools.Variables;

using Sirenix.OdinInspector;

namespace QRTools.Inputs
{
    [CreateAssetMenu(fileName = "New Touch", menuName = "QRTools/Input/Touch", order = 20)]
    public class TouchInput : InputAction
    {
        #region Properties & Variables
        [SerializeField, EnumPaging] private TouchState touchType = default;
        public GameEvent onInput = default;

        [Tooltip("Delay between two click if DOUBLE_TAP"), ShowIf("touchType", TouchState.DOUBLE_TAP)]
        public float doubleClickTime = .2f;
        private float lastClickTime = .2f;

        [Title("Fields after are to consifers only in LongPressed or Swipe")]
        public GameEvent onTouchEnter = default;
        public GameEvent onTouchStay = default;

        
        #region LongTouch
        [Tooltip("Delay between two click if SIMPLE_LONGPRESSED"), ShowIf("touchType", TouchState.SIMPLE_LONGPRESSED)]
        public float longPressedTime = .5f;
        [HideInInspector] public float longPressedTimer;
        #endregion

        #region Swipping
        [ShowIf("touchType", TouchState.HORIZONTAL_SWIPE)]
        public GameEvent onSwipeRight = default;
        [ShowIf("touchType", TouchState.HORIZONTAL_SWIPE)]
        public GameEvent onSwipeLeft = default;

        [ShowIf("touchType", TouchState.VERTICAL_SWIPE)]
        public GameEvent onSwipeUp = default;
        [ShowIf("touchType", TouchState.VERTICAL_SWIPE)]
        public GameEvent onSwipeDown = default;

        [Tooltip("Distance to run with your finger to activate the input")]
        public float swipeDistanceThresold = 50f;
        #endregion

        public TouchState TouchState
        {
            get { return touchType; }
            set
            {
                touchType = value;
                ChangeState(value);
            }
        }
        private Touch touch;
        public delegate void PlayInput();
        PlayInput PlayCurrentInput;
        bool asTouch = false;

        private Vector2
            startPos = new Vector2(),
            endPos = new Vector2();
        #endregion

        #region Runtime Methods
        public override void Init()
        {
            ChangeState(touchType);
        }

        public override void Execute()
        {
            if (!isActive)
                return;

            PlayCurrentInput?.Invoke();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Change state of TouchState
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(TouchState state)
        {
            RemoveDelegate();

            switch (state)
            {
                case TouchState.SIMPLE_DOWN:
                    PlayCurrentInput += SimpleDown;
                    break;
                case TouchState.SIMPLE_UP:
                    PlayCurrentInput += SimpleUp;
                    break;
                case TouchState.SIMPLE_PRESSED:
                    PlayCurrentInput += SimplePressed;
                    break;
                case TouchState.SIMPLE_LONGPRESSED:
                    PlayCurrentInput += SimpleLongPressed;
                    break;

                case TouchState.DOUBLE_TAP:
                    PlayCurrentInput += DoubleTapDown;
                    break;

                case TouchState.SWIPE:
                    PlayCurrentInput += SimpleSwipe;
                    break;
                case TouchState.HORIZONTAL_SWIPE:
                    PlayCurrentInput += HorizontalSwipe;
                    break;                
                case TouchState.VERTICAL_SWIPE:
                    PlayCurrentInput += VerticalSwipe;
                    break;
            }
        }
        #endregion

        #region Delegate Methods
        void RemoveDelegate()
        {
            PlayCurrentInput = null;
        }

        void SimpleDown() => SimpleTouch(TouchPhase.Began);
        void SimpleUp() => SimpleTouch(TouchPhase.Ended);
        void SimplePressed() => SimpleTouch(TouchPhase.Stationary);
        void SimpleLongPressed() => LongTap();

        void HorizontalSwipe() => Swipe(TouchState.HORIZONTAL_SWIPE);
        void VerticalSwipe() => Swipe(TouchState.VERTICAL_SWIPE);
        void SimpleSwipe() => Swipe(TouchState.SWIPE);

        void DoubleTapDown() => DoubleTap(TouchPhase.Began);
        #endregion

        #region Private Methods
        void Swipe(TouchState state)
        {
            if (Input.touchCount == 1)
            {
                touch = Input.touches[0];
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        startPos = touch.position;
                        onTouchEnter?.Raise();
                        break;
                    case TouchPhase.Moved:
                        onTouchStay?.Raise();
                        break;
                    case TouchPhase.Ended:
                        endPos = touch.position;
                        AnalyseGesture(startPos, endPos, state);
                        break;
                }
            }
        }

        void AnalyseGesture(Vector2 start, Vector2 end, TouchState state)
        {
            if(Vector2.Distance(start, end) > swipeDistanceThresold)
            {
                onInput?.Raise();

                switch (state)
                {
                    case TouchState.VERTICAL_SWIPE:
                        if (start.y < end.y)
                            onSwipeUp?.Raise();
                        else if (start.y > end.y)
                            onSwipeDown?.Raise();
                        break;

                    case TouchState.HORIZONTAL_SWIPE:
                        if (start.x < end.x)
                            onSwipeRight?.Raise();
                        else if (start.x > end.x)
                            onSwipeLeft?.Raise();
                        break;
                }
            }
        }

        void LongTap()
        {
            if (Input.touchCount == 1)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    longPressedTimer = longPressedTime;
                    onTouchEnter?.Raise();
                    asTouch = true;
                }

                if (touch.phase == TouchPhase.Stationary)
                {
                    longPressedTimer -= Time.deltaTime;

                    if(longPressedTimer > 0)
                        onTouchStay?.Raise();

                    if(longPressedTimer <= 0 && asTouch)
                    {
                        onInput?.Raise();
                        asTouch = false;
                    }
                }
            }
        }

        void DoubleTap(TouchPhase phase)
        {
            if (Input.touchCount == 1)
            {
                float timeSinceLastClick = Time.time - lastClickTime;
                touch = Input.GetTouch(0);

                if (touch.phase == phase && timeSinceLastClick <= doubleClickTime)
                {
                    lastClickTime = Time.time;
                    onInput?.Raise();
                }

                lastClickTime = Time.time;
            }
        }

        void SimpleTouch(TouchPhase phase)
        {
            if (Input.touchCount == 1)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == phase)
                    onInput?.Raise();
            }
        }
        #endregion
    }

    #region Enums
    public enum TouchState
    {
        SIMPLE_DOWN,
        SIMPLE_UP,
        SIMPLE_PRESSED,
        SIMPLE_LONGPRESSED,

        DOUBLE_TAP,

        SWIPE,
        HORIZONTAL_SWIPE,
        VERTICAL_SWIPE
    }
    #endregion
}