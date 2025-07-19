using UnityEngine;

namespace Resources
{
    public class FoodComponent
    {
        public int NumberOfFood = 0;
        public int MaxNumberOfFood = 100;

        public float TimeSinceLastTick = 0;

        public void AddFood(int amount)
        {
            if ((TimeSinceLastTick + Time.deltaTime) >= 1)
            {
                NumberOfFood += amount;
                Debug.Log(NumberOfFood);
                TimeSinceLastTick = 0;
            }
            TimeSinceLastTick += Time.deltaTime;
        }
    }
}