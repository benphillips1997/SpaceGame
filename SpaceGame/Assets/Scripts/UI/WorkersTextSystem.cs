using Arch.Core;
using UnityEngine;

namespace UI.Workers
{
    public class WorkersTextSystem : BaseSystem
    {
        private readonly QueryDescription _addWorkerEvent = new QueryDescription().WithAll<WorkerAddedEvent>();
        private readonly QueryDescription _workerUI = new QueryDescription().WithAll<WorkersTextComponent>();
        public WorkersTextSystem(World world) : base(world) { }

        private int newWorkerAmount = 0;
        public override void Update()
        {
            World.Query(in _addWorkerEvent, (Entity ent, ref WorkerAddedEvent ev) =>
            {
                newWorkerAmount = ev.NewValue;
                World.Destroy(ent);
            });

            World.Query(in _workerUI, (ref WorkersTextComponent component) =>
            {
                component.Amount = newWorkerAmount;
            });
        }
    }
}