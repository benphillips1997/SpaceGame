using UnityEngine;

public class GameWindowComponent
{
    public NavMenuButtonType windowType;
    public readonly GameObject window;
    public GameWindowComponent(NavMenuButtonType type, GameObject obj)
    {
        window = obj;
        windowType = type;
    }

}
