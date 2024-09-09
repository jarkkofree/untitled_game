using UnityEngine;
using UnityEngine.UI;

public class CloseContextMenu : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Close);
    }

    private void Close()
    {
        ContextMenu.CloseContextMenu();
        Target.DeselectTarget();
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(Close);
    }
}
