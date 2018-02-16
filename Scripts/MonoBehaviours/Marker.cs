using UnityEngine;

public class Marker : MonoBehaviour
{
    public GameObject alwaysTarget;

    Renderer rend;

    void Start()
    {
        alwaysTarget = GameObject.FindGameObjectWithTag("Pieces");
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
        transform.position = alwaysTarget.transform.position;
    }

    void Relocate(GameObject target)
    {

        if (target == null)
        {
            rend.enabled = false;
        }
        else
        {
            alwaysTarget = target;
            rend.enabled = true;
            gameObject.transform.position = target.transform.position;
        }
    }
}