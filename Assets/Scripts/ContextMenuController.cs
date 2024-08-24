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