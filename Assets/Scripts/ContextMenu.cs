using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenu : MonoBehaviour
{
    private static GameObject _contextMenu;

    public static void ShowContextMenu(GameObject ContextMenuPrefab, Transform transform)
    {
        if (_contextMenu == null)
        {
            _contextMenu = Instantiate(ContextMenuPrefab, transform);
        }
        else
        {
            _contextMenu.SetActive(true);
            _contextMenu.transform.SetParent(transform);
        }
        
        _contextMenu.transform.position = Input.mousePosition;
    }

    public static void CloseContextMenu()
    {
        if (_contextMenu != null)
        {
            _contextMenu.SetActive(false);
        }
    }
}
