using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _name;
    [SerializeField] private GameObject _contextMenuPrefab;
    [SerializeField] private bool _hasDock;
    [SerializeField] private bool _isPlayerOwned;
    [SerializeField] private bool _selected = false;
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            // Handle right-click
            Debug.Log("Right click detected");

            if (PlayerSelectedMapObjects.ShowFlyButton())
                ContextMenu.ShowContextMenu(_contextMenuPrefab, transform);
            
            PlayerTarget.SelectTarget(this);
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Handle left-click
            Debug.Log("Left click detected");
            _selected = !_selected;
            if (_selected)
            {
                PlayerSelectedMapObjects.AddSelection(this);
            }
            else
            {
                PlayerSelectedMapObjects.RemoveSelection(this);
            }
        }
    }

    public void UISelect()
    {
        _lable.text = "[" + _name + "]";
    }

    public void UIDeselct()
    {
        _lable.text = _name;
    }

    public void UITarget()
    {
        _lable.text = "<" + _name + ">";
    }

    public void UIUntarget()
    {
        _lable.text = _name;
    }
}
