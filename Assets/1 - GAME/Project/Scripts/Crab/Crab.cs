using UnityEngine;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    public class Crab : SerializedMonoBehaviour
    {
        /// <summary>
        /// IMovementBehaviour qui vient de la classe Crab - 
        /// Gère le mouvement du crab - 
        /// </summary>
        public IMovementBehaviour movementBehaviour = default;

        /// <summary>
        /// Line sur laquelle se situe le crab
        /// </summary>
        public int currentLine;

        /// <summary>
        /// Line editor (nom à changer)
        /// </summary>
        [HideInInspector] public LineEditor lineEditor;

        private void Start()
        {
            lineEditor = FindObjectOfType<LineEditor>();

            Init();
        }

        protected virtual void Init()
        {
            currentLine = lineEditor.GetLine(this.transform.position);
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
    }
}
