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

        _contextMenu.SetActive(!_contextMenu.activeSelf);

        if (_contextMenu.activeSelf)
        {
            _contextMenu.transform.position = Input.mousePosition;
        }
    }
}
