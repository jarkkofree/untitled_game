using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenu : MonoBehaviour
{
    private static GameObject _contextMenu;

    private void Awake()
    {
        ContextMenuButton.OnClick += CloseMenu;
    }

    private void OnDestroy()
    {
        ContextMenuButton.OnClick -= CloseMenu;
    }

    private void CloseMenu(ContextMenuButton button)
    {
        if (_contextMenu != null)
        {
            _contextMenu.SetActive(false);
        }
    }

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
}
