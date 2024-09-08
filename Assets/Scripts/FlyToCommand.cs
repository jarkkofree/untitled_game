using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyToCommand : MonoBehaviour
{
    private Button _button;
    private List<MapObject> _subordinates;
    private MapObject _destination;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(FlyTo);
    }

    private void FlyTo()
    {
        _subordinates = SelectedMapObjects.GetSelectedPlayerOwnedShips();
        _destination = Target.GetTarget();
        foreach (MapObject ship in _subordinates)
        {
            
        }
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(FlyTo);
    }
}
