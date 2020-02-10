using System.Collections.Generic;

using QRTools.Variables;

namespace CRABMAGA
{
    /// <summary>
    /// Pour le déplacement
    /// </summary>
    public interface IMovementBehaviour
    {
        DictionaryStringFloatVariable SpeedData { get; set; }
        void Move(Crab crab);
        void TurnRight(Crab crab);
        void TurnLeft(Crab crab);
    }

    /// <summary>
    /// Si l'entité doit suivre une autre
    /// </summary>
    /// <param name="crab"></param>
    public delegate void TurningMovement(Crab crab);
    public interface IFollowMovementBehaviour
    {
        TurningMovement TurningMovement { get; set; }
        Queue<float> NextMovementPosition { get; set; }
        Queue<TurningMovement> NextMovementAction { get; set; }
        /// <summary>
        /// précision de la position où le crabe tourne
        /// </summary>
        float Thickness { get; set; }

        void AddTurningActionRight();
        void AddTurningActionLeft();
    }

    public interface ICrabUnit
    {
        void Init();
    }
}
