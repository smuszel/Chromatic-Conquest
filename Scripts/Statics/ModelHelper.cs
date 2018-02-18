using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

[CreateAssetMenu]
public class ModelHelper : ScriptableObject
{

    public SoundEffect destructionSound;

    public static string resourceName = "model_helper";

    private static bool _isInstantiated = false;
    private static ModelHelper _instance;
    public static ModelHelper Instance
    {
        get
        {

            if (_isInstantiated)
            {
                return _instance;
            }
            else
            {
                _instance = Resources.Load(resourceName) as ModelHelper;
                _isInstantiated = true;
                return _instance;
            }
        }
    }

    public void Reassemble()
    {
        Model._piecesAlive = new List<GameObject>();
        Model._tiles = new List<GameObject>();

        foreach (GameObject piece in GameObject.FindGameObjectsWithTag("Pieces"))
        {
            Model._piecesAlive.Add(piece);
        }

        foreach (GameObject tile in GameObject.FindGameObjectsWithTag("Tiles"))
        {
            Model._tiles.Add(tile);
        }

        Model._colorPool = new List<Color>();
        Model._colorPool.Add(Color.red);
        Model._colorPool.Add(Color.blue);
        Model._colorPool.Add(Color.green);
        Model._colorPool.Add(Color.magenta);
    }

    public void Construct()
    {
        Reassemble();
        RandomizeColors();
    }

    void RandomizeColors()
    {
        foreach (GameObject tile in Model._tiles)
        {
            tile.GetComponent<Renderer>().material.color = Model.RandomColor;
        }
    }
}