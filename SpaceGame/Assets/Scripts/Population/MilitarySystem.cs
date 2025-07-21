using Arch.Core;
using Arch.Core.Extensions;
using Arch.Core.Utils;
using UnityEngine;

namespace Population.Military
{
    public class MilitarySystem : BaseSystem
    {
        private readonly QueryDescription _soldierAddEvents = new QueryDescription().WithAll<AddSoldierEvent>();
        private readonly QueryDescription _startBattle = new QueryDescription().WithAll<StartBattleRequest>();
        private readonly QueryDescription _stopBattle = new QueryDescription().WithAll<StopBattleRequest>();
        private readonly QueryDescription _military = new QueryDescription().WithAll<MilitaryComponent>();

        public MilitarySystem(World world) : base(world) { }

        public override void Update()
        {
            World.Query(in _soldierAddEvents, (Entity ent, ref AddSoldierEvent ev) =>
            {
                var comp = ev.Player.Get<MilitaryComponent>();
                comp.AddSoldier(1);
                World.Destroy(ent);
            });

            World.Query(in _military, (ref MilitaryComponent comp) =>
            {
                if (comp.BattleActive)
                {
                    if (comp.TimeToNextBattleUpdate - Time.deltaTime < 0)
                    {
                        Battle(comp);
                        comp.TimeToNextBattleUpdate = 1;
                    }

                    comp.TimeToNextBattleUpdate -= Time.deltaTime;
                }
            });

            World.Query(in _startBattle, (Entity ent, ref StartBattleRequest req) =>
            {
                StartBattle(req.Player);
                World.Destroy(ent);
            });

            World.Query(in _stopBattle, (Entity ent, ref StopBattleRequest req) =>
            {
                StopBattle(req.Player);
                World.Destroy(ent);
            });
        }       
        
        private void Battle(MilitaryComponent militaryComp)
        {
            if (militaryComp.SoldierCount > 0)
            {
                militaryComp.UpdateBattle();
            }
            else
            {
                militaryComp.StopBattle();
                Debug.Log($"Stopped battle due to not enough soldiers");
            }            
        }

        private void StartBattle(Entity player)
        {
            if (player.TryGet<MilitaryComponent>(out var militaryComp))
            {
                militaryComp.StartBattle();
                Debug.Log("Started battle");
            }
        }

        private void StopBattle(Entity player)
        {
            if (player.TryGet<MilitaryComponent>(out var militaryComp))
            {
                militaryComp.StopBattle();
                Debug.Log("Stopped battle");
            }
        }
    }
}