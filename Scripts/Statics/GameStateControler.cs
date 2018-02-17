using UnityEngine;
using System.Collections.Generic;

public static class GameStateControler
{
    static GameStateControler()
    {
        Model.PiecesAlive = new List<GameObject>();
        Model.TilesAvaible = new List<GameObject>();
        Model.TilesOccupied = new List<GameObject>();

        foreach (GameObject piece in GameObject.FindGameObjectsWithTag("Pieces"))
        {
            Model.PiecesAlive.Add(piece);
        }
    
        foreach (GameObject tile in GameObject.FindGameObjectsWithTag("Tiles"))
        {
            Model.TilesAvaible.Add(tile);
        }
    }

    public static void Activate()
    {
        // Apparently must reference the class in order to call static constructor
    }

    public static void RemovePiece(GameObject piece)
    {
        Model.PiecesAlive.Remove(piece);
        CheckWinCondition();
    }

    public static void MarkTileUnoccupied(GameObject tile)
    {
        Model.TilesAvaible.Remove(tile);
        Model.TilesOccupied.Add(tile);
        CheckLooseCondition();
    }

    public static void CheckLooseCondition()
    {
        if (Model.TilesAvaible.Count < 2)
        {
            Debug.Log("LOST");
        }

    }
    public static void CheckWinCondition()
    {
        if (Model.PiecesAlive.Count < 2)
        {
            Debug.Log("WIN");
        }
    }
}