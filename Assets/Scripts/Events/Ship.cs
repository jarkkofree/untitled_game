using System;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private Actor _commander;
    private Fly _fly;
    public event Action OnCommandComplete;

    private void Awake()
    {
        if (_commander != null)
            Debug.Log($"Listening for commands from {_commander.name}");
            _commander.OnFlyToCommand += FlyTo;
    }

    private void OnDestroy()
    {
        if (_commander != null)
            _commander.OnFlyToCommand -= FlyTo;
        
        if (_fly != null)
            _fly.OnDestinationReached -= DestinationReached;
    }

    private void FlyTo(Vector3 destination)
    {
        Debug.Log($"{this.name} got command to fly to {destination} from {_commander.name}");
        _fly = transform.gameObject.AddComponent<Fly>();
        _fly.SetDestination(destination);
        _fly.OnDestinationReached += DestinationReached;
    }

    private void DestinationReached()
    {
        Debug.Log("Ship is aware that destination has been reached");
        OnCommandComplete?.Invoke();
    }
}
