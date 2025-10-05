using Arch.Core;
using Resources.PlanetResource;
using TMPro;
using UI.Cash;
using UnityEngine;

namespace Space.Planet
{
    public class Planet : MonoBehaviour
    {
        private World _world;

        private Entity _entity;

        [SerializeField]
        private OccupiedByPlayer occupiedByPlayer;

        [SerializeField]
        private double WoodAmount, MetalAmount, CoalAmount, CropsAmount;

        private void Start()
        {
            _world = WorldFetcher.Instance;
            _entity = _world.Create(
                new PlanetComponent(occupiedByPlayer),
                new WoodComponent(WoodAmount),
                new MetalComponent(MetalAmount),
                new CoalComponent(CoalAmount),
                new CropsComponent(CropsAmount),
                new HarvestComponent()
            );
        }

        private void OnMouseDown()
        {
            Debug.Log("Planet clicked");
        }
    }
}

