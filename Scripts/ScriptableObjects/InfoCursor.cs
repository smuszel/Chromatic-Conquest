using UnityEngine;

[CreateAssetMenu]
public class InfoCursor : CursorState
{
    public override void Execute(GameObject go)
    {
        Debug.Log($"This is {go.name}");
        base.Execute(go);
    }
}