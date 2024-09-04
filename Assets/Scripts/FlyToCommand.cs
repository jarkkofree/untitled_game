using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyToCommand : MonoBehaviour
{
    [SerializeField] private Button _button;
    
    void Awake()
    {
        _button.onClick.AddListener(HandleButtonPress);
    }

    void HandleButtonPress()
    {
        Debug.Log("Fly To command issued");
    }
}
