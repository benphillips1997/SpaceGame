using Arch.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class NavMenuButton : MonoBehaviour
    {
        [SerializeField]
        private GameWindowType type;

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