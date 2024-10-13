using UnityEngine;
using System;

public class Actor : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private Ship _commanding;
    public Ship Commanding => _commanding;
    public event Action<Vector3> OnFlyToCommand;

    public void FlyToCommand(Vector3 destination)
    {
        OnFlyToCommand?.Invoke(destination);
    }
}
