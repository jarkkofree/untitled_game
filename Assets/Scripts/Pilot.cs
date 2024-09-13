using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pilot : MonoBehaviour
{
    private Queue<Vector3> _destinations = new();

    public void AddDestination(Vector3 destination)
    {
        _destinations.Enqueue(destination);
    }

    public Vector3 GetNextDestination()
    {
        return _destinations.Dequeue();
    }

    public bool HasNextDestination()
    {
        if (_destinations.Any())
        {
            return true;
        } else
        {
            return false;
        };
    }
}
