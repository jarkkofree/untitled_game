using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectedMapObjects : MonoBehaviour
{
    private static List<MapObject> _selected = new();

    public static void AddSelection(MapObject mapObject)
    {
        if (!_selected.Contains(mapObject))
            _selected.Add(mapObject);
            mapObject.UISelect();

            foreach (MapObject selectedObject in _selected)
            {
                Debug.Log($"{selectedObject.Name}");
            }
    }

    public static void RemoveSelection(MapObject mapObject)
    {
        if (_selected.Contains(mapObject))
            _selected.Remove(mapObject);
            mapObject.UIDeselct();
        
            foreach (MapObject selectedObject in _selected)
            {
                Debug.Log($"{selectedObject.Name}");
            }
    }

    public static bool AllSelectedPlayerOwnedShips()
    {
        return _selected.All<MapObject>(obj => obj.IsPlayerOwned && obj.IsShip);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
