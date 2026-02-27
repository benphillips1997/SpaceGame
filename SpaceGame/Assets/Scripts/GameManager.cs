using Arch.Core;
using Player;
using Population.Military;
using Population.Scientist;
using Population.Worker;
using Resources;
using Resources.Cash;
using Resources.PlanetResource;
using Resources.Research;
using Space.Planet;
using UI;
using UI.Cash;
using UI.Coal;
using UI.Crops;
using UI.Metal;
using UI.Wood;
using UI.Workers;
using UnityEngine;

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
        _world = WorldFetcher.GetOrRegisterNewWorld();

        _systemRunner = new(_world);

        CreateResearchEntities();

        player = _world.Create(
            new PlayerComponent(),
            new FoodComponent(),
            new WorkerComponent(),
            new ScientistComponent(),
            new MilitaryComponent(weaponsResearchEntity, armourResearchEntity),
            new CashComponent(),
            new WoodComponent(0),
            new MetalComponent(0),
            new CoalComponent(0),
            new CropsComponent(0)
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
        _systemRunner.AddSystem(new GameWindowSystem(_world));
        _systemRunner.AddSystem(new WoodTextSystem(_world));
        _systemRunner.AddSystem(new CoalTextSystem(_world));
        _systemRunner.AddSystem(new MetalTextSystem(_world));
        _systemRunner.AddSystem(new CropsTextSystem(_world));
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
