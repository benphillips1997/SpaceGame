using Arch.Core;

namespace Population.Worker {
    public class WorkerSystem : BaseSystem
    {
        private readonly QueryDescription _workerEntities = new QueryDescription().WithAll<WorkerComponent>();

        public WorkerSystem(World world) : base(world) { }

        public override void Update()
        {
            World.Query(in _workerEntities, (ref WorkerComponent worker) =>
            {
                // Check if we have enough food
                //If we do, add worker then subtract food from FoodComponent
                worker.AddWorker(1);
                //Otherwise, do nothing

            });
        }
    }
}