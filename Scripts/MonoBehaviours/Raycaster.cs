using UnityEngine;
using System;
using System.Linq;

public class Raycaster : MonoBehaviour 
{
    public float highlightTolerance = 5f;
    public static GameObject HighlightedObject { get; set; }
    public static Vector3 HighlightedPoint { get; set; }
    Ray ray;
    RaycastHit info;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out info);

        HighlightedPoint = info.point;

        if (info.collider?.gameObject.tag != "Pieces")
        {
            HighlightedObject = Model.GetClosestWithinTolerance(info.point, highlightTolerance);
        }
        else
        {
            HighlightedObject = info.collider?.gameObject;
        }
    }
}
