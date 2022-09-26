using System.Linq;
using UnityEditor;
using UnityEngine;

public class RoadPlacer : Editor
{
    public static float n = 0f;
    [MenuItem("Tools/Set position")]
   public static void SetPosition()
    {
        var deeperSelection = Selection.transforms.SelectMany(transf => transf.GetComponents<Transform>()).Select(t => t.transform);
        n = -5f;
        foreach (Transform t in deeperSelection)
        {
            t.position = new Vector3(t.position.x, t.position.y, n);
            n += 5f;
        }
    }
}
