using Arch.Core;
using UnityEngine;
using UnityEngine.UI;

public enum NavMenuButtonType
{
    CURRENT_PLANET,
    UNITS,
    RESEARCH,
    MILITARY,
    BUILD,
    MAP,
    STATS,
    SAVE,
    EXIT
}
namespace UI
{
    public class NavMenuButton : MonoBehaviour
    {
        [SerializeField]
        private NavMenuButtonType type;

        [SerializeField]
        private Button button;
        private World _world;

        private void Start()
        {
            _world = WorldFetcher.Instance;
        }

        public void OnClick()
        {
            Debug.Log("CLICK");
            _world.Create(new NavMenuButtonClickedEvent(button, type));
            _world.Create(new WindowChangeEvent(type));
        }
    }
}

public struct NavMenuButtonClickedEvent
{
    public Button button;
    public NavMenuButtonType type;
    public NavMenuButtonClickedEvent(Button b, NavMenuButtonType t)
    {
        button = b;
        type = t;
    }
}