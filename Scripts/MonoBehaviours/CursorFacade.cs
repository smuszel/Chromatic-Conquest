using UnityEngine;

public class CursorFacade : MonoBehaviour
{
    // My job is to store cursor state + make it do something to highlighted when fire is called

    public CursorState state1;
    public CursorState state2;
    private CursorState _state;
    public CursorState State 
    { 
        get
        {
            return _state;
        }
    
        set
        {
            Cursor.SetCursor(value?.texture, Vector2.zero, CursorMode.Auto);
            _state = value;
        }
    }

    void Start()
    {
        State = null;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && State != null)
        {
            if (State.Execute(Model.Highlighted))
            {
                State = null;
            }
            else
            {
                Debug.Log("INVALID CLICK!");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            State = state1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            State = state2;
        }
    }
}