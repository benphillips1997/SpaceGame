using Arch.Core;
using Player;
using Population.Scientist;
using Population.Worker;
using Resources;
using Resources.Cash;
using Resources.Research;
using UI.Cash;
using UI.Workers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private World _world;
    private SystemRunner _systemRunner;

    private void Start()
    {
    }

    private Entity researchEntity;
    private Entity player;
    private void Awake()
    {
        _world = World.Create();
        WorldFetcher.RegisterWorld(_world);

        _systemRunner = new(_world);

        player = _world.Create(
            new PlayerComponent(),
            new FoodComponent(),
            new WorkerComponent(),
            new ScientistComponent(),
            new CashComponent()
        );

        researchEntity = _world.Create(
            new ResearchComponent(
                ResearchClass.ScientificEquipment, ResearchTier.Level1, 6
            )
         );

        _systemRunner.AddSystem(new FoodSystem(_world));
        _systemRunner.AddSystem(new WorkerSystem(_world));
        _systemRunner.AddSystem(new ResearchSystem(_world));
        _systemRunner.AddSystem(new ScientistSystem(_world));
        _systemRunner.AddSystem(new PlayerActionSystem(_world, player, researchEntity));
        _systemRunner.AddSystem(new CashSystem(_world));

        // UI
        _systemRunner.AddSystem(new CashTextSystem(_world));
        _systemRunner.AddSystem(new WorkersTextSystem(_world));

    }

    private void Update()
    {
        _systemRunner.Update();
    }

}
