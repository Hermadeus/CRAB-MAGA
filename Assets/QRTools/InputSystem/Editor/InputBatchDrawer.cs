using UnityEngine;
using UnityEditor;
using QRTools.Functions.Editor;

namespace QRTools.Inputs
{
    [CustomEditor(typeof(InputActionBatch))]
    public class InputBatchDrawer : Editor
    {
        #region SerializedProperties
        SerializedProperty description;
        SerializedProperty inputActions;
        SerializedProperty isActive;
        #endregion

        Texture2D icon;
        Rect iconRect = default;
        const float ICON_SIZE = 120f;

        private void OnEnable()
        {
            icon = Resources.Load<Texture2D>("Textures/logoActionBatch");

            description = serializedObject.FindProperty("description");
            inputActions = serializedObject.FindProperty("inputActions");
            isActive = serializedObject.FindProperty("isActive");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorFunctions.DrawImage(iconRect, ICON_SIZE, icon);

            EditorGUILayout.PropertyField(description);
            EditorList.Show(inputActions, EditorListOption.All);
            EditorGUILayout.PropertyField(isActive);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
