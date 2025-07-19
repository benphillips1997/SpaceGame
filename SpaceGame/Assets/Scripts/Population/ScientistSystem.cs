using Arch.Core;
using Arch.Core.Extensions;

namespace Population.Scientist
{
    public class ScientistSystem : BaseSystem
    {
        private readonly QueryDescription _scientistEntities = new QueryDescription().WithAll<ScientistComponent>();
        private readonly QueryDescription _scientistAddEvents = new QueryDescription().WithAll<AddScientistEvent>();
        public ScientistSystem(World world) : base(world) { }

        public override void Update()
        {
            World.Query(in _scientistAddEvents, (Entity ent, ref AddScientistEvent ev) =>
            {
                var comp = ev.Player.Get<ScientistComponent>();
                comp.AddScientist(1);
                World.Destroy(ent);
            });
        }
    }
}