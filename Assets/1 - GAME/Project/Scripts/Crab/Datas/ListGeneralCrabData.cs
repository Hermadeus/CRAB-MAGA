using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEditor;

using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/Crabs/List des generaux")]
    public class ListGeneralCrabData : ScriptableWithDescription
    {
        [ListDrawerSettings(OnTitleBarGUI = "FindAll")]
        public List<GeneralCrabData> generals = new List<GeneralCrabData>();

#if UNITY_EDITOR
        public void FindAll()
        {
            if (SirenixEditorGUI.ToolbarButton(EditorIcons.Refresh))
            {
                generals.Clear();

                var paths = AssetDatabase.GetAllAssetPaths().ToList();
                for (int i = 0; i < paths.Count; i++)
                {
                    Object obj = AssetDatabase.LoadAssetAtPath<GeneralCrabData>(paths[i]);
                    if (obj is GeneralCrabData)
                        generals.Add(obj as GeneralCrabData);
                }
            }
        }
#endif

        [Button]
        public void Reset()
        {
            for (int i = 0; i < generals.Count; i++)
            {
                if (generals[i].generalCrabName == "Leader")
                    generals[i].isLock = false;

                generals[i].isLock = true;
            }
        }
    }
}