using Arch.Core;
using UnityEngine;

namespace Resources.Cash
{
    public class CashSystem : BaseSystem
    {
        private readonly QueryDescription _cashTextComponent = new QueryDescription().WithAll<CashComponent>();
        public CashSystem(World world) : base(world) { }
        public override void Update()
        {
            World.Query(in _cashTextComponent, (Entity ent, ref CashComponent component) =>
            {
                World.Create(new CashUpdatedEvent{ NewValue = component.AddCash(1) });
            });
        }
    }
}