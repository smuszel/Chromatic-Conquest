// using UnityEngine;

// [CreateAssetMenu]
// public class WalkerStrategy : ScriptableObject
// {
//     public PieceArrivedEffect arrivedEffect;

//     [Range(0,400)]
//     public float speed = 100f;

//     public GameObject UpdateMovement(GameObject host, GameObject Destination)
//     {
//         // Walking functionality coulbe be decoupled from brain but for now it seems unnescessary
//         // host.GetComponent<Rigidbody>().velocity = (Destination.transform.position - host.transform.position).normalized * speed * Time.deltaTime;

//         if (Tools.AreSimilar(host.transform?.position, Destination?.transform.position))
//         {
//             arrivedEffect.Execute(host, Destination);
//             return GetDestination();
//         }
//         else
//         {
//             return Destination;
//         }
//     }

//     public GameObject GetDestination()
//     {
//         return Model.TileAvaible;
//     }
// }