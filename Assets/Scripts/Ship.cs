using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private ShipAttributes attributes;

    private float _speed;

    public float Speed => _speed;

    private void Start()
    {
        _speed = attributes.speed;
    }
}