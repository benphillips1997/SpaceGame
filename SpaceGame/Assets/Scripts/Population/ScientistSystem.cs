using Arch.Core;

namespace Population.Scientist
{
    public class ScientistSystem : BaseSystem
    {
        private readonly QueryDescription _scientistEntities = new QueryDescription().WithAll<ScientistComponent>(); // Maybe should also require PlayerComponent?
        public ScientistSystem(World world) : base(world) { }

        public override void Update()
        {
            World.Query(in _scientistEntities, (ref ScientistComponent worker) =>
            {
                worker.AddScientist(1);
            });
        }
    }
}