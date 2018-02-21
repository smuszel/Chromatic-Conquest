using System;
using UnityEngine;

public class MarkerHighlight : MonoBehaviour
{
    public ClickEffect clickEffect;
    public float highlightTolerance = 0.8f;
    Renderer rend;
    Light pointLight;

    GameObject _target;
    public GameObject MyTarget
    {
        get
        {
            return _target;
        }

        set
        {
            if (_target != null)
            {
                Unparalyze(_target);
            }

            if (value != null)
            {
                rend.enabled = true;
                pointLight.enabled = true;
                Paralyze(value);
            }
            else
            {
                rend.enabled = false;
                pointLight.enabled = false;
            }

            _target = value;
        }
    }

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        pointLight = gameObject.GetComponentInChildren<Light>();
        rend.enabled = false;
        pointLight.enabled = false;
    }

    void FixedUpdate()
    {
        MyTarget = GetRightTarget();

        if (MyTarget == null)
        {
            transform.position = Vector3.zero;
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            clickEffect.Execute(MyTarget);
        }
        else
        {
            transform.position = MyTarget.transform.position;
        }
    }

    GameObject GetRightTarget()
    {
        return Model.GetClosestPiece(Raycaster.info.point, highlightTolerance);
    }

    void Paralyze(GameObject go)
    {
        go.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    void Unparalyze(GameObject go)
    {
        go.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}