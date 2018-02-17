using UnityEngine;

public class CursorControler : MonoBehaviour
{
    public CursorState state1;
    public CursorState state2;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Model.CurrentCursorState != null)
        {
            Model.CurrentCursorState.Execute(Model.CurrentlyHighlighted);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Model.CurrentCursorState = state1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Model.CurrentCursorState = state2;
        }
    }
}