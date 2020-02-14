using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    public class LineEditor : MonoBehaviour
    {
        public Transform linesTransformParent;

        public List<Transform> lines = new List<Transform>();

        public int lineCount = 5;

        [Button]
        void AddNewLine()
        {
            Debug.Log("Ajout d'une line");
            GameObject go = new GameObject();
            go.transform.parent = linesTransformParent;
            lines.Add(go.transform);

            lines = lines.OrderBy((w) => w.transform.position.x).ToList();

            lines.First().SetAsFirstSibling();
            lines.First().name = "LineGauche";
            
            if (lines.Count > 2)
                for (int i = 1; i < lines.Count - 1; i++)
                {
                    lines[i].SetSiblingIndex(i);
                    lines[i].name = "line " + i.ToString();
                    float d = Vector3.Distance(lines.First().position, lines.Last().position);
                    Debug.LogError(d);
                    lines[i].position = new Vector3(
                        lines.First().position.x + (d / (1/3)),
                        0,
                        0
                        );
                }

            lines.Last().SetAsLastSibling();
            lines.Last().name = "LineDroite";
        }

        [Button]
        void RemoveLine()
        {
            Destroy(lines[lines.Count - 1]);
        }

        [Button]
        void ReorderLines()
        {
            lines.Clear();

            for (int i = 0; i < linesTransformParent.childCount; i++)
                lines.Add(linesTransformParent.GetChild(i));

            lines = lines.OrderBy((w) => w.transform.position.x).ToList();
        }

        public float NextPosition(int currentLine)
        {
            return lines[currentLine + 1].position.x;
        }

        public float GoToLine(int lineIndex)
        {
            return lines[lineIndex].position.x;
        }

        public float GetNextLine(int currentLine)
        {
            if (currentLine >= lines.Count)
                return lines[currentLine].position.x;
            else
                return NextPosition(currentLine);
        }

        public float PreviousPosition(int currentLine)
        {
            return lines[currentLine - 1].position.x;
        }

        public float GetPreviousLine(int currentLine)
        {
            if (currentLine <= 0)
                return lines[currentLine].position.x;
            else
                return PreviousPosition(currentLine);
        }

        public int GetLine(Vector3 position)
        {
            int x = 0;
            for (int i = 0; i < lines.Count; i++)
                if (lines[i].position.x == position.x)
                    x = i;

            return x;
        }

        public int GetLinePosition(Vector3 position)
        {
            position = new Vector3(Mathf.RoundToInt(position.x), 0, 0);

            int x = 0;
            for (int i = 0; i < lines.Count; i++)
                if (lines[i].position.x == position.x)
                    x = i;

            return (int)lines[x].position.x;
        }

        private void OnDrawGizmos()
        {
            //for (int i = 0; i < lines.Count; i++)
            //{
            //    Gizmos.color = Color.green;
            //    Gizmos.DrawLine(lines[i].position, lines[i].up * Mathf.Infinity);
            //}
        }
    }
}
