using UnityEngine;

public class Marker : MonoBehaviour
{
    public GameObject MyTarget { get; set; }

    Renderer rend;

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        rend.enabled = false;
    }

    void OnEnable()
    {
        Model.HighlightWasChanged += Relocate;
    }

    void OnDisable()
    {
        Model.HighlightWasChanged -= Relocate;
    }

    void Update()
    {
        if (MyTarget != null)
        {
            transform.position = MyTarget.transform.position;
        }
    }

    void Relocate(GameObject target)
    {
        if (target == null)
        {
            rend.enabled = false;
            transform.position = Vector3.zero;
        }
        else
        {
            MyTarget = target;
            rend.enabled = true;
            gameObject.transform.position = target.transform.position;
        }
    }
}