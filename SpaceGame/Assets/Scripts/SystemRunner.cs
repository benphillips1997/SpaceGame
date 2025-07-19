using Arch.Core;
using System.Collections.Generic;

public class SystemRunner
{
    private World _world;
    private readonly List<BaseSystem> _systems = new();

    public SystemRunner(World world)
    {
        _world = world;
    }

    public void AddSystem(BaseSystem system)
    {
        _systems.Add(system);
    }


    public void Update()
    {
        foreach (var system in _systems)
        {
            system.Update();
        }
    }
}
