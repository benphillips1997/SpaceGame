

namespace Resources.PlayerResource
{
    public class PlayerCropsComponent
    {
        public double CropsAmount { get; private set; }

        public void AddCrops(double amount)
        {
            CropsAmount += amount;
        }
    }
}