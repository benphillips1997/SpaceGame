using Arch.Core;
using UnityEngine;

public static class WorldFetcher
{
    public static World Instance { get; private set; }

    public static void RegisterWorld(World world)
    {
        Instance = world;
    }
}
