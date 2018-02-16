using UnityEngine;

public class Raycaster : MonoBehaviour 
{
    Ray ray;
    RaycastHit info;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out info);

		if (info.collider?.gameObject.GetHashCode() != Model.Highlighted?.GetHashCode())
		{
            Model.Highlighted = info.collider?.gameObject;
        }
    }
}
