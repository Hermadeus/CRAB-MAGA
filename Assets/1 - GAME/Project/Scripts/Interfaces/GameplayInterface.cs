using UnityEngine;

namespace CRABMAGA
{
    public interface IMovementBehaviour
    {
        void Move(Crab crab);
    }

    public interface IFollowMovementBehaviour
    {
        void Move(Crab crab);
    }
}
