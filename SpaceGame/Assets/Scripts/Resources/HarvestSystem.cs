using Arch.Core;
using Arch.Core.Extensions;
using Space.Planet;
using Resources.PlayerResource;
using Resources.Research;
using UnityEngine;

namespace Resources.PlanetResource
{
    public class HarvestSystem : BaseSystem
    {
        private Entity _player;
        private PlayerWoodComponent playerWood;
        private PlayerMetalComponent playerMetal;
        private PlayerCoalComponent playerCoal;
        private PlayerCropsComponent playerCrops;

        private readonly QueryDescription _wood = new QueryDescription().WithAll<WoodComponent, PlanetComponent, HarvestComponent>();
        private readonly QueryDescription _metal = new QueryDescription().WithAll<MetalComponent, PlanetComponent, HarvestComponent>();
        private readonly QueryDescription _coal = new QueryDescription().WithAll<CoalComponent, PlanetComponent, HarvestComponent>();
        private readonly QueryDescription _crops = new QueryDescription().WithAll<CropsComponent, PlanetComponent, HarvestComponent>();

        public HarvestSystem(World world, Entity player) : base(world) 
        {
            _player = player;
            playerWood = _player.Get<PlayerWoodComponent>();
            playerMetal = _player.Get<PlayerMetalComponent>();
            playerCoal = _player.Get<PlayerCoalComponent>();
            playerCrops = _player.Get<PlayerCropsComponent>();
        }

        public override void Update()
        {
            World.Query(in _wood, (ref WoodComponent woodComp, ref PlanetComponent planet, ref HarvestComponent harvComp) =>
            {
                if (IsOccupied(planet))
                {
                    harvComp.TimeSinceLastTick += Time.deltaTime;
                    if (harvComp.TimeSinceLastTick >= 1)
                    {
                        int divider = HalfIfPartiallyOccupied(planet);

                        playerWood.AddWood(woodComp.WoodAmount / divider);

                        harvComp.TimeSinceLastTick = 0;
                    }
                }
            });

            World.Query(in _metal, (ref MetalComponent metalComp, ref PlanetComponent planet, ref HarvestComponent harvComp) =>
            {
                if (IsOccupied(planet))
                {
                    harvComp.TimeSinceLastTick += Time.deltaTime;
                    if (harvComp.TimeSinceLastTick >= 1)
                    {
                        int divider = HalfIfPartiallyOccupied(planet);

                        playerMetal.AddMetal(metalComp.MetalAmount / divider);

                        harvComp.TimeSinceLastTick = 0;
                    }
                }
            });

            World.Query(in _coal, (ref CoalComponent coalComp, ref PlanetComponent planet, ref HarvestComponent harvComp) =>
            {
                if (IsOccupied(planet))
                {
                    harvComp.TimeSinceLastTick += Time.deltaTime;
                    if (harvComp.TimeSinceLastTick >= 1)
                    {
                        int divider = HalfIfPartiallyOccupied(planet);

                        playerCoal.AddCoal(coalComp.CoalAmount / divider);

                        harvComp.TimeSinceLastTick = 0;
                    }
                }
            });

            World.Query(in _crops, (ref CropsComponent cropsComp, ref PlanetComponent planet, ref HarvestComponent harvComp) =>
            {
                if (IsOccupied(planet))
                {
                    harvComp.TimeSinceLastTick += Time.deltaTime;
                    if (harvComp.TimeSinceLastTick >= 1)
                    {
                        int divider = HalfIfPartiallyOccupied(planet);

                        playerCrops.AddCrops(cropsComp.CropsAmount / divider);

                        harvComp.TimeSinceLastTick = 0;
                    }
                }
            });
        }

        private bool IsOccupied(PlanetComponent planet)
        {
            return planet.OccupiedStatus != OccupiedByPlayer.NotOccupied;
        }

        private int HalfIfPartiallyOccupied(PlanetComponent planet)
        {
            return planet.OccupiedStatus == OccupiedByPlayer.PartiallyOccupied ? 2 : 1;
        }
    }
}