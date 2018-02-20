using UnityEngine;

[CreateAssetMenu]
public class PieceArrivedEffect: ScriptableObject
{
    public SoundEffect arrivalSound;
    public void Execute(GameObject piece, GameObject tile)
    {
        Color pieceColor = piece.GetComponent<Renderer>().material.color;
        Color tileColor = tile.GetComponent<Renderer>().material.color;
        if (Tools.AreSimilar(pieceColor, tileColor))
        {
            
        }
        else
        {
            piece.GetComponent<Renderer>().material.color = tileColor;
            tile.GetComponent<Renderer>().material.color = Color.black;
            arrivalSound.Execute();
        }
    }
}