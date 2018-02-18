using UnityEngine;

public class MarkerHighlight : MonoBehaviour
{
    // public Effect clickEffect;
    public GameObject MyTarget { get; set; }

    Renderer rend;

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        rend.enabled = false;
    }

    void OnEnable()
    {
        Raycaster.HighlightChanged += Relocate;
    }

    void OnDisable()
    {
        Raycaster.HighlightChanged -= Relocate;
    }

    void Update()
    {
        if (MyTarget != null && Input.GetButtonDown("Fire1"))
        {
            // clickEffect.Execute(MyTarget);
            // MyTarget = null;
        }
        else if (MyTarget != null)
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
        else if (target.tag == "Pieces")
        {
            MyTarget = target;
            rend.enabled = true;
            gameObject.transform.position = target.transform.position;
        }
    }
}