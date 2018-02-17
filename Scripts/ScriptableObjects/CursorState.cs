using UnityEngine;
using System;

public abstract class CursorState : ScriptableObject
{
    public Texture2D texture;
    public event Action<GameObject> PlaceholderEventName;

    public bool wasExecutionSuccesful = true;
    public virtual void Execute(GameObject go)
    {
        PlaceholderEventName?.Invoke(go);
    }
}