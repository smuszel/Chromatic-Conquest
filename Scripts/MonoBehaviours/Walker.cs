using System;
using UnityEngine;

public class Walker : MonoBehaviour 
{
    public GameObject partSys;
    public SoundEffect getNoDestinationSound;
    public SoundEffect destructionSound;
    public GameStateControler controler;
    public CollisionEffect collisionEffect;
    public PieceArrivedEffect arrivedEffect;
    public WalkerBrain walkerBrain;

    public GameObject Destination { get; set; }

    Rigidbody body;

    [HideInInspector]
    public Renderer rend;


    void Awake()
    {
        Model.Poke();
    }

    void Start() 
	{
        rend = gameObject.GetComponent<Renderer>();
        body = gameObject.GetComponent<Rigidbody>();
        NewDestination();
    }
	
	void FixedUpdate() 
	{
        HighlightDecision(Raycaster.CurrentlyHighlighted);

        if (Tools.AreSimilar(transform?.position, Destination?.transform.position))
        {
            arrivedEffect.Execute(gameObject, Destination);
            NewDestination();
        }

        walkerBrain.UpdateMovement(gameObject, Destination);
        controler.CheckLooseCondition();
    }

    void OnCollisionEnter(Collision other)
    {
        collisionEffect.Execute(this, other.collider.gameObject.GetComponent<Walker>());
    }

    void NewDestination()
    {
        Destination = walkerBrain.GetDestination();

        if (Destination == null)
        {
            rend.material.color = Color.black;
            getNoDestinationSound.Execute();
        }
    }

    public void HighlightDecision(GameObject go)
    {
        if (go == gameObject && transform.position.y < 0.5)
        {
            body.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
        }
        else
        {
            body.constraints = RigidbodyConstraints.None;
        }
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
        controler.RemovePiece(gameObject);
    }
}
