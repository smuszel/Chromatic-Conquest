using UnityEngine;

[CreateAssetMenu]
public class PaintCursor : CursorState
{
    public Color paintColor;

    public override bool Execute(GameObject go)
    {
        if (go.tag == "Pieces")
        {
            go.GetComponent<Renderer>().material.color = paintColor;
            wasExecutionSuccesful = true;
        }
        else
        {
            wasExecutionSuccesful = false;
        }

        return base.Execute(go);
    }
}