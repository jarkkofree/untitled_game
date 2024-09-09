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
    [SerializeField] private bool _canFly;
    [SerializeField] private bool _selected = false;

    private TextMeshProUGUI _lable;
    private Transform _transform;
    private Flight _flight;

    public Flight Flight => _flight;
    public string Name => _name;
    public bool IsPlayerOwned => _isPlayerOwned;
    public bool CanFly => _canFly;
    public Transform Transform => _transform;

    void Start()
    {
        _lable = GetComponentInChildren<TextMeshProUGUI>();
        _transform = transform;

        if (_canFly)
            _flight = _transform.AddComponent<Flight>();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            // Handle right-click
            Debug.Log("Right click detected");

            if (SelectedMapObjects.ShowFlyButton())
                ContextMenu.ShowContextMenu(_contextMenuPrefab, transform);
            
            Target.SelectTarget(this);
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Handle left-click
            Debug.Log("Left click detected");
            _selected = !_selected;
            if (_selected)
            {
                SelectedMapObjects.AddSelection(this);
            }
            else
            {
                SelectedMapObjects.RemoveSelection(this);
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
