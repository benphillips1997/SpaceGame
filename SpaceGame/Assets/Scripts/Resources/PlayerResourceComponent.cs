using System;
using UnityEngine;

namespace Resources.PlayerResources
{
    public class PlayerResourceComponent
    {
        public double WoodAmount;
        public double MetalAmount;
        public double CoalAmount;
        public double CropsAmount;
        public double TimeToNextUpdate = 0;

        public void AddWood(double amount)
        {
            WoodAmount += amount;
        }

        public void AddMetal(double amount) 
        { 
            MetalAmount += amount; 
        }

        public void AddCoal(double amount)
        {
            CoalAmount += amount;
        }

        public void AddCrops(double amount)
        {
            CropsAmount += amount;
        }
    }
}