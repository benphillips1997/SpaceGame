using Arch.Core;
using Arch.Core.Extensions;

namespace Population.Worker {
    public class WorkerSystem : BaseSystem
    {
        private readonly QueryDescription _workerEntities = new QueryDescription().WithAll<WorkerComponent>();
        private readonly QueryDescription _workerAddEvents = new QueryDescription().WithAll<AddWorkerEvent>();

        public WorkerSystem(World world) : base(world) { }

        public override void Update()
        {
            World.Query(in _workerAddEvents, (Entity ent, ref AddWorkerEvent ev) =>
            {
                var comp = ev.Player.Get<WorkerComponent>();
                // Check if we have enough food
                //If we do, add worker then subtract food from FoodComponent
                comp.AddWorker(1);
                //Otherwise, do nothing
                World.Destroy(ent);
            });
        }
    }
}