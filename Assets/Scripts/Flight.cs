using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Flight : MonoBehaviour
{
    private Transform _transform;
    private Vector3? _flyDestination;

    public Transform Transform => _transform;

    void Start()
    {
        _transform = transform;
    }

    void Update()
    {
        if (_flyDestination == null)
            return;

        _transform.localPosition += (_flyDestination.Value - transform.localPosition).normalized * Time.deltaTime * 10;

        var distance = Vector3.Distance(_transform.localPosition, _flyDestination.Value);
        if (distance < 1.0)
            _flyDestination = null;
    }
    public void SetFlyDestination(Vector3 destination)
    {
        _flyDestination = destination;
    }

    public bool HasFlyDestination()
    {
        return _flyDestination != null;
    }
}