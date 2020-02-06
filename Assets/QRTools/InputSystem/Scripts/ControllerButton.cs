using UnityEngine.Events;
using UnityEngine;

namespace QRTools.Inputs {
    [CreateAssetMenu(fileName = "New key", menuName ="QRTools/Input/Controller Key", order = 5)]
    public class ControllerButton: InputAction
    {
        public KeyCode key;
        public OnRaise onRaise = new OnRaise();
        public bool isPressed = true;

        public override void Execute()
        {
            if (!isActive)
                return;

            if (Input.GetKeyDown(key))
            {
                onRaise.Invoke();
                isPressed = true;
            }
            else
                isPressed = false;
        }

        public override void Init()
        {
            
        }

        public void Remap(KeyCode newKey)
        {
            key = newKey;
        }
    }

    public class OnRaise : UnityEvent { }
}
