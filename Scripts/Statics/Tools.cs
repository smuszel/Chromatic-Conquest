using System;
using UnityEngine;

public static class Tools 
{
    public static float tolerance = 0.05f;

    public static bool AreSimilar(GameObject first, GameObject second)
    {
        return AreSimilar(first.GetComponent<Renderer>().material.color, second.GetComponent<Renderer>().material.color);
    }

    public static bool AreSimilar(Vector3? first, Vector3? second)
    {
        if (first == null || second == null) return false;

        float dx = Mathf.Abs((float)(first?.x - second?.x));
        float dz = Mathf.Abs((float)(first?.z - second?.z));

        return dx < tolerance && dz < tolerance;
    }

    public static bool AreSimilar(Material first, Material second)
    {
        return first.color.r == second.color.r && first.color.g == second.color.g && first.color.b == second.color.b;
    }
    public static bool AreSimilar(Color first, Color second)
    {
        return first.r == second.r && first.g == second.g && first.b == second.b;
    }
    public static bool AreSimilar(Color? first, Color? second)
    {
        if (first == null || second == null) return false;
        return first?.r == second?.r && first?.g == second?.g && first?.b == second?.b;
    }
}
