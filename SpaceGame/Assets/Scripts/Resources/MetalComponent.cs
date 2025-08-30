using System;
using UnityEngine;

namespace Resources.PlanetResource
{
    public class MetalComponent
    {
        public double MetalAmount;

        public MetalComponent(double metalAmount)
        {
            MetalAmount = metalAmount;
        }

        public double AddMetal(double amount)
        {
            MetalAmount = Math.Max(0, MetalAmount += amount);
            return MetalAmount;
        }
    }
}