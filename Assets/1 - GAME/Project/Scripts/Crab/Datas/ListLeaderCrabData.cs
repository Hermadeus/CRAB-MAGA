using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEditor;

using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;

using QRTools.Functions;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/Crabs/Leader List")]
    public class ListLeaderCrabData : ScriptableWithDescription
    {
        [ListDrawerSettings(OnTitleBarGUI = "FindAll")]
        public List<LeaderCrabData> leadersDataList = new List<LeaderCrabData>();

#if UNITY_EDITOR
        public void FindAll()
        {
            if (SirenixEditorGUI.ToolbarButton(EditorIcons.Refresh))
            {
                leadersDataList.Clear();

                LeaderCrabData[] crabsData = Resources.FindObjectsOfTypeAll<LeaderCrabData>();

                FunctionsUseful.Adds(leadersDataList, crabsData);
            }
        }
#endif

        [Button]
        public void Reset()
        {
            for (int i = 0; i < leadersDataList.Count; i++)
            {
                if (leadersDataList[i].crabName.GetCurrentVersion(LanguageEnum.Instance) == "Leader")
                    leadersDataList[i].isLock = false;

                leadersDataList[i].isLock = true;
            }
        }
    }
}