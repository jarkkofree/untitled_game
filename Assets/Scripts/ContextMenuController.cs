using UnityEngine;
using UnityEngine.EventSystems;

public class ContextMenuController : MonoBehaviour, IPointerClickHandler
{
    public GameObject ContextMenuPrefab;
    private GameObject _contextMenu;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            GameObject clickedObject = eventData.pointerPress;

            // if another object has been left-click selected (selection)
               // if selection is ship owned by player
                  // if right clicked object is a station
                     // then show additional context menu section to select command
                     // appropriate for ship-station interactions (dock, trade)
                  // else if right clicked object is ship
                     // then show additional context menu section to select command
                     // appropriate for ship-ship interactions (follow, attack, defend)
                  // else if right clicked object is field
                     // then show additional context menu section to select command
                     // appropriate for ship-field interactions (mine, prospect)
                  // ...

            if (_contextMenu == null)
            {
                _contextMenu = Instantiate(ContextMenuPrefab, transform);
            }

            _contextMenu.SetActive(!_contextMenu.activeSelf);

            if (_contextMenu.activeSelf)
            {
                _contextMenu.transform.position = Input.mousePosition;
            }
        }
    }

    void Update()
    {
        if (_contextMenu != null && _contextMenu.activeSelf)
        {
            if (Input.GetMouseButtonDown(0) && !RectTransformUtility.RectangleContainsScreenPoint(
                _contextMenu.GetComponent<RectTransform>(), Input.mousePosition, null))
            {
                _contextMenu.SetActive(false);
            }
        }
    }
}