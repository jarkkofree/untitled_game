using System.Collections.Generic;
using UnityEngine;

public class FlyTo
{
    private List<MapObject> _subordinates;
    private MapObject _destination;

    public void Execute()
    {
        _subordinates = SelectedMapObjects.GetSelectedFlyables();
        _destination = Target.GetTarget();
        foreach (MapObject ship in _subordinates)
        {
            if (ship.Flight != null)
                ship.Flight.SetFlyDestination(_destination.Transform.localPosition);
        }
    }

}
