namespace Business.Day11
{
    public class Octopus
    {
        public Octopus(int val)
        {
            Value = val;
        }

        public bool HasBoostedAdjacent { get; set; }

        public int Value { get; private set; }

        public bool Boosted { get; private set; }

        public void SetUnchanged()
        {
            Boosted = false;
        }

        public void IncreaseEnergy()
        {
            Value++;
            Boosted = true;
        }

        public void Discharge()
        {
            Value = 0;
            Boosted = true;
            HasBoostedAdjacent = false;
        }
    }
}