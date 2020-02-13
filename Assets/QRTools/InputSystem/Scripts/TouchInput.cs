using UnityEngine;
using UnityEngine.Events;

using QRTools.Variables;

using Sirenix.OdinInspector;

namespace QRTools.Inputs
{
    [CreateAssetMenu(fileName = "New Touch", menuName = "QRTools/Input/Touch", order = 20)]
    public class TouchInput : InputAction
    {
        #region Properties & Variables
        [SerializeField, EnumPaging] private TouchState touchType = default;
        public UnityEvent onInput = new UnityEvent();

        [Tooltip("Delay between two click if DOUBLE_TAP"), ShowIf("touchType", TouchState.DOUBLE_TAP)]
        public float doubleClickTime = .2f;
        private float lastClickTime = .2f;

        [Title("Other events")]
        public UnityEvent onTouchEnter = new UnityEvent();
        public UnityEvent onTouchStay = new UnityEvent();
        public UnityEvent onTouchEnd = new UnityEvent();

        #region LongTouch
        [Tooltip("Delay between two click if SIMPLE_LONGPRESSED"), ShowIf("touchType", TouchState.SIMPLE_LONGPRESSED)]
        public float longPressedTime = .5f;
        [HideInInspector] public float longPressedTimer;
        #endregion

        #region Swipping
        [ShowIf("touchType", TouchState.HORIZONTAL_SWIPE)]
        public UnityEvent onSwipeRight = new UnityEvent();
        [ShowIf("touchType", TouchState.HORIZONTAL_SWIPE)]
        public UnityEvent onSwipeLeft = new UnityEvent();

        [ShowIf("touchType", TouchState.VERTICAL_SWIPE)]
        public UnityEvent onSwipeUp = new UnityEvent();
        [ShowIf("touchType", TouchState.VERTICAL_SWIPE)]
        public UnityEvent onSwipeDown = new UnityEvent();


        [Tooltip("Distance to run with your finger to activate the input")]
        public float swipeDistanceThresold = 50f;

        bool asSwipe = false;
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

        public Vector2 InputEnterPosition { get; private set; }
        public Vector2 InputExitPosition { get; private set; }

        public Vector2 InputCurrentPosition { get; private set; }
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
                case TouchState.SIMPLE:
                    PlayCurrentInput += SimpleTouch;
                    break;
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

        public void DebugPosition()
        {
            Debug.Log("EnterPosition = " + InputEnterPosition);
            Debug.Log("ExitPosition = " + InputExitPosition);
        }
        #endregion

        #region Delegate Methods
        void RemoveDelegate()
        {
            PlayCurrentInput = null;
        }

        void SimpleTouch() => Simple();
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
                        onTouchEnter?.Invoke();
                        InputEnterPosition = touch.position;
                        break;
                    case TouchPhase.Moved:
                        onTouchStay?.Invoke();

                        if (asSwipe) return;
                        endPos = touch.position;
                        AnalyseGesture(startPos, endPos, state);
                        break;
                    case TouchPhase.Ended:
                        asSwipe = false;
                        onTouchEnd?.Invoke();
                        InputExitPosition = touch.position;
                        break;
                }
            }
        }

        void AnalyseGesture(Vector2 start, Vector2 end, TouchState state)
        {
            if(Vector2.Distance(start, end) > swipeDistanceThresold)
            {
                asSwipe = true;
                onInput?.Invoke();

                switch (state)
                {
                    case TouchState.VERTICAL_SWIPE:
                        if (start.y < end.y)
                            onSwipeUp?.Invoke();
                        else if (start.y > end.y)
                            onSwipeDown?.Invoke();
                        break;

                    case TouchState.HORIZONTAL_SWIPE:
                        if (start.x < end.x)
                            onSwipeRight?.Invoke();
                        else if (start.x > end.x)
                            onSwipeLeft?.Invoke();
                        break;
                }
            }
        }

        void LongTap()
        {
            if (Input.touchCount == 1)
            {
                touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        longPressedTimer = longPressedTime;
                        onTouchEnter?.Invoke();
                        InputEnterPosition = touch.position;
                        asTouch = true;
                        break;
                    case TouchPhase.Stationary:
                        longPressedTimer -= Time.deltaTime;

                        if (longPressedTimer > 0)
                            onTouchStay?.Invoke();

                        if (longPressedTimer <= 0 && asTouch)
                        {
                            onInput?.Invoke();
                            asTouch = false;
                        }
                        break;
                    case TouchPhase.Ended:
                        onTouchEnd?.Invoke();
                        InputExitPosition = touch.position;
                        break;
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
                    onInput?.Invoke();
                    InputEnterPosition = touch.position;
                    InputExitPosition = touch.position;
                }

                lastClickTime = Time.time;
            }
        }

        void Simple()
        {
            if (Input.touchCount == 1)
            {
                touch = Input.GetTouch(0);    

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        onInput?.Invoke();
                        onTouchEnter?.Invoke();
                        InputEnterPosition = touch.position;
                        break;
                    case TouchPhase.Moved:
                        onTouchStay?.Invoke();
                        InputCurrentPosition = touch.position;
                        break;
                    case TouchPhase.Stationary:
                        onTouchStay?.Invoke();
                        InputCurrentPosition = touch.position;
                        break;
                    case TouchPhase.Ended:
                        onTouchEnd?.Invoke();
                        InputExitPosition = touch.position;
                        break;
                    case TouchPhase.Canceled:
                        break;
                }
            }
        }

        void SimpleTouch(TouchPhase phase)
        {
            if (Input.touchCount == 1)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == phase)
                {
                    onInput?.Invoke();
                    InputEnterPosition = touch.position;
                    InputExitPosition = touch.position;
                }
            }
        }
        #endregion
    }

    #region Enums
    public enum TouchState
    {
        SIMPLE,
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
