namespace Business.Day11
{
    public class Octopus
    {
        public Octopus(int val)
        {
            Value = val;
        }

        public int Value { get; private set; }

        public bool Changed { get; private set; }

        public void SetUnchanged()
        {
            Changed = false;
        }

        public void IncreaseEnergy()
        {
            Value++;
            Changed = true;
        }

        public void Discharge()
        {
            Value = 0;
            Changed = true;
        }
    }
}