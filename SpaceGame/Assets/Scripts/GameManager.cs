using Arch.Core;
using Player;
using Population.Scientist;
using Population.Worker;
using Resources;
using Resources.Research;
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
        _systemRunner = new(_world);

        player = _world.Create(
            new PlayerComponent(),
            new FoodComponent(),
            new WorkerComponent(),
            new ScientistComponent()
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


    }

    private void Update()
    {
        _systemRunner.Update();


//       // When button clicked
//       if (Input.GetKeyDown(KeyCode.E))
//       {
//           //Add WorkerAddEvent
//           _workerSystem.Update();
//       }
//       if (Input.GetKeyDown(KeyCode.F))
//       {
//           //Add ScientistAddEvent
//           _scientistSystem.Update();
//       }
    }

}
