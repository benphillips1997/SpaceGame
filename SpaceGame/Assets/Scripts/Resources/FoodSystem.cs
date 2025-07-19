using Arch.Core;
using Population.Worker;

namespace Resources
{

    public class FoodSystem : BaseSystem
    {
        private readonly QueryDescription _workerEntities = new QueryDescription().WithAll<FoodComponent, WorkerComponent>();

        public FoodSystem(World world) : base(world)
        {
        }

        public override void Update()
        {
            World.Query(in _workerEntities, (ref FoodComponent food, ref WorkerComponent worker) =>
            {
                if (worker.WorkerCount < 1)
                {
                    food.AddFood(1);
                }
                else
                {
                    food.AddFood(worker.WorkerCount * 2);
                }

            });
        }
    }
}