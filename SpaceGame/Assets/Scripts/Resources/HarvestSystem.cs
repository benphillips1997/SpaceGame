using Arch.Core;
using Arch.Core.Extensions;
using Space.Planet;
using Resources.Research;
using UnityEngine;

namespace Resources.PlanetResource
{
    public class HarvestSystem : BaseSystem
    {
        private readonly Entity _player;
        private readonly WoodComponent playerWood;
        private readonly MetalComponent playerMetal;
        private readonly CoalComponent playerCoal;
        private readonly CropsComponent playerCrops;

        private readonly QueryDescription _wood = new QueryDescription().WithAll<WoodComponent, PlanetComponent, HarvestComponent>();
        private readonly QueryDescription _metal = new QueryDescription().WithAll<MetalComponent, PlanetComponent, HarvestComponent>();
        private readonly QueryDescription _coal = new QueryDescription().WithAll<CoalComponent, PlanetComponent, HarvestComponent>();
        private readonly QueryDescription _crops = new QueryDescription().WithAll<CropsComponent, PlanetComponent, HarvestComponent>();
        private readonly QueryDescription _harvestablePlanets = new QueryDescription().WithAll<PlanetComponent, HarvestComponent>();

        public HarvestSystem(World world, Entity player) : base(world)
        {
            _player = player;
            playerWood = _player.Get<WoodComponent>();
            playerMetal = _player.Get<MetalComponent>();
            playerCoal = _player.Get<CoalComponent>();
            playerCrops = _player.Get<CropsComponent>();
        }

        public override void Update()
        {
            HarvestResources();
            UpdateHarvestableTimers();
        }

        private void HarvestResources()
        {
            World.Query(in _wood, (ref WoodComponent woodComp, ref PlanetComponent planet, ref HarvestComponent harvComp) =>
            {
                if (IsOccupied(planet))
                // Might be able to make an "Occupied" component which we attach to occupied planets. That way we filter them out before.
                // This might not be the logic we want though in some cases so for now let's leave it like this.
                {
                    if (harvComp.TimeSinceLastTick >= 1)
                    {
                        int divider = GetDivider(planet);

                        playerWood.AddWood(woodComp.WoodAmount / divider);
                        // Do planets lose the resources too? That's something we could consider adding here.

                        harvComp.TimeSinceLastTick = 0;
                    }
                }
            });

            World.Query(in _metal, (ref MetalComponent metalComp, ref PlanetComponent planet, ref HarvestComponent harvComp) =>
            {
                if (IsOccupied(planet))
                {
                    if (harvComp.TimeSinceLastTick >= 1)
                    {
                        int divider = GetDivider(planet);

                        playerMetal.AddMetal(metalComp.MetalAmount / divider);

                        harvComp.TimeSinceLastTick = 0;
                    }
                }
            });

            World.Query(in _coal, (ref CoalComponent coalComp, ref PlanetComponent planet, ref HarvestComponent harvComp) =>
            {
                if (IsOccupied(planet))
                {
                    if (harvComp.TimeSinceLastTick >= 1)
                    {
                        int divider = GetDivider(planet);

                        playerCoal.AddCoal(coalComp.CoalAmount / divider);

                        harvComp.TimeSinceLastTick = 0;
                    }
                }
            });

            World.Query(in _crops, (ref CropsComponent cropsComp, ref PlanetComponent planet, ref HarvestComponent harvComp) =>
            {
                if (IsOccupied(planet))
                {
                    if (harvComp.TimeSinceLastTick >= 1)
                    {
                        int divider = GetDivider(planet);

                        playerCrops.AddCrops(cropsComp.CropsAmount / divider);

                        harvComp.TimeSinceLastTick = 0;
                    }
                }
            });
        }

        private void UpdateHarvestableTimers()
        {
            World.Query(in _harvestablePlanets, (ref PlanetComponent planet, ref HarvestComponent harvComp) =>
            {
                harvComp.TimeSinceLastTick += Time.deltaTime;
            });
        }

        private bool IsOccupied(PlanetComponent planet)
        {
            return planet.OccupiedStatus != OccupiedByPlayer.NotOccupied;
        }

        private int GetDivider(PlanetComponent planet)
        {
            // If the planet is partialy occupied, we want to get half the resources.
            return planet.OccupiedStatus == OccupiedByPlayer.PartiallyOccupied ? 2 : 1;
        }
    }
}