using Arch.Core;

namespace UI.Crops
{
    public class CropsTextSystem : BaseSystem
    {
        private readonly QueryDescription _updateCropsUIEvent = new QueryDescription().WithAll<CropsUpdatedEvent>();
        private readonly QueryDescription _cropsUI = new QueryDescription().WithAll<CropsTextComponent>();
        public CropsTextSystem(World world) : base(world) { }

        private double newCropsAmount;

        public override void Update()
        {
            World.Query(in _updateCropsUIEvent, (Entity ent, ref CropsUpdatedEvent ev) =>
            {
                newCropsAmount = ev.NewValue;
                World.Destroy(ent);
            });

            World.Query(in _cropsUI, (ref CropsTextComponent component) =>
            {
                component.Amount = newCropsAmount;
            });
        }
    }
}