using Arch.Core;
using UnityEngine;

public class GameWindow : MonoBehaviour
{
    private Entity _entity;
    private World _world;

    [SerializeField]
    NavMenuButtonType windowType;

    private void Awake()
    {
        _world = WorldFetcher.GetOrRegisterNewWorld();
        Debug.Log($"Set entity to: [{windowType}]. World: [{_world.Id}]");
        _entity = _world.Create(new GameWindowComponent(windowType, this.gameObject));
        gameObject.SetActive(false);
    }
}
