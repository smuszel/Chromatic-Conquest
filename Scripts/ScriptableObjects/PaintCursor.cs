using UnityEngine;

[CreateAssetMenu]
public class PaintCursor : CursorState
{
    public Color paintColor;

    public override void Execute(GameObject go)
    {
        if (go.tag == "Pieces")
        {
            go.GetComponent<Renderer>().material.color = paintColor;
        }
        else
        {
        }

        base.Execute(go);
    }
}