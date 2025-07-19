using Arch.Core;
using UnityEngine;

public class PlayerActionSystem : BaseSystem
{
    private readonly QueryDescription _workerButtonClicked = new QueryDescription().WithAll<BuyWorkerButtonClickedEvent>();

    // This is not how I want to do this longer term, just quickly moving things around
    private Entity _research;
    private Entity _player;
    public PlayerActionSystem(World world, Entity player, Entity research) : base(world)
    {
        _research = research;
        _player = player;
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            World.Create(new AddScientistToResearchRequest { Research = _research, player = _player });
        }

        World.Query(in _workerButtonClicked, (Entity ent, ref BuyWorkerButtonClickedEvent ev) =>
        {
            World.Create(new AddWorkerEvent { Player = _player});
            World.Destroy(ent);
        });

        if (Input.GetKeyDown(KeyCode.F))
        {
            World.Create(new AddScientistEvent { Player = _player });
        }
    }
}
