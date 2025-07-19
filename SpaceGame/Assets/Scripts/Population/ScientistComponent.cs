using UnityEngine;

namespace Population.Scientist
{
    public class ScientistComponent
    {
        public int ScientistCount;

        public void AddScientist(int amount)
        {
            ScientistCount += amount;
            Debug.Log(ScientistCount);
        }
    }
}