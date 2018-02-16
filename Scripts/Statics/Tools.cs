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
}
