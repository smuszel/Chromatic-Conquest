using UnityEngine;

[CreateAssetMenu]
public class CollisionEffect : ScriptableObject
{
    public SoundEffect collisionSound;
    public void Execute(Walker first, Walker second)
    {
        // Tools.Swap(ref first.Destination, ref second.Destination);
        // Tools.Swap(first.rend.material.color, second.rend.material.color);
    }
}