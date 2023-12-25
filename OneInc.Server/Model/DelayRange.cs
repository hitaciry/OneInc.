namespace OneInc.Server.Model
{
    public record class DelayRange
    {
        public DelayRange(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public int Min { get; }
        public int Max { get; }
    }
}
