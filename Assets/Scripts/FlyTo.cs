using System.Collections.Generic;
using UnityEngine;

public class FlyTo
{
    private List<MapObject> _subordinates;
    private Vector3 _destination;

    public void Execute()
    {
        _subordinates = SelectedMapObjects.GetSelectedFlyables();
        _destination = Target.GetTarget().Transform.localPosition;
        foreach (MapObject ship in _subordinates)
        {
            if (ship.Flight != null)
                ship.Pilot.AddDestination(_destination);
        }
    }

}
