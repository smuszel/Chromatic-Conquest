using UnityEngine;
using System.Linq;

public class EndConditionObserver : MonoBehaviour
{
    public GameObject lostParticles;
    public SoundEffect winSound;
    public SoundEffect lostSound;

    void Update()
    {
        if (Model._piecesAlive.Count == Model.BlackCount)
        {
            Lose();
            Application.Quit();
            this.enabled = false;

        }
        else if (Model.PieceCount < 1)
        {
            Win();
            Application.Quit();
            this.enabled = false;
        }
    }
    
    public void Lose()
    {
        if (Model._piecesAlive.Count == Model.BlackCount)
        {
            Debug.Log(Model._piecesAlive.Count.ToString() + Model.BlackCount.ToString());
            lostSound.Execute();

            Instantiate(lostParticles);
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

    public void Win()
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