using UnityEngine;
using UnityEditor;
using QRTools.Functions.Editor;
using QRTools.Variables;

namespace QRTools.Inputs
{
    [CustomEditor(typeof(ButtonInput))]
    public class ButtonDrawer : Editor
    {
        #region SerializedProperties
        SerializedProperty description;
        SerializedProperty inputName;
        SerializedProperty isActive;
        SerializedProperty inputEvent;
        SerializedProperty inputType;
        SerializedProperty isPressed;
        SerializedProperty doubleClickTime;
        SerializedProperty boolVar;
        SerializedProperty multiclickTimer;
        #endregion

        Texture2D icon;
        Rect iconRect = default;
        const float ICON_SIZE = 120f;

        bool inGame = false;

        private void OnEnable()
        {
            icon = Resources.Load<Texture2D>("Textures/logoButton");

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
            inputType = serializedObject.FindProperty("inputType");
            isPressed = serializedObject.FindProperty("isPressed");
            doubleClickTime = serializedObject.FindProperty("doubleClickTime");
            boolVar = serializedObject.FindProperty("refBoolVariable");
            multiclickTimer = serializedObject.FindProperty("multiClickTime");
        }

        void DrawProperties()
        {
            EditorFunctions.DrawImage(iconRect, ICON_SIZE, icon);

            EditorGUILayout.PropertyField(description);
            EditorGUILayout.PropertyField(inputName);
            EditorGUILayout.PropertyField(inputType);
            EditorGUILayout.PropertyField(boolVar);

            if (inputType.enumValueIndex == 3)
                EditorGUILayout.PropertyField(doubleClickTime);

            if(inputType.enumValueIndex == 4)
                EditorGUILayout.PropertyField(multiclickTimer);

            EditorGUILayout.PropertyField(isActive);
            GameEventButton.DrawGameEventProperty(inputEvent, inGame);

            GUI.enabled = false;
            EditorGUILayout.PropertyField(isPressed);
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
            inputType.enumValueIndex = 0;
        }
    }
}
