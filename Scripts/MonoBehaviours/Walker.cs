using System;
using UnityEngine;

public class Walker : MonoBehaviour 
{
    public float speed = 30f;

    Vector3 destination;

    Rigidbody body;

    Renderer rend;


    void Start() 
	{
        body = gameObject.GetComponent<Rigidbody>();
        rend = gameObject.GetComponent<Renderer>();

        destination = Tools.GenerateDestination();
    }
	
	void Update() 
	{
        
        if (Tools.AreSimilar(transform.position, destination))
        {
            body.velocity = Vector3.zero;
            // rend.material.color = Color.blue;
            destination = Tools.GenerateDestination();
        }
        UpdateMovement();
	}

    public void UpdateMovement()
    {
        body.velocity = (destination - transform.position).normalized * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        destination = Tools.GenerateDestination();
    }

    void OnCollisionStay(Collision other)
    {
        destination = Tools.GenerateDestination();
    }
}
