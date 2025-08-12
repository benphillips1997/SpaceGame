using Arch.Core;
using Resources.PlanetResources;
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
                new PlanetResourceComponent(WoodAmount, MetalAmount, CoalAmount, CropsAmount)
            );
        }

        private void OnMouseDown()
        {
            Debug.Log("Planet clicked");
        }
    }
}

