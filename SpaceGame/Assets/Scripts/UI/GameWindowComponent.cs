using UnityEngine;

namespace UI
{
    public class GameWindowComponent
    {
        public GameWindowType windowType;
        public readonly GameObject window;
        public GameWindowComponent(GameWindowType type, GameObject obj)
        {
            window = obj;
            windowType = type;
        }

    }
}