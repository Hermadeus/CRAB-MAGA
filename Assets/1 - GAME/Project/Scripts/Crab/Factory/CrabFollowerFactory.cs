using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/Factory/Crab Follower Factory")]
    public class CrabFollowerFactory : ScriptableWithDescription, ICrabFactory
    {
        public CrabsUnit InstantiateCrabsUnit(LeaderCrabData general, int quantiteFollower, Vector3 position)
        {
            throw new System.NotImplementedException();
        }

        public List<CrabFollower> InstantiateFollowers(LeaderCrabData general, int quantiteFollower, Vector3 position, Transform parent)
        {
            throw new System.NotImplementedException();
        }

        public LeaderCrab InstantiateGeneralCrab(LeaderCrabData general, CrabsUnit unit, Vector3 position)
        {
            throw new System.NotImplementedException();
        }
    }
}
