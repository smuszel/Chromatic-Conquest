using UnityEngine;
using System;
using System.Linq;

public class Raycaster : MonoBehaviour 
{
    Ray ray;
    public static RaycastHit info;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out info);
    }
}
