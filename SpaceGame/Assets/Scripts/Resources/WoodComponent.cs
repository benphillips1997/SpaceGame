using System;
using UnityEngine;

namespace Resources.PlanetResource
{
    public class WoodComponent
    {
        public double WoodAmount;

        public WoodComponent(double woodAmount)
        {
            WoodAmount = woodAmount;
        }

        public double AddWood(double amount)
        {
            WoodAmount = Math.Max(0, WoodAmount += amount);
            return WoodAmount;
        }
    }
}