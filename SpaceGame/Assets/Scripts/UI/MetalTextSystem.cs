using Arch.Core;

namespace UI.Metal
{
    public class MetalTextSystem : BaseSystem
    {
        private readonly QueryDescription _updateMetalUIEvent = new QueryDescription().WithAll<MetalUpdatedEvent>();
        private readonly QueryDescription _metalUI = new QueryDescription().WithAll<MetalTextComponent>();
        public MetalTextSystem(World world) : base(world) { }

        private double newMetalAmount;

        public override void Update()
        {
            World.Query(in _updateMetalUIEvent, (Entity ent, ref MetalUpdatedEvent ev) =>
            {
                newMetalAmount = ev.NewValue;
                World.Destroy(ent);
            });

            World.Query(in _metalUI, (ref MetalTextComponent component) =>
            {
                component.Amount = newMetalAmount;
            });
        }
    }
}