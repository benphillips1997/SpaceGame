using Arch.Core;
using UnityEngine;

namespace UI.Coal
{
    public class CoalTextSystem : BaseSystem
    {
        private readonly QueryDescription _updateCoalUIEvent = new QueryDescription().WithAll<CoalUpdatedEvent>();
        private readonly QueryDescription _coalUI = new QueryDescription().WithAll<CoalTextComponent>();
        public CoalTextSystem(World world) : base(world) { }

        private double newCoalAmount;

        public override void Update()
        {
            World.Query(in _updateCoalUIEvent, (Entity ent, ref CoalUpdatedEvent ev) =>
            {
                newCoalAmount = ev.NewValue;
                World.Destroy(ent);
            });

            World.Query(in _coalUI, (ref CoalTextComponent component) =>
            {
                component.Amount = newCoalAmount;
            });
        }
    }
}