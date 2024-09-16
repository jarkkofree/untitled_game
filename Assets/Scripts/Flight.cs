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

    private void Awake()
    {
        ContextMenuButton.OnClick += ContextButtonClicked;
    }

    private void Destroy()
    {
        ContextMenuButton.OnClick -= ContextButtonClicked;
    }

    private void ContextButtonClicked(ContextMenuButton button)
    {
        if (button is not FlyToCommand)
            return;

        var selection = SelectedMapObjects.GetSelectedFlyables();
        var target = Target.GetTarget();

        foreach (MapObject ship in selection)
        {
            if (!_flying.ContainsKey(ship))
                _flying.Add(ship, new Queue<Vector3>());

            _flying[ship].Enqueue(target.Transform.localPosition);
        }
    }

    void Start()
    {
        _transform = transform;
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
                (destination - flying.Key.Transform.localPosition).normalized * Time.deltaTime * flying.Key.FlightSpeed;
        }
    }
}