using System;
using UnityEngine;

namespace Resources.PlanetResources
{
    public class PlanetResourceComponent
    {
        public double WoodAmount;
        public double MetalAmount;
        public double CoalAmount;
        public double CropsAmount;

        public PlanetResourceComponent(double woodAmount, double metalAmount, double coalAmount, double cropsAmount)
        {
            WoodAmount = woodAmount;
            MetalAmount = metalAmount;
            CoalAmount = coalAmount;
            CropsAmount = cropsAmount;
        }
    }
}