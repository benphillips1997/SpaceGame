using Arch.Core;
using Resources.Cash;
using Resources.Research;
using UnityEngine;

namespace UI.Cash
{
    public class CashTextSystem : BaseSystem
    {
        private readonly QueryDescription _updateCashUIEvent = new QueryDescription().WithAll<CashUpdatedEvent>();
        private readonly QueryDescription _cashUI = new QueryDescription().WithAll<CashTextComponent>();
        public CashTextSystem(World world) : base(world) { }

        private double newCashAmount;
        public override void Update()
        {
            World.Query(in _updateCashUIEvent, (Entity ent, ref CashUpdatedEvent ev) =>
            {
                newCashAmount = ev.NewValue;
                World.Destroy(ent);
            });

            World.Query(in _cashUI, (ref CashTextComponent component) =>
            {
                component.CashAmount = newCashAmount;
            });
        }
    }
}