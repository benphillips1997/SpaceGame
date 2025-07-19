using Arch.Core;
using Player;
using Population.Scientist;
using Population.Worker;
using Resources;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private World _world;

    private FoodSystem _foodSystem;
    private WorkerSystem _workerSystem;
    private ResearchSystem _researchSystem;
    private ScientistSystem _scientistSystem;

    private void Start()
    {
    }

    private Entity researchEntity;
    private Entity player;
    private void Awake()
    {
        _world = World.Create();

        _foodSystem = new(_world);
        _workerSystem = new(_world);
        _researchSystem = new(_world);
        _scientistSystem = new(_world);


        // Creates an entity with a FoodComponent.
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
    }

    private void Update()
    {
        _foodSystem.Update();
        _researchSystem.Update();


        // When button clicked
        if (Input.GetKeyDown(KeyCode.E))
        {
            _workerSystem.Update();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            _scientistSystem.Update();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _researchSystem.AddScientistToResearch(researchEntity, player);
        }


    }

}
