using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;
using UnityEditor;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "QRTools/Tests/Scriptable Object <StartCallback> Manager")]
public class ScriptableObjectManager : ScriptableObject
{
    public List<ScriptableObjectWithStartCallback> ScriptableObjectsWithStartCallback = new List<ScriptableObjectWithStartCallback>();

    List<string> paths = new List<string>();

    private void OnEnable()
    {
        InitSOWithStartCallback();

        MonoBehaviour m = FindObjectOfType<MonoBehaviour>();
        m.StartCoroutine(Start());
    }

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();

        for (int i = 0; i < ScriptableObjectsWithStartCallback.Count; i++)
            ScriptableObjectsWithStartCallback[i].Start();

        yield break;
    }

    [Button]
    void InitSOWithStartCallback()
    {
        ScriptableObjectsWithStartCallback.Clear();

        paths = AssetDatabase.GetAllAssetPaths().ToList();
        for (int i = 0; i < paths.Count; i++)
        {
            Object obj = AssetDatabase.LoadAssetAtPath<ScriptableObjectWithStartCallback>(paths[i]);
            if (obj is ScriptableObjectWithStartCallback)
                ScriptableObjectsWithStartCallback.Add(obj as ScriptableObjectWithStartCallback);
        }
    }
}
