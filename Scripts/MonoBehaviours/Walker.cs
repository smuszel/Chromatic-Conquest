using System;
using UnityEngine;

public class Walker : MonoBehaviour 
{
    public CollisionEffect collisionEffect;
    public PieceArrivedEffect arrivedEffect;
    public float maxSpeed = 80f;

    [HideInInspector]
    public float speed = 0f;

    private bool freeze;

    private GameObject _destination;
    public GameObject Destination
    {
        get
        {
            return _destination;
        }
        set
        {
            if (value == null)
            {
                Destroy(gameObject);
            }
            _destination = value;
        }
    }
    public Renderer rend;

    Rigidbody body;

    void OnEnable()
    {
        Raycaster.HighlightChanged += ChangeHighlight;
    }

    void OnDisable()
    {
        Raycaster.HighlightChanged -= ChangeHighlight;
    }

    void Start() 
	{
        body = gameObject.GetComponent<Rigidbody>();
        rend = gameObject.GetComponent<Renderer>();
        NewDestination();
    }
	
	void FixedUpdate() 
	{
        // if (Input.GetKeyDown(KeyCode.Space))
        if (Tools.AreSimilar(transform.position, Destination.transform.position))
        {
            body.velocity = Vector3.zero;
            arrivedEffect.Execute(gameObject, Destination);
            NewDestination();
        }

        UpdateMovement();
	}

    public void UpdateMovement()
    {
        if (!freeze)
        {
            body.velocity = (Destination.transform.position - transform.position).normalized * speed * Time.deltaTime;
        }
        else
        {
            body.velocity = Vector3.zero;
        }
    }

    // void OnCollisionEnter(Collision other)
    // {
    //     collisionEffect.Execute(this, other.collider.gameObject.GetComponent<Walker>());
    // }

    // void OnCollisionStay(Collision other)
    // {
    //     NewDestination();
    // }

    void NewDestination()
    {
        Destination = Model.TileAvaible;
    }

    public void ChangeSpeed()
    {
        if (speed > 0)
        {
            speed -= 20;
        }
    }

    public void ChangeHighlight(GameObject go)
    {
        if (go == gameObject)
        {
            freeze = true;
        }
        else
        {
            freeze = false;
        }
    }

    void OnDestroy()
    {
        // Debug.Log(gameObject);
        // Model.PiecesAlive.Remove(gameObject);
        GameStateControler.RemovePiece(gameObject);
        // _destination.GetComponent<Tile>().Predator = null;
    }
}
