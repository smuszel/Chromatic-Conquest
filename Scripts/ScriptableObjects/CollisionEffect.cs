using UnityEngine;

[CreateAssetMenu]
public class CollisionEffect : ScriptableObject
{
    public SoundEffect destructionSound;
    public void Execute(GameObject first, GameObject second)
    {
        if (Tools.AreSimilar(first.GetComponent<Renderer>().material, second.GetComponent<Renderer>().material))
        {
            destructionSound.Execute();
            Debug.Log("Desintegration NI");

            Destroy(first);
            Destroy(second);
        }
    }
}