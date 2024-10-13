using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Flight : MonoBehaviour
{
    private Transform _transform;

    // TODO: Queue<Transform>
    private Dictionary<MapObject, Queue<Vector3>> _flying = new Dictionary<MapObject, Queue<Vector3>>();

    public Transform Transform => _transform;
    public static Action<Flight> OnStarted;

    public void Fly(List<MapObject> ships, MapObject target)
    {
        foreach (MapObject ship in ships)
        {
            if (ship.FlightSpeed == 0)
                continue;

            if (!_flying.ContainsKey(ship))
                _flying.Add(ship, new Queue<Vector3>());

            _flying[ship].Enqueue(target.Transform.localPosition);
        }
    }

    void Start()
    {
        _transform = transform;
        OnStarted?.Invoke(this);
    }

    void Update()
    {
        Dictionary<MapObject, Queue<Vector3>> nowFlying = new Dictionary<MapObject, Queue<Vector3>>(_flying);

        foreach (var flying  in nowFlying)
        {
            var destination = flying.Value.Peek();
            var distance = Vector3.Distance(destination, flying.Key.Transform.localPosition);

            if (distance < 1.0)
            {
                flying.Value.Dequeue();

                if (flying.Value.Count == 0)
                    _flying.Remove(flying.Key);
            }

            flying.Key.Transform.localPosition +=
                flying.Key.FlightSpeed * Time.deltaTime * (destination - flying.Key.Transform.localPosition).normalized;
        }
    }
}