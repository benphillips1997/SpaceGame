using Arch.Core;

namespace UI.Wood
{
    public class WoodTextSystem : BaseSystem
    {
        private readonly QueryDescription _updateWoodUIEvent = new QueryDescription().WithAll<WoodUpdatedEvent>();
        private readonly QueryDescription _woodUI = new QueryDescription().WithAll<WoodTextComponent>();
        public WoodTextSystem(World world) : base(world) { }

        private double newWoodAmount;

        public override void Update()
        {
            World.Query(in _updateWoodUIEvent, (Entity ent, ref WoodUpdatedEvent ev) =>
            {
                newWoodAmount = ev.NewValue;
                World.Destroy(ent);
            });

            World.Query(in _woodUI, (ref WoodTextComponent component) =>
            {
                component.Amount = newWoodAmount;
            });
        }
    }
}