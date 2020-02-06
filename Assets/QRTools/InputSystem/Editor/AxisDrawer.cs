using UnityEngine;
using UnityEditor;
using QRTools.Functions.Editor;
using QRTools.Variables;

namespace QRTools.Inputs
{
    [CustomEditor(typeof(AxisInput))]
    public class AxisDrawer : Editor
    {

        #region SerializedProperties
        SerializedProperty description;
        SerializedProperty inputName;
        SerializedProperty isActive;
        SerializedProperty inputEvent;
        SerializedProperty axisType;
        SerializedProperty value;
        SerializedProperty floatVariableRef;
        #endregion

        Texture2D icon;
        Rect iconRect = default;
        const float ICON_SIZE = 120f;

        bool inGame = false;

        private void OnEnable()
        {
            icon = Resources.Load<Texture2D>("Textures/logoAxis");

            InitProperties();

            EditorApplication.playModeStateChanged += ButtonChange;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawProperties();

            if (GUILayout.Button("RESET"))
            {
                Reset();
            }

            serializedObject.ApplyModifiedProperties();
        }

        void InitProperties()
        {
            description = serializedObject.FindProperty("description");
            inputName = serializedObject.FindProperty("inputName");
            isActive = serializedObject.FindProperty("isActive");
            inputEvent = serializedObject.FindProperty("inputEvent");
            axisType = serializedObject.FindProperty("axisType");
            value = serializedObject.FindProperty("value");
            floatVariableRef = serializedObject.FindProperty("floatVariableRef");
        }

        void DrawProperties()
        {
            EditorFunctions.DrawImage(iconRect, ICON_SIZE, icon);

            EditorGUILayout.PropertyField(description);
            EditorGUILayout.PropertyField(inputName);
            EditorGUILayout.PropertyField(axisType);
            EditorGUILayout.PropertyField(floatVariableRef);
            EditorGUILayout.PropertyField(isActive);
            GameEventButton.DrawGameEventProperty(inputEvent, inGame);

            GUI.enabled = false;
            EditorGUILayout.PropertyField(value);
            GUI.enabled = true;
        }

        public void ButtonChange(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.EnteredPlayMode)
                inGame = true;

            if (state == PlayModeStateChange.ExitingPlayMode)
                inGame = false;
        }

        void Reset()
        {
            if (inputName == null)
                return;

            inputName.stringValue = null;
            isActive.boolValue = true;
            inputEvent.objectReferenceValue = null;
            axisType.enumValueIndex = 0;
            floatVariableRef.objectReferenceValue = null;
        }
    }
}
