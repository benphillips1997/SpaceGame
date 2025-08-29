

namespace Resources.PlayerResource
{
    public class PlayerWoodComponent
    {
        public double WoodAmount { get; private set; }

        public void AddWood(double amount)
        {
            WoodAmount += amount;
        }
    }
}