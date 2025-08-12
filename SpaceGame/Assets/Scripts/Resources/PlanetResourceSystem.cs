using Arch.Core;
using Arch.Core.Extensions;
using Space.Planet;
using Resources.PlayerResources;
using Resources.Research;
using UnityEngine;

namespace Resources.PlanetResources
{
    public class PlanetResourceSystem : BaseSystem
    {
        private Entity _player;

        private readonly QueryDescription _resources = new QueryDescription().WithAll<PlanetResourceComponent, PlanetComponent>();

        public PlanetResourceSystem(World world, Entity player) : base(world) 
        {
            _player = player;
        }

        public override void Update()
        {
            World.Query(in _resources, (ref PlanetResourceComponent planetResComp, ref PlanetComponent planet) =>
            {
                bool isPartiallyOccupied = planet.OccupiedStatus == OccupiedByPlayer.PartiallyOccupied;
                if (planet.OccupiedStatus == OccupiedByPlayer.FullyOccupied || isPartiallyOccupied)
                {
                    var playerResComp = _player.Get<PlayerResourceComponent>();

                    playerResComp.TimeToNextUpdate -= Time.deltaTime;
                    if (playerResComp.TimeToNextUpdate < 0)
                    {
                        int divider = isPartiallyOccupied ? 2 : 1;

                        playerResComp.AddWood(planetResComp.WoodAmount / divider);
                        playerResComp.AddMetal(planetResComp.MetalAmount / divider);
                        playerResComp.AddCoal(planetResComp.CoalAmount / divider);
                        playerResComp.AddCrops(planetResComp.CropsAmount / divider);

                        playerResComp.TimeToNextUpdate = 1;

                        Debug.Log($"Wood: {playerResComp.WoodAmount}, Metal: {playerResComp.MetalAmount}, Coal: {playerResComp.CoalAmount}, Crops: {playerResComp.CropsAmount}");
                    }
                }
            });
        }
    }
}