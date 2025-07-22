using Arch.Core;
using Arch.Core.Extensions;
using Resources.Research;
using UnityEngine;

namespace Population.Military
{
    public class MilitaryComponent
    {
        public int SoldierCount;
        public ResearchTier PowerLevel;
        public ResearchTier DefenceLevel;
        public bool BattleActive = false;
        public double TimeToNextBattleUpdate = 0;

        public MilitaryComponent(Entity power, Entity armour)
        {
            var powerResearchComp = power.Get<ResearchComponent>();
            var armourResearchComp = armour.Get<ResearchComponent>();

            if (powerResearchComp.ResearchClass != ResearchClass.Weapons || armourResearchComp.ResearchClass != ResearchClass.Armour)
            {
                Debug.LogError("Incorrect research class for military");
                return;
            }
            
            PowerLevel = powerResearchComp.ResearchTier;
            DefenceLevel = armourResearchComp.ResearchTier;
        }

        public void AddSoldier(int amount)
        {
            SoldierCount += amount;
            Debug.Log($"Added {amount} soldiers, Soldier count: {SoldierCount}");
        }

        public void RemoveSoldier(int amount)
        {
            SoldierCount -= amount;
            Debug.Log($"Removed {amount} soldiers, Soldier count: {SoldierCount}");
        }

        public void StartBattle()
        {
            BattleActive = true;
        }

        public void StopBattle()
        {
            BattleActive = false;
            TimeToNextBattleUpdate = 0;
        }

        public void UpdateBattle()
        {
            RemoveSoldier(1);
        }
    }
}