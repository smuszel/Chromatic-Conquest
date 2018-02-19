using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu]
public class GameStateControler: ScriptableObject
{
    public GameObject looseParticles;
    public SoundEffect winSound;
    public SoundEffect looseSound;
    public void RemovePiece(GameObject piece)
    {
        Model._piecesAlive.Remove(piece);
        CheckWinCondition();
    }

    public void CheckLooseCondition()
    {
        if (Model._piecesAlive.Count == Model.BlackCount)
        {
            Debug.Log(Model._piecesAlive.Count.ToString() + Model.BlackCount.ToString());
            looseSound.Execute();

            Instantiate(looseParticles);
            foreach (GameObject tile in Model._tiles)
            {
                Destroy(tile);
            }
            foreach (GameObject piece in Model._piecesAlive)
            {
                Destroy(piece);
            }
        }
    }
    public void CheckWinCondition()
    {
        if (Model.PieceCount < 1)
        {
            winSound.Execute();

            if (Model._tiles.FirstOrDefault() != null)
            {
                foreach (GameObject tile in Model._tiles)
                {
                    tile.GetComponent<Renderer>().material.color = Color.green;
                }
            }
        }
    }
}