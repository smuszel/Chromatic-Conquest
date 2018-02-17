using System;
using UnityEngine;

public static class Tools 
{
    public static float edge = 8f;
    public static float tolerance = 0.05f;
    public static Vector3 GenerateDestination()
	{
        float x = Mathf.Floor(UnityEngine.Random.value * edge);
        float z = Mathf.Floor(UnityEngine.Random.value * edge);
        return new Vector3(x, 0, z);
    }

    public static bool AreSimilar(Vector3 first, Vector3 second)
    {
        float dx = first.x - second.x;
        float dz = first.z - second.z;

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

    public static void Swap<T> (ref T first, ref T second)
    {
        T temp = first;
        first = second;
        second = temp;
    }
}
