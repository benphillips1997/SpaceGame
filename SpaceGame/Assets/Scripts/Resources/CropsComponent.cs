using System;
using UnityEngine;

namespace Resources.PlanetResource
{
    public class CropsComponent
    {
        public double CropsAmount;

        public CropsComponent(double cropsAmount)
        {
            CropsAmount = cropsAmount;
        }
        public double AddCrops(double amount)
        {
            CropsAmount = Math.Max(0, CropsAmount += amount);
            return CropsAmount;
        }
    }
}