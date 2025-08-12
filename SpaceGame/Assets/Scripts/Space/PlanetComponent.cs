using System;
using UnityEngine;

namespace Space.Planet
{
    public enum OccupiedByPlayer
    {
        FullyOccupied, PartiallyOccupied, NotOccupied
    }

    public class PlanetComponent
    {
        public OccupiedByPlayer OccupiedStatus;

        public PlanetComponent(OccupiedByPlayer occupied)
        {
            OccupiedStatus = occupied;
        }
    }
}