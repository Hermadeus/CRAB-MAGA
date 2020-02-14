﻿using System.Collections;
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

        [Button]
        public void Raise()
        {
            VagueData vaguedata = new VagueData();
            for (int i = 0; i < unitsToInvoke.Count; i++)
            {
                 CrabsUnit newUnit = unitFactory.InstantiateCrabsUnit(unitsToInvoke[i].generalCrabData,
                    unitsToInvoke[i].followerToInvoke,
                    new Vector3(unitsToInvoke[i].position.x, 0, -i * offsetZApparition));

                newUnit.transform.parent = actionPhaseManager.Value.crabesParent;
                newUnit.leaderCrab.currentLine = lineEditorVariable.Value.GetLine(newUnit.leaderCrab.transform.position);

                vaguedata.crabUnits.Add(newUnit);
            }

            actionPhaseManager.Value.vagues.Insert(0, vaguedata);
        }

        [Button]
        public void StartWave(int vagueIndex)
        {
            for (int y = 0; y < actionPhaseManager.Value.vagues[vagueIndex].crabUnits.Count; y++)
            {
                actionPhaseManager.Value.vagues[vagueIndex].crabUnits[y].leaderCrab.IsMoving = true;
                for (int z = 0; z < actionPhaseManager.Value.vagues[vagueIndex].crabUnits[y].followers.Count; z++)
                {
                    actionPhaseManager.Value.vagues[vagueIndex].crabUnits[y].followers[z].IsMoving = true;
                }
            }

            unitsToInvoke.Clear();
        }

        //public void AddUnitToVague()
        //{
        //    AddUnitsToInvoke(new UnitToInvoke(generalCrab, generalCrab.followersMax, new Vector3(0, 0, 0)));
        //    AddUnitsToInvoke(new UnitToInvoke(generalCrab, generalCrab.followersMax, new Vector3(1, 0, 0)));
        //    AddUnitsToInvoke(new UnitToInvoke(generalCrab, generalCrab.followersMax, new Vector3(-1, 0, 0)));
        //    Raise();
        //}

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