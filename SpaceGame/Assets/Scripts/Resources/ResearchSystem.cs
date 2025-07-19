using Arch.Core;
using Arch.Core.Extensions;
using Population.Scientist;
using UnityEngine;

namespace Resources.Research
{
    public class ResearchSystem : BaseSystem
    {
        private readonly QueryDescription _researches = new QueryDescription().WithAll<ResearchComponent>();
        private readonly QueryDescription _researchAddingScientist = new QueryDescription().WithAll<AddScientistToResearchRequest>();

        public ResearchSystem(World world) : base(world) { }

        public override void Update()
        {
            World.Query(in _researches, (ref ResearchComponent component) =>
            {
                if (component.ScientistsResearching > 0)
                {
                    if (component.TimeToResearchInMs - Time.deltaTime < 0)
                    {
                        component.IsComplete = true;
                        Debug.Log("Research Complete!");
                        // Fire event here that tells everyone the research is done
                    }
                    else
                    {
                        component.TimeToResearchInMs -= Time.deltaTime;
                    }
                }
            });

            World.Query(in _researchAddingScientist, (Entity ent, ref AddScientistToResearchRequest req) =>
            {
                AddScientistToResearch(req.Research, req.player);
                World.Destroy(ent);
            });
        }

        public void AddScientistToResearch(Entity research, Entity player)
        {
            if (research.TryGet<ResearchComponent>(out var res))
            {
                var sciComp = player.Get<ScientistComponent>();
                if (sciComp.ScientistCount > 0)
                {
                    sciComp.AddScientist(-1);
                    res.AddScientist(1);
                    Debug.Log("Added Scientist");

                }
            }
        }
    }
}