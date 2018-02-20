using System;
using UnityEngine;

public class Walker : MonoBehaviour 
{
    public GameObject partSys;
    public SoundEffect getNoDestinationSound;
    public SoundEffect destructionSound;
    public CollisionEffect collisionEffect;
    public WalkerStrategy strategy;
    public bool freezable = true;
    public GameObject Destination { get; set; }

    [HideInInspector]
    public Renderer rend;

    void Awake()
    {
        Model.Poke();
    }

    void Start() 
	{
        rend = gameObject.GetComponent<Renderer>();
        Destination = strategy.GetDestination();

        if (Destination == null) Debug.LogWarning("Destination initialized improperly");
    }
	
	void FixedUpdate() 
	{
        Destination = strategy.UpdateMovement(gameObject, Destination);

        if (Destination == null)
        {
            rend.material.color = Color.black;
            getNoDestinationSound.Execute();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        collisionEffect.Execute(this, other.collider.gameObject.GetComponent<Walker>());
    }

    public void PreDestroy()
    {
        var particles = Instantiate(partSys, transform.position, Quaternion.identity);

        var settings1 = particles.GetComponent<ParticleSystem>().main;
        var settings2 = particles.GetComponentInChildren<ParticleSystem>().main;

        settings1.startColor = rend.material.color;
        settings2.startColor = rend.material.color;

        //FRACTURE

        destructionSound.Execute();
    }

    void OnDestroy()
    {
        Model._piecesAlive.Remove(gameObject);
    }
}
