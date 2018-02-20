using System;
using UnityEngine;

public class MarkerHighlight : MonoBehaviour
{
    public ClickEffect clickEffect;
    public GameObject MyTarget { get; set; }
    Renderer rend;
    new Light light;

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        light = gameObject.GetComponentInChildren<Light>();
        rend.enabled = false;
        light.enabled = false;
    }

    void Update()
    {
        HighlightDecision(Raycaster.HighlightedObject);
        
        if (MyTarget != null && Input.GetButtonDown("Fire1"))
        {
            clickEffect.Execute(MyTarget);
            MyTarget = null;
        }
        else if (MyTarget != null)
        {
            transform.position = MyTarget.transform.position;
        }
    }

    private void HighlightDecision(GameObject target)
    {
        if (target == null)
        {
            rend.enabled = false;
            light.enabled = false;
            transform.position = Vector3.zero;
        }
        else if (target.tag == "Pieces")
        {
            MyTarget = target;
            rend.enabled = true;
            light.enabled = true;
            gameObject.transform.position = target.transform.position;
        }
        else
        {
            rend.enabled = false;
            light.enabled = false;
        }
    }
}