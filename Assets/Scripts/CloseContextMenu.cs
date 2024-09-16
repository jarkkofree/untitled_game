using System;
using UnityEngine;
using UnityEngine.UI;

public class CloseContextMenu : ContextMenuButton
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => {
            OnClick?.Invoke(this);
        });
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }
}
