using UnityEngine;
using System;
using System.Linq;

public class Raycaster : MonoBehaviour 
{
    public float highlightTolerance = 5f;
    static GameObject _current;
    public static GameObject CurrentlyHighlighted { get; set; }
    Ray ray;
    RaycastHit info;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out info);

        
        if (info.collider?.gameObject.tag != "Pieces")
        {
            CurrentlyHighlighted = Model.GetClosestWithinTolerance(info.point, highlightTolerance);
        }
        else
        {
            CurrentlyHighlighted = info.collider?.gameObject;
        } 
    }
}
