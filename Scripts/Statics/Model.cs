using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

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

    public static Color? MajorColor
    {
        get
        {
            var pieceColors = _piecesAlive.Select(x => x.GetComponent<Renderer>().material.color);
            var dic = _colorPool.ToDictionary(color => color, color => HowManyMatches(pieceColors, color));

            var vals = dic.Values.ToList();
            var max = dic.Values.Max();
            vals.Remove(max);

            if (vals.Contains(max))
            {
                return null;
            }
            else
            {
                return dic.Where(z => z.Value == max).Select(q => q.Key).ToArray()[0];
            }          
            // var MajorList = dic.Where(x => x.Value == max).Select(y => y.Key).ToList();
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
    public static Vector3[] PiecePositions
    {
        get
        {
            return _piecesAlive.Select(p => p.transform.position).ToArray();
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
            var notBlack = _tiles.Where(t => !IsBlack(t));
            var honed = _piecesAlive.Select(p => p.GetComponent<Walker>().Destination);
            var avaible = notBlack.Except(honed);

            // Debug.Log($"Not black {notBlack.Count()} honed {honed.Count()} avaible {avaible}");

            if (avaible.Count() < 2)
            {
                return null;
            }

            return RandomElement(notBlack.Except(honed).ToList());
            // Debug.Log($"There are {_tilesAvaible.Count} in avaible, {_tilesClean.Count} in clean and {_tilesOccupied.Count} in occupied");
        }
    }

    public static int BlackCount
    {
        get
        {
            return _piecesAlive.Where(piece => IsBlack(piece)).ToList().Count;
        }
    }

    public static bool IsBlack(GameObject go)
    {
        return go.GetComponent<Renderer>().material.color == Color.black;
    }

    private static T RandomElement<T>(List<T> lst)
    {
        return lst[Mathf.FloorToInt(UnityEngine.Random.value * lst.Count)];
    }

    public static int HowManyMatches<T>(IEnumerable<T> lst, T target)
    {
        int c = 0;

        foreach (T element in lst)
        {
            if (element.Equals(target)) c++;
        }

        return c;
    }

    public static GameObject GetClosestPiece(Vector3 point, float tolerance)
    {
        if (_piecesAlive.FirstOrDefault() == null) return null;

        float[] distances = _piecesAlive.Select(p => Vector3.Distance(point, p.transform.position)).ToArray();
        int idx = Array.IndexOf(distances, distances.Min());

        if (distances.Min() < tolerance)
        {
            return _piecesAlive[idx];
        }
        else
        {
            return null;
        }
    }

    static Model()
    {
        Initialize();
        RandomizeColors();
    }

    static public void Initialize()
    {
        _piecesAlive = new List<GameObject>();
        _tiles = new List<GameObject>();

        foreach (GameObject piece in GameObject.FindGameObjectsWithTag("Pieces"))
        {
            _piecesAlive.Add(piece);
        }

        foreach (GameObject tile in GameObject.FindGameObjectsWithTag("Tiles"))
        {
            _tiles.Add(tile);
        }

        _colorPool = new List<Color>();
        _colorPool.Add(Color.red);
        _colorPool.Add(Color.blue);
        _colorPool.Add(Color.green);
        _colorPool.Add(Color.magenta);
    }

    static void RandomizeColors()
    {
        foreach (GameObject tile in _tiles)
        {
            tile.GetComponent<Renderer>().material.color = RandomColor;
        }

        foreach (GameObject piece in _piecesAlive)
        {
            piece.GetComponent<Renderer>().material.color = RandomColor;
        }
    }

    public static void Poke()
    {}
}
