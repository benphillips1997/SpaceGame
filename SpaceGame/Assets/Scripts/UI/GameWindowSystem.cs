using Arch.Core;
using Arch.Core.Extensions;
using UnityEngine;

public class GameWindowSystem : BaseSystem
{
    private readonly QueryDescription _windowChangeEvent = new QueryDescription().WithAll<WindowChangeEvent>();

    // GameWindows are set. There's only a few of them and we know what they'll be at compile time.
    // We could Dictionary this part by building a lazy lookup of window type and the entity. Probably not worth it for 7 checks though.
    private readonly QueryDescription _gameWindows = new QueryDescription().WithAll<GameWindowComponent>();

    public GameWindowSystem(World world) : base(world) { }

    private Entity? _currentWindowEntity;
    public override void Update()
    {
        World.Query(in _windowChangeEvent, (Entity ent, ref WindowChangeEvent ev) =>
        {
            ChangeWindow(ev.type);
            World.Destroy(ent);
        });

    }

    private void ChangeWindow(NavMenuButtonType windowType)
    {
        if (_currentWindowEntity.HasValue)
        {
            if (_currentWindowEntity.Value.TryGet<GameWindowComponent>(out var comp))
            {
                if (comp.windowType == windowType) return;
                comp.window.SetActive(false);
            }

        }

        World.Query(in _gameWindows, (Entity ent, ref GameWindowComponent comp) =>
        {
            Debug.Log("Here");
            Debug.Log($"Type: [{comp.windowType}]");
            if (comp.windowType == windowType)
            {
                comp.window.SetActive(true);
                _currentWindowEntity = ent;
            }
        });
    }
}

public struct WindowChangeEvent
{
    public NavMenuButtonType type;
    public WindowChangeEvent(NavMenuButtonType t)
    {
        type = t;
    }
}