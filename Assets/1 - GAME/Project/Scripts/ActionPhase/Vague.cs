using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using Sirenix.OdinInspector;

namespace CRABMAGA {
    [CreateAssetMenu(menuName = "CRAB MAGA/Action Phase/Vague")]
    public class Vague : ScriptableWithDescription
    {
        public ICrabFactory unitFactory = default;

        [TableList(ShowIndexLabels = true, DrawScrollView = true)]
        public List<UnitToInvoke> unitsToInvoke = new List<UnitToInvoke>();

        public LeaderCrabData generalCrab = default;
        public ActionPhaseManagerVariable actionPhaseManager;
        public LineEditorVariable lineEditorVariable;

        public float offsetZApparition = 1f;

        public int invokeIndex = 0;

        VagueData currentVagueData = new VagueData();

        public CameraManagerVariable cameraManagerVariable = default;

        [Button]
        public void Raise()
        {
            if(unitsToInvoke == null)
            {
                Debug.LogError("Il n'y a pas d'unités invoquées !!! + Vague.Raise()");
                return;
            }


            CrabsUnit newUnit = unitFactory.InstantiateCrabsUnit(unitsToInvoke[invokeIndex].generalCrabData,
                unitsToInvoke[invokeIndex].followerToInvoke,
                new Vector3(unitsToInvoke[invokeIndex].position.x, 0, -invokeIndex * offsetZApparition));

            newUnit.transform.parent = actionPhaseManager.Value.crabesParent;
            newUnit.leaderCrab.currentLine = lineEditorVariable.Value.GetLine(newUnit.leaderCrab.transform.position);

            currentVagueData.crabUnits.Add(newUnit);
            actionPhaseManager.Value.currentVague = currentVagueData;
            actionPhaseManager.Value.SetIsControllableOfAllCrabsOfWave(currentVagueData);
            invokeIndex++;
        }

        [Button]
        public void StartWave(int vagueIndex)
        {
            if (unitsToInvoke == null)
            {
                Debug.LogError("Il n'y a pas d'unités invoquées !!! + Vague.StartWave()");
                return;
            }

            actionPhaseManager.Value.vagues.Insert(0, currentVagueData);

            for (int y = 0; y < actionPhaseManager.Value.vagues[vagueIndex].crabUnits.Count; y++)
            {
                actionPhaseManager.Value.vagues[vagueIndex].crabUnits[y].leaderCrab.IsMoving = true;
                for (int z = 0; z < actionPhaseManager.Value.vagues[vagueIndex].crabUnits[y].followers.Count; z++)
                {
                    actionPhaseManager.Value.vagues[vagueIndex].crabUnits[y].followers[z].IsMoving = true;
                }
            }

            currentVagueData = new VagueData();
            //cameraManagerVariable.Value.SetTargetOnWave(currentVagueData);

            invokeIndex = 0;
            unitsToInvoke.Clear();
        }

        public UnitToInvoke AddUnitsToInvoke(UnitToInvoke unitToInvoke)
        {
            unitsToInvoke.Add(unitToInvoke);
            return unitToInvoke;
        }

        public void OnDisable()
        {
            unitsToInvoke.Clear();
        }
    }

    [System.Serializable]
    public class VagueData
    {
        public List<CrabsUnit> crabUnits;

        public VagueData()
        {
            crabUnits = new List<CrabsUnit>();
        }

        public List<Crab> GetAllCrabs()
        {
            List<Crab> crabs = new List<Crab>();

            for (int i = 0; i < crabUnits.Count; i++)
            {
                for (int y = 0; y < crabUnits[i].followers.Count; y++)
                {
                    crabs.Add(crabUnits[i].followers[y]);
                }
                crabs.Add(crabUnits[i].leaderCrab);
            }

            return crabs;
        }
    }

    [System.Serializable]
    public class UnitToInvoke
    {
        public LeaderCrabData generalCrabData;
        public Vector3 position;
        public int followerToInvoke;

        public UnitToInvoke(LeaderCrabData generalCrabData, int followerToInvoke, Vector3 position)
        {
            this.generalCrabData = generalCrabData;
            this.followerToInvoke = followerToInvoke;
            this.position = position;
        }
    }
}