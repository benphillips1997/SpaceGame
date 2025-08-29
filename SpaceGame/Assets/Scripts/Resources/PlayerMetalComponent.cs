

namespace Resources.PlayerResource
{
    public class PlayerMetalComponent
    {
        public double MetalAmount { get; private set; }

        public void AddMetal(double amount)
        {
            MetalAmount += amount;
        }
    }
}