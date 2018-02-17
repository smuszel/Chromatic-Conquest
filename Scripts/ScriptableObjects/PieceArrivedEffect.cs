using UnityEngine;

[CreateAssetMenu]
public class PieceArrivedEffect : ScriptableObject
{
    public void Execute(GameObject piece, GameObject tile)
    {
        Color pieceColor = piece.GetComponent<Renderer>().material.color;
        Color tileColor = tile.GetComponent<Renderer>().material.color;

        if (Tools.AreSimilar(pieceColor, tileColor))
        {
            Debug.Log("tile matches the walker -  NI");
        }
        else
        {
            piece.GetComponent<Renderer>().material.color = tileColor;
            tile.GetComponent<Renderer>().material.color = Color.black;
            GameStateControler.MarkTileUnoccupied(tile);
        }
    }
}