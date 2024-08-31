using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _name;
    [SerializeField] private GameObject _contextMenuPrefab;
    [SerializeField] private bool _hasDock;
    [SerializeField] private bool _isPlayerOwned;
    [SerializeField] private bool _isShip;
    [SerializeField] private bool _selected = false;

    private TextMeshProUGUI _lable;

    public string Name => _name;
    public bool IsPlayerOwned => _isPlayerOwned;
    public bool IsShip => _isShip;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            // Handle right-click
            Debug.Log("Right click detected");

            if (SelectedMapObjects.AllSelectedPlayerOwnedShips())
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

    // Start is called before the first frame update
    void Start()
    {
        _lable = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
