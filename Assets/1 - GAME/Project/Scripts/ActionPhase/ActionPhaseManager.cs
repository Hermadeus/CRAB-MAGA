using UnityEngine;
using UnityEngine.Events;

using System.Collections.Generic;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    public class ActionPhaseManager : SerializedMonoBehaviour
    {
        [BoxGroup("References")]
        public Transform crabesParent = default;
        [BoxGroup("References")]
        public ActionPhase actionPhase = default;

        [BoxGroup("Events")]
        public UnityEvent 
            onStart = new UnityEvent(),
            onExit = new UnityEvent();        


        [FoldoutGroup("Debugs")]
        public List<VagueData> vagues = new List<VagueData>();
        [ReadOnly, FoldoutGroup("Debugs")]
        public LeaderCrabData leaderCrabDataChoosen = default;

        [FoldoutGroup("Debugs")]
        [SerializeField] private List<CrabsUnit> allCrabUnits = new List<CrabsUnit>();
        [ReadOnly, FoldoutGroup("Debugs")]
        public VagueData currentVague = default;
        public List<CrabsUnit> AllCrabUnits
        {
            get
            {
                allCrabUnits = GetAllUnits();
                return allCrabUnits;
            }
        }

        private void Start()
        {
            InitializeActionPhase();
        }

        public void InitializeActionPhase()
        {
            actionPhase.StartPhase(this);
        }

        public void SetIsControllableOfAllCrabsOfWave(int waveIndex)
        {
            for (int i = 0; i < GetAllCrabs().Count; i++)
            {
                GetAllCrabs()[i].IsControllable = false;
            }
            for (int i = 0; i < GetAllCrabOfWave(waveIndex).Count; i++)
            {
                GetAllCrabOfWave(waveIndex)[i].IsControllable = true;
            }

            currentVague = vagues[waveIndex];
        }

        public void SetIsControllableOfAllCrabsOfWave(VagueData vague)
        {
            for (int i = 0; i < GetAllCrabs().Count; i++)
            {
                GetAllCrabs()[i].IsControllable = false;
            }
            for (int i = 0; i < vague.GetAllCrabs().Count; i++)
            {
                vague.GetAllCrabs()[i].IsControllable = true;
            }

            currentVague = vague;
        }

        public Vector3 GetPositionOfAWave(int waveIndex)
        {
            return vagues[waveIndex].crabUnits[0].leaderCrab.transform.position;
        }

        public List<Crab> GetAllCrabOfWave(int waveIndex)
        {
            return vagues[waveIndex].GetAllCrabs();
        }

        public List<CrabsUnit> GetAllUnits()
        {
            List<CrabsUnit> crabsUnits = new List<CrabsUnit>();
            for (int i = 0; i < vagues.Count; i++)
            {
                for (int y = 0; y < vagues[i].crabUnits.Count; y++)
                {
                    crabsUnits.Add(vagues[i].crabUnits[y]);
                }
            }
            return crabsUnits;
        }

        public List<Crab> GetAllCrabs()
        {
            List<Crab> allCrabs = new List<Crab>();
            for (int i = 0; i < AllCrabUnits.Count; i++)
            {
                for (int y = 0; y < allCrabUnits[i].followers.Count; y++)
                {
                    allCrabs.Add(allCrabUnits[i].followers[y]);
                }
                allCrabs.Add(allCrabUnits[i].leaderCrab);
            }
            return allCrabs;
        }
    }
}
