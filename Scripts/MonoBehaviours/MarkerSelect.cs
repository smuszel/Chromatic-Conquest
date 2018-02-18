// using System;
// using UnityEngine;

// public class MarkerSelect : MonoBehaviour
// {
//     public event Action<GameObject, GameObject> DoubleSelection;
//     GameObject _target;
//     public GameObject MyTarget
//     { 
//         get
//         {
//             return _target;
//         }
//         set
//         {
//             rend.enabled = true;
//             if (_target != null && value != null)
//             {
//                 Debug.Log("Double selection");
//                 // DoubleSelection?.Invoke(_target, value); OR SO
//             }
//             _target = value;
//         }

//     }

//     Renderer rend;

//     void Start()
//     {
//         rend = gameObject.GetComponent<Renderer>();
//         rend.enabled = false;
//     }
//     void Update()
//     {
//         var possibleTarget = Raycaster.CurrentlyHighlighted;

//         if (Input.GetButtonDown("Fire1") && possibleTarget.tag == "Pieces")
//         {
//             MyTarget = possibleTarget;
//         }

//         UpdateMovement();
//     }

//     private void UpdateMovement()
//     {
//         gameObject.transform.position = MyTarget.transform.position;
//     }
// }