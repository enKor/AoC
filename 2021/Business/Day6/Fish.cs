namespace Business.Day6
{
    public class Fish
    {
        public int BornOn { get; } = 0;
        public int DaysLeft { get; set; }

        public Fish(int bornOn)
        {
            BornOn = bornOn;
            DaysLeft = 8;
        }

    }
}