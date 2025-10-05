using Arch.Core;
using Population.SoldierEvent;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActionSystem : BaseSystem
{
    private readonly QueryDescription _workerButtonClicked = new QueryDescription().WithAll<BuyWorkerButtonClickedEvent>();
    private readonly QueryDescription _navMenuButtonClicked = new QueryDescription().WithAll<NavMenuButtonClickedEvent>();

    // This is not how I want to do this longer term, just quickly moving things around
    private Entity _research;
    private Entity _player;
    private Button _lastClickedButton;

    public PlayerActionSystem(World world, Entity player, Entity research) : base(world)
    {
        _research = research;
        _player = player;
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            World.Create(new AddScientistToResearchRequest { Research = _research, player = _player });
        }

        World.Query(in _workerButtonClicked, (Entity ent, ref BuyWorkerButtonClickedEvent ev) =>
        {
            World.Create(new AddWorkerEvent { Player = _player});
            World.Destroy(ent);
        });

        World.Query(in _navMenuButtonClicked, (Entity ent, ref NavMenuButtonClickedEvent ev) =>
        {
            if(ev.button != _lastClickedButton)
            {
                if(_lastClickedButton != null)
                    _lastClickedButton.interactable = true;

                ev.button.interactable = false;
                _lastClickedButton = ev.button;
            }
            World.Destroy(ent);
        });

        if (Input.GetKeyDown(KeyCode.F))
        {
            World.Create(new AddScientistEvent { Player = _player });
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            World.Create(new AddSoldierEvent { Player = _player });
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            World.Create(new StartBattleRequest { Player = _player });
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            World.Create(new StopBattleRequest { Player = _player });
        }
    }
}
