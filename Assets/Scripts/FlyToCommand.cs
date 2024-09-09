using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyToCommand : MonoBehaviour
{
    private Button _button;
    private FlyTo _flyTo = new();

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(()=> 
        {
            _flyTo.Execute();
            ContextMenu.CloseContextMenu();
        });
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }
}
