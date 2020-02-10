using UnityEngine;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    public class CrabsUnit : SerializedMonoBehaviour, ICrabUnit
    {
        public ICrabFactory crabUnityFactory = default;

        public GeneralCrab leader = default;

        public void Init()
        {
            InstantiateGeneral();
        }

        public void InstantiateGeneral()
        {
            crabUnityFactory.InstantiateCrab(leader.generalCrabData.generalCrabPrefab, transform.position, leader.generalCrabData.followersMax, leader.transform);
        }
    }
}
