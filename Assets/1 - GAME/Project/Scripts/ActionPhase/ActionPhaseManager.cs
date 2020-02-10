using UnityEngine;
using UnityEngine.Events;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    public class ActionPhaseManager : SerializedMonoBehaviour, ICrabUnitFactory
    {
        public UnityEvent onStart = new UnityEvent();
        public UnityEvent onExit = new UnityEvent();

        public ICrabFactory crabUnity = default;
        public Transform parent;

        public GeneralCrabData generalData = default;

        private void Start()
        {
            InitializeActionPhase();
        }

        public void InitializeActionPhase()
        {
            crabUnity.InstantiateCrab(generalData.generalCrabPrefab, transform.position, null, null);
        }

        public CrabsUnit InstantiateCrabsUnit(Crab general, Crab follower, int quantiteFollower, Vector3 position)
        {
            throw new System.NotImplementedException();
        }
    }
}
