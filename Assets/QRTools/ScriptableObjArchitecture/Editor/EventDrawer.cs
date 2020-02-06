using UnityEngine;
using UnityEditor;

namespace QRTools.Variables
{
    [CustomEditor(typeof(GameEvent))]
    public class EventDrawer : Editor
    {
        GameEvent myTarget;

        SerializedProperty description;

        bool inGame;

        private void OnEnable()
        {
            myTarget = (GameEvent)target;

            description = serializedObject.FindProperty("description");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(description);

            EditorList.Show(serializedObject.FindProperty("listeners"), EditorListOption.All);
            serializedObject.ApplyModifiedProperties();

            if (!myTarget.inGame)
                ButtonOff();
            else if (myTarget.inGame)
                ButtonOn();
        }

        void ButtonOff()
        {
            GUI.enabled = false;
            if (GUILayout.Button("Raise !"))
                myTarget.Raise();
        }

        void ButtonOn()
        {
            if (GUILayout.Button("Raise !"))
                myTarget.Raise();
        }
    }
}
