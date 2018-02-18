using UnityEngine;
using System.Collections.Generic;

public static class GameStateControler
{
    public static void RemovePiece(GameObject piece)
    {
        Model._piecesAlive.Remove(piece);
        CheckWinCondition();
    }

    public static void CheckLooseCondition()
    {
        if (Model.UnoccupiedCount < 2)
        {
            Debug.Log("LOST");
        }

    }
    public static void CheckWinCondition()
    {
        if (Model.PieceCount < 2)
        {
            Debug.Log("WIN");
        }
    }
}