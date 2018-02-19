using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CollisionEffect : ScriptableObject
{
    public SoundEffect collisionSound;

    public static Stack<KeyValuePair<string, string>> collisionHistory;

    void OnEnable()
    {
        collisionHistory = new Stack<KeyValuePair<string, string>>();
        collisionHistory.Push(new KeyValuePair<string, string>("x", "y"));
    }
    public void Execute(Walker first, Walker second)
    {
        if (first != null && second != null && !HasJustCollided(first.gameObject, second.gameObject))
        {
            if (second.rend.material.color == Color.black || first.rend.material.color == Color.black)
            {
                second.rend.material.color = Color.black;
                first.rend.material.color = Color.black;
                return;
            }
            
            var tempColor = second.rend.material.color;
            second.rend.material.color = first.rend.material.color;
            first.rend.material.color = tempColor;

            var tempDest = second.Destination;
            second.Destination = first.Destination;
            first.Destination = tempDest;

            collisionSound.Execute();
            collisionHistory.Push(new KeyValuePair<string, string>(first.gameObject.name, second.gameObject.name));
        }
    }

    public static bool HasJustCollided(GameObject first, GameObject second)
    {
        string firstOld = collisionHistory.Peek().Key;
        string secondOld = collisionHistory.Peek().Value;

        return (firstOld == first.name && secondOld == second.name) || (firstOld == second.name && secondOld == first.name);
    }
}