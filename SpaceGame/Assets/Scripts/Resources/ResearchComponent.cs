using UnityEngine;

namespace Resources.Research
{
    public enum ResearchTier
    {
        Level1, Level2, Level3
    }

    public enum ResearchClass
    {
        TravelSpeed, Armour, Weapons, ProductionTools, ScientificEquipment, Civilisation
    }

    public class ResearchComponent
    {
        public ResearchClass ResearchClass;
        public ResearchTier ResearchTier;
        public int ScientistsResearching;
        public double TimeToResearchInMs;
        public bool IsComplete = false;

        public ResearchComponent(ResearchClass rc, ResearchTier rt, double timeToResearchms, int scientists = 0)
        {
            ResearchClass = rc;
            ResearchTier = rt;
            TimeToResearchInMs = timeToResearchms;
            ScientistsResearching = scientists;
        }

        public void AddScientist(int amount)
        {
            ScientistsResearching += amount;
            Debug.Log("Added Scientist");
        }
    }
}