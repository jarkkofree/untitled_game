using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private List<MapObject> _ownedObjects = new();
    [SerializeField] private MapObject _AITarget;
    private Flight _flight;
    private bool _flying;

    private void Awake()
    {
        MapObject.OnStarted += MapObjectStarted;
        Flight.OnStarted += FlightStarted;
    }

    private void OnDestroy()
    {
        MapObject.OnStarted -= MapObjectStarted;
        Flight.OnStarted -= FlightStarted;
    }

    private void Update()
    {
        if (!_flying && _ownedObjects.Count > 0 && _flight != null)
        {
            _flying = true;
            _flight.Fly(_ownedObjects, _AITarget);
        }
    }

    private void FlightStarted(Flight flight)
    {
        _flight = flight;
    }

    private void MapObjectStarted(MapObject mapObject)
    {
        if (!mapObject.IsPlayerOwned)
        {
            _ownedObjects.Add(mapObject);
        }
    }
}
