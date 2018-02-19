using UnityEngine;

[CreateAssetMenu]
public class WalkerBrain : ScriptableObject
{
    [Range(0,400)]
    public float speed = 100f;

    public void UpdateMovement(GameObject host, GameObject Destination)
    {
        if (Destination == null)
        {
            host.GetComponent<Rigidbody>().velocity = Vector3.zero;
            return;
        }
        else
        {
            host.GetComponent<Rigidbody>().velocity = (Destination.transform.position - host.transform.position).normalized * speed * Time.deltaTime;
        }
    }

    public GameObject GetDestination()
    {
        return Model.TileAvaible;
    }

}