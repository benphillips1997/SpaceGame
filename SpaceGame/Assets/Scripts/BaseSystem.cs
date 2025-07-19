using Arch.Core;

public abstract class BaseSystem
{
    public World World { get; protected set; }

    protected BaseSystem(World world)
    {
        World = world;
    }

    public abstract void Update();
}
