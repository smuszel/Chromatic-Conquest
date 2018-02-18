using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

[CreateAssetMenu]
public static class Model
{
    public static List<Color> _colorPool;

    public static Color RandomColor
    {
        get
        {
            return RandomElement<Color>(_colorPool);
        }
    }

    public static List<GameObject> _piecesAlive;
    public static int PieceCount
    {
        get
        {
            return _piecesAlive.Count;
        }
    }
    public static GameObject PieceAlive
    {
        get
        {
            return RandomElement(_piecesAlive);
        }
    }
    public static List<GameObject> _tiles;
    public static GameObject TileAvaible
    {
        get
        {
            var notBlack = _tiles.Where(t => IsUnoccupied(t));
            var honed = _piecesAlive.Select(p => p.GetComponent<Walker>().Destination);
            var avaible = notBlack.Except(honed);

            Debug.Log($"Not black {notBlack.Count()} honed {honed.Count()} avaible {avaible}");

            if (avaible.Count() < 2)
            {
                return null;
            }

            return RandomElement(notBlack.Except(honed).ToList());
            // Debug.Log($"There are {_tilesAvaible.Count} in avaible, {_tilesClean.Count} in clean and {_tilesOccupied.Count} in occupied");
        }
    }

    public static int UnoccupiedCount
    {
        get
        {
            return _tiles.Where(t => IsUnoccupied(t)).ToList().Count;
        }
    }

    public static bool IsUnoccupied(GameObject tile)
    {
        return tile.GetComponent<Renderer>().material.color != Color.black;
    }

    private static T RandomElement<T>(List<T> lst)
    {
        return lst[Mathf.FloorToInt(UnityEngine.Random.value * lst.Count)];
    }

    static Model()
    {
        ModelHelper.Instance.Construct();
    }

    // public static void ShuffleList()
    // {
    //     Debug.Log("Shuffle NI");
    // }

    // private static CursorState _state;
    // public static CursorState CurrentCursorState
    // {
    //     get
    //     {
    //         return _state;
    //     }

    //     set
    //     {
    //         Cursor.SetCursor(value?.texture, Vector2.zero, CursorMode.Auto);
    //         _state = value;
    //     }
    // }
}