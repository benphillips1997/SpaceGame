

namespace Resources.PlayerResource
{
    public class PlayerCoalComponent
    {
        public double CoalAmount { get; private set; }

        public void AddCoal(double amount)
        {
            CoalAmount += amount;
        }
    }
}