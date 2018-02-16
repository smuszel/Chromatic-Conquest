using UnityEngine;
using System;

public abstract class CursorState : ScriptableObject
{
    public Texture2D texture;
    public event Action<GameObject> PlaceholderEventName;

    public bool wasExecutionSuccesful = true;
    public virtual bool Execute(GameObject go)
    {
        PlaceholderEventName?.Invoke(go);
        return wasExecutionSuccesful;
    }    

}