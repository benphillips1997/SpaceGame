using UnityEngine;

namespace Population.Worker
{
    public class WorkerComponent
    {
        public int WorkerCount = 0;

        public void AddWorker(int amount)
        {
            Debug.Log("Added Worker");
            WorkerCount += amount;
        }
    }
}