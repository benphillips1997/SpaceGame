using Arch.Core;
using Arch.Core.Extensions;
using Resources.Cash;

namespace Population.Worker
{
    public class WorkerSystem : BaseSystem
    {
        private readonly QueryDescription _workerEntities = new QueryDescription().WithAll<WorkerComponent>();
        private readonly QueryDescription _workerAddEvents = new QueryDescription().WithAll<AddWorkerEvent>();

        public WorkerSystem(World world) : base(world) { }

        public override void Update()
        {
            NewWorker();
        }

        private void NewWorker()
        {
            World.Query(in _workerAddEvents, (Entity ent, ref AddWorkerEvent ev) =>
            {
                var comp = ev.Player.Get<WorkerComponent>();
                var cashComp = ev.Player.Get<CashComponent>();
                // Check if we have enough cash, food, etc.
                //If we do, add worker then subtract food from FoodComponent
                if (cashComp.CashAmount > 100)
                {
                    World.Create(new WorkerAddedEvent() { NewValue = comp.AddWorker(1) });
                    World.Create(new CashUpdatedEvent() { NewValue = cashComp.AddCash(-100) });
                }

                //Otherwise, do nothing
                World.Destroy(ent);
            });
        }
    }
}

// Should be its own file
public struct WorkerAddedEvent
{
    public int NewValue;
}