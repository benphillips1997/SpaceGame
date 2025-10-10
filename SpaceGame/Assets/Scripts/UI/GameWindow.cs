using Arch.Core;
using UnityEngine;

namespace UI
{
    public class GameWindow : MonoBehaviour
    {
        private Entity _entity;
        private World _world;

        [SerializeField]
        GameWindowType windowType;

        private void Awake()
        {
            _world = WorldFetcher.GetOrRegisterNewWorld();
            _entity = _world.Create(new GameWindowComponent(windowType, this.gameObject));
            gameObject.SetActive(false);
        }
    }
}