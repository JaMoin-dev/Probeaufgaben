namespace ja.training.csharp._01_TimeboxedCounter
{
    /// <summary>
    /// Keeps track over a sum of data points over the last minute and the last hour.
    /// May be used very, very frequently e.g. to keep track of server requests.
    /// => So please take extra care for memory and cpu consumption :)
    /// => Please use the injected DateTimeProxy instead of DateTime, to allow for easy testing.
    /// </summary>
    public interface ITimeboxedCounter
    {
        /// <summary>
        /// for the next minute the SumOfLastMinute will be increased by 'count'
        /// for the next hour the SumOfLastHour will be increased by 'count'
        /// </summary>
        void Add(int count);

        int SumOfLastMinute { get; }

        int SumOfLastHour { get; }
    }

}
