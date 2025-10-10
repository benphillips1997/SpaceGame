using UnityEngine.UI;

namespace UI
{
    public struct NavMenuButtonClickedEvent
    {
        public Button button;
        public GameWindowType type;
        public NavMenuButtonClickedEvent(Button b, GameWindowType t)
        {
            button = b;
            type = t;
        }
    }
}
