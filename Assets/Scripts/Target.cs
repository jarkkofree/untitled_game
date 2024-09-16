using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private static MapObject _target;

    public static void SelectTarget(MapObject target)
    {
        _target = target;
        target.UITarget();
    }

    public static MapObject GetTarget()
    {
        return _target;
    }
}
