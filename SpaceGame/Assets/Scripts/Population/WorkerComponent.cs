using UnityEngine;

namespace Population.Worker
{
    public class WorkerComponent
    {
        public int WorkerCount = 0;

        public int AddWorker(int amount)
        {
            return WorkerCount += amount;
        }
    }
}