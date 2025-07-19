using Arch.Core;
using Arch.Core.Extensions;
using Population.Scientist;
using UnityEngine;

public class ResearchSystem : BaseSystem
{
    private readonly QueryDescription _researches = new QueryDescription().WithAll<ResearchComponent>();

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
    }

    public void AddScientistToResearch(Entity research, Entity player)
    {
        if (research.TryGet<ResearchComponent>(out var res))
        {
            var sciComp = player.Get<ScientistComponent>();
            if(sciComp.ScientistCount > 0)
            {
                sciComp.AddScientist(-1);
                res.AddScientist(1);
            }
        }
    }
}
