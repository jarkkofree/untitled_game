using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private static MapObject _target;

    public static void SelectTarget(MapObject target)
    {
        if (_target != null)
        {
            _target.UIUntarget();
        }
        _target = target;
        target.UITarget();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
