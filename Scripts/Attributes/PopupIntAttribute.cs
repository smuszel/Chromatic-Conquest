using UnityEngine;
using UnityEditor;

public class PopupIntAttribute: PropertyAttribute
{
    public readonly string flag;
    public readonly int start;
    public readonly int end;
    public PopupIntAttribute(string flag, int start, int end)
    {
        this.flag = flag;
        this.start = start;
        this.end = end;
    }
}