using UnityEngine;

using System.Collections.Generic;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    public class CrabsUnit : SerializedMonoBehaviour, ICrabUnit
    {
        public LeaderCrab generalCrab = default;
        public List<CrabFollower> followers = new List<CrabFollower>();

        public Transform crabFollowerParent;

        public void Init()
        {
            throw new System.NotImplementedException();
        }
    }
}
