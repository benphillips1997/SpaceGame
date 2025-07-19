using Arch.Core;
using UnityEngine;

public class PlayerActionSystem : BaseSystem
{
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            World.Create(new AddWorkerEvent { Player = _player});
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            World.Create(new AddScientistEvent { Player = _player });
        }
    }
}
