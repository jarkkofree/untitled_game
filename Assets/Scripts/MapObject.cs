using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapObject : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private bool _hasDock;
    [SerializeField] private bool _isPlayerOwned;
    [SerializeField] private MapObjectAttributes _objectAttributes;

    private TextMeshProUGUI _lable;
    private Transform _transform;

    public string Name => _name;
    public bool IsPlayerOwned => _isPlayerOwned;
    public Transform Transform => _transform;
    public float FlightSpeed => GetFlightSpeed();
    public static Action<MapObject> OnStarted;

    void Start()
    {
        _lable = GetComponentInChildren<TextMeshProUGUI>();
        _transform = transform;
        OnStarted?.Invoke(this);
    }

    private float GetFlightSpeed()
    {
        if (_objectAttributes == null)
            return 0;

        return _objectAttributes.FlightSpeed;
    }
}
