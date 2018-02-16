using UnityEngine;

[CreateAssetMenu]
public class InfoCursor : CursorState
{
    public override bool Execute(GameObject go)
    {
        Debug.Log($"This is {go.name}");
        return base.Execute(go);
    }
}