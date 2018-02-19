using UnityEngine;

[CreateAssetMenu]
public class ClickEffect : ScriptableObject
{
    public SoundEffect destroySound;

    public void Execute(GameObject go)
    {
        if (Tools.AreSimilar(Model.MajorColor, go.GetComponent<Renderer>().material.color))
        {
            destroySound.Execute();
            go.GetComponent<Walker>()?.PreDestroy();
            Destroy(go);
        }
    }
}