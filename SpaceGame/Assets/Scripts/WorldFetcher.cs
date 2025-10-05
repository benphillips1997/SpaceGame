using Arch.Core;
using UnityEngine;

public static class WorldFetcher
{
    public static World Instance { get; private set; }

    public static World GetOrRegisterNewWorld()
    {
        Instance ??= World.Create();
        return Instance;
    }
}
