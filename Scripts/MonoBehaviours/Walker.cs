using System;
using UnityEngine;

public class Walker : MonoBehaviour 
{
    [Range(0, 400)]
    public float speed = 100f;
    public PieceArrivedEffect arrivedEffect;
    public GameObject partSys;
    public SoundEffect getNoDestinationSound;
    public SoundEffect destructionSound;
    public CollisionEffect collisionEffect;
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
        Destination = GetDestination();

        if (Destination == null) Debug.LogWarning("Destination initialized improperly");
    }
	
	void FixedUpdate() 
	{
        Destination = UpdateMovement(gameObject, Destination);


        if (Destination == null)
        {
            rend.material.color = Color.black;
            getNoDestinationSound.Execute();
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.enabled = false;
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

    public GameObject UpdateMovement(GameObject host, GameObject Destination)
    {
        // Walking functionality coulbe be decoupled from brain but for now it seems unnescessary

        gameObject.GetComponent<Rigidbody>().velocity = (Destination.transform.position - gameObject.transform.position).normalized * speed * Time.deltaTime;
        if (Tools.AreSimilar(host.transform?.position, Destination?.transform.position))
        {
            arrivedEffect.Execute(host, Destination);
            return GetDestination();
        }
        else
        {
            return Destination;
        }
    }

    public GameObject GetDestination()
    {
        return Model.TileAvaible;
    }
}
