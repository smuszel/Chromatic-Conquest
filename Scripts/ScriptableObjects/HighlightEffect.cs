using UnityEngine;

[CreateAssetMenu]
public class HighlightEffect : ScriptableObject
{
    private static GameObject _frozenObject;
    public static GameObject FrozenObject
    {
        get
        {
            return _frozenObject;
        }
        set
        {
            UnFreeze(_frozenObject);
            Freeze(value);
            _frozenObject = value;
        }
    }

    public void Execute(GameObject target)
    {
        if (target.transform.position.y < 0.5)
        {
            FrozenObject = target;
        }
    }

    public static void Freeze(GameObject target)
    {
        if (target != null)
        {
            target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
        }
    }
    public static void UnFreeze(GameObject target)
    {
        if (target != null)
        {
            target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
