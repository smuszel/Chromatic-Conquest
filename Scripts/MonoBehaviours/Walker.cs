using System;
using UnityEngine;

public class Walker : MonoBehaviour 
{
    public CollisionEffect collisionEffect;
    public PieceArrivedEffect arrivedEffect;
    public float speed = 30f;

    GameObject destination;

    Rigidbody body;

    void Start() 
	{
        body = gameObject.GetComponent<Rigidbody>();
        NewDestination();
    }
	
	void Update() 
	{
        
        if (Tools.AreSimilar(transform.position, destination.transform.position))
        {
            body.velocity = Vector3.zero;
            arrivedEffect.Execute(gameObject, destination);
            NewDestination();
        }

        UpdateMovement();
	}

    public void UpdateMovement()
    {
        body.velocity = (destination.transform.position - transform.position).normalized * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        collisionEffect.Execute(gameObject, other.collider.gameObject);
        NewDestination();
    }

    void OnCollisionStay(Collision other)
    {
        NewDestination();
    }

    void NewDestination()
    {
        destination = Model.GetUnoccupiedTile();
    }

    void OnDestroy()
    {
        // Debug.Log(gameObject);
        // Model.PiecesAlive.Remove(gameObject);
        GameStateControler.RemovePiece(gameObject);
    }
}
