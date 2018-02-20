using UnityEngine;

public class SceneAttribute: PropertyAttribute
{
    public readonly string onEventName;
    
    public SceneAttribute(string _onEventName)
    {
        this.onEventName = _onEventName;
    }
}