using ja.training.csharp.Services;
using System.Text;

namespace ja.training.csharp._01_TimeboxedCounter
{

    /// <inheritdoc/>
    public class TimeboxedCounter : ITimeboxedCounter
    {
        private readonly IDateTimeProxy _dateTime;

        public TimeboxedCounter(IDateTimeProxy dateTime)
        {
            _dateTime = dateTime;
        }

        /// <inheritdoc/>
        public void Add(int count)
        {
            
        }

        public int SumOfLastMinute
        {
            get
            {
                // TODO
                return 42;
            }
        }

        public int SumOfLastHour
        {
            get
            {
                // TODO
                return 42;
            }
        }
    }

}
