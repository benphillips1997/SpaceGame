using System;
using UnityEngine;

namespace Resources.PlanetResource
{
    public class CoalComponent
    {
        public double CoalAmount;

        public CoalComponent(double coalAmount)
        {
            CoalAmount = coalAmount;
        }

        public double AddCoal(double amount)
        {
            CoalAmount = Math.Max(0, CoalAmount += amount);
            return CoalAmount;
        }
    }
}