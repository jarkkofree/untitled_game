using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private Vector3 _destination;
    private Transform _transform;
    public event Action OnDestinationReached;

    public void SetDestination(Vector3 destination)
    {
        _destination = destination;
        Debug.Log($"Destination set to {destination}");
    }

    void Start()
    {
        _transform = transform;
        Debug.Log("fly component added, starting");
    }

    void Update()
    {
        if (_destination == null)
        {
            Debug.Log("No destination yet");
            return;
        }
        
        var distance = Vector3.Distance(_destination, _transform.localPosition);

        if (distance < 1.0)
        {
            Debug.Log("Destination reached");
            OnDestinationReached?.Invoke();
            Destroy(this);
        }
        
        _transform.localPosition +=
                10 * Time.deltaTime * (_destination - _transform.localPosition).normalized;
    }
}
