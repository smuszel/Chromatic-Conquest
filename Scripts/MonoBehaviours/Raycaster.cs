using UnityEngine;
using System;

public class Raycaster : MonoBehaviour 
{
    public static event Action<GameObject> HighlightChanged;

    static GameObject _current;
    public static GameObject CurrentlyHighlighted
    {
        get
        {
            return _current;
        }
        set
        {
            if (_current?.GetHashCode() != value?.GetHashCode())
            {
                HighlightChanged?.Invoke(value);
            }
        }
    }
    Ray ray;
    RaycastHit info;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out info);

        CurrentlyHighlighted = info.collider?.gameObject;
    }
}
