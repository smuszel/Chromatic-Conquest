using UnityEngine;
using System;

public static class Model
{
    private static GameObject _highlighted;
    public static event Action<GameObject> HighlightWasChanged;

    public static GameObject Highlighted
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
}