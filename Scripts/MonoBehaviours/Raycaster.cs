using UnityEngine;

public class Raycaster : MonoBehaviour 
{
    Ray ray;
    RaycastHit info;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out info);

		if (info.collider?.gameObject.GetHashCode() != Model.CurrentlyHighlighted?.GetHashCode())
		{
            Model.CurrentlyHighlighted = info.collider?.gameObject;
        }
    }

    void Awake()
    {
        GameStateControler.Activate();
    }
}
