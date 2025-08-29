using Arch.Core;
using Player;
using Population.Scientist;
using Population.Worker;
using Resources;
using Population.Military;
using Resources.Cash;
using Resources.Research;
using UI.Cash;
using UI.Workers;
using UnityEngine;
using Resources.PlanetResource;
using Space.Planet;
using Resources.PlayerResource;

public class GameManager : MonoBehaviour
{
    private World _world;
    private SystemRunner _systemRunner;

    private void Start()
    {
    }

    private Entity scientificEquipmentResearchEntity;
    private Entity armourResearchEntity;
    private Entity weaponsResearchEntity;
    private Entity player;

    private void Awake()
    {
        _world = World.Create();
        WorldFetcher.RegisterWorld(_world);

        _systemRunner = new(_world);

        CreateResearchEntities();

        player = _world.Create(
            new PlayerComponent(),
            new FoodComponent(),
            new WorkerComponent(),
            new ScientistComponent(),
            new MilitaryComponent(weaponsResearchEntity, armourResearchEntity),
            new CashComponent(),
            new PlayerWoodComponent(),
            new PlayerMetalComponent(),
            new PlayerCoalComponent(),
            new PlayerCropsComponent()
        );

        _systemRunner.AddSystem(new FoodSystem(_world));
        _systemRunner.AddSystem(new WorkerSystem(_world));
        _systemRunner.AddSystem(new ResearchSystem(_world));
        _systemRunner.AddSystem(new ScientistSystem(_world));
        _systemRunner.AddSystem(new PlayerActionSystem(_world, player, scientificEquipmentResearchEntity));
        _systemRunner.AddSystem(new MilitarySystem(_world));
        _systemRunner.AddSystem(new CashSystem(_world));
        _systemRunner.AddSystem(new PlanetSystem(_world));
        _systemRunner.AddSystem(new HarvestSystem(_world, player));

        // UI
        _systemRunner.AddSystem(new CashTextSystem(_world));
        _systemRunner.AddSystem(new WorkersTextSystem(_world));
    }

    private void Update()
    {
        _systemRunner.Update();
    }

    private void CreateResearchEntities()
    {
        scientificEquipmentResearchEntity = _world.Create(
            new ResearchComponent(
                ResearchClass.ScientificEquipment, ResearchTier.Level1, 6
            )
        );

        weaponsResearchEntity = _world.Create(
            new ResearchComponent(
                ResearchClass.Weapons, ResearchTier.Level1, 6
            )
        );

        armourResearchEntity = _world.Create(
            new ResearchComponent(
                ResearchClass.Armour, ResearchTier.Level1, 6
            )
        );
    }
}
