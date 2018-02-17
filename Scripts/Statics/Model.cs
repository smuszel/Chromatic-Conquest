using UnityEngine;
using System;
using System.Collections.Generic;

public static class Model
{
    public static event Action<GameObject> HighlightWasChanged;
    private static GameObject _highlighted;

    public static GameObject CurrentlyHighlighted
    {
        get
        {
            return _highlighted;
        }
        set
        {
            _highlighted = value;
            HighlightWasChanged?.Invoke(value);
        }
    }

    private static CursorState _state;
    public static CursorState CurrentCursorState
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

    public static List<GameObject> PiecesAlive { get; set; }

    public static List<GameObject> TilesAvaible { get; set; }
    public static List<GameObject> TilesOccupied { get; set; }

    public static GameObject GetUnoccupiedTile()
    {
        return TilesAvaible[RandomIndex(TilesAvaible)];
    }

    private static int RandomIndex(List<GameObject> lst)
    {
        return Mathf.FloorToInt(UnityEngine.Random.value * lst.Count);
    }

    // public static void ShuffleList()
    // {
    //     Debug.Log("Shuffle NI");
    // }
}