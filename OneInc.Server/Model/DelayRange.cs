namespace OneInc.Server.Model
{
    public record class DelayRange
    {
        public DelayRange() { }
        public DelayRange(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public int Min { get; init; }
        public int Max { get; init; }
    }
}
