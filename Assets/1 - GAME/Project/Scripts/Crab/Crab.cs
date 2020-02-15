using UnityEngine;

using Sirenix.OdinInspector;

using QRTools.Variables;

using DG.Tweening;

namespace CRABMAGA
{
    public class Crab : SerializedMonoBehaviour
    {
        /// <summary>
        /// IMovementBehaviour qui vient de la classe Crab - 
        /// Gère le mouvement du crab - 
        /// </summary>
        public IMovementBehaviour movementBehaviour = default;

        public float Speed { get; set; }

        /// <summary>
        /// Line sur laquelle se situe le crab
        /// </summary>
        public int currentLine;

        /// <summary>
        /// Line editor (nom à changer)
        /// </summary>
        [HideInInspector] public LineEditor lineEditor;

        [SerializeField] private bool isMoving = false;
        public bool IsMoving { get => isMoving; set => isMoving = value; }

        [SerializeField] private bool isControllable = false;
        public bool IsControllable { get => isControllable; set => isControllable = value; }

        private void Start()
        {
            lineEditor = FindObjectOfType<LineEditor>();

            Init();
        }

        protected virtual void Init()
        {
            currentLine = lineEditor.GetLine(this.transform.position);
            SetSpeed("normal");
        }

        private void Update()
        {
            Execute();
        }

        protected virtual void Execute()
        {
            movementBehaviour.Move(this);
        }

        public void ResetPosition()
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                0
                );
        }

        public void SetSpeed(string state)
        {
            float newSpeed = movementBehaviour.SpeedData.GetValue(state);
            DOTween.To(() => Speed, x => Speed = x, newSpeed, 2);
        }
    }
}
