using ja.training.csharp._01_TimeboxedCounter;
using ja.training.csharp.Services;
using Moq;
using System;
using Xunit;

namespace ja.training.csharp._01_TimeboxedCounter
{
    public class TimeboxedCounterTest
    {
        private readonly ITimeboxedCounter Sut;
        private readonly Mock<IDateTimeProxy> _dateTimeMock;
        private DateTime _now;


        public TimeboxedCounterTest()
        {
            _dateTimeMock = new Mock<IDateTimeProxy>();
            // intentionally set up the mock with a modified closure to be able to "change time" during the test
            // ReSharper disable once AccessToModifiedClosure
            _dateTimeMock.Setup(m => m.UtcNow).Returns(() => _now);
            Sut = new TimeboxedCounter(_dateTimeMock.Object);
        }


        [Fact]
        public void Sums_return_counts_of_last_30_secs()
        {
            // arrange
            _now = new DateTime(2019, 4, 4);

            // act
            // add 30 seconds 3 ticks 
            for (var i = 0; i < 30; i++)
            {
                Sut.Add(3);
                _now = _now.AddSeconds(1);
            }

            // assert
            Assert.Equal(90, Sut.SumOfLastMinute);
            Assert.Equal(90, Sut.SumOfLastHour);
        }

        [Fact]
        public void Ticks_exactly_one_minute_old_shall_be_included_in_minute_timer()
        {
            // arrange
            _now = new DateTime(2019, 4, 4);

            // act
            Sut.Add(42);
            _now = _now.AddMinutes(1);

            // assert
            Assert.Equal(42, Sut.SumOfLastMinute);

            // act
            _now = _now.AddMilliseconds(1);
            // assert
            Assert.Equal(0, Sut.SumOfLastMinute);
        }

        [Fact]
        public void Ticks_exactly_one_hour_old_shall_be_included_in_hour_timer()
        {
            // arrange
            _now = new DateTime(2019, 4, 4);

            // act
            Sut.Add(42);
            _now = _now.AddHours(1);

            // assert
            Assert.Equal(42, Sut.SumOfLastHour);

            // act
            _now = _now.AddMilliseconds(1);
            // assert
            Assert.Equal(0, Sut.SumOfLastHour);
        }

        [Fact]
        public void SumMinutes_rejects_counts_older_than_minute()
        {
            // arrange
            _now = new DateTime(2019, 4, 4);

            // act
            // add 30 seconds 3 ticks 
            for (var i = 0; i < 30; i++)
            {
                Sut.Add(3);
                _now = _now.AddSeconds(1);
            }
            _now = _now.AddMinutes(1);
            Sut.Add(5);
            _now = _now.AddSeconds(5);

            // assert
            Assert.Equal(5, Sut.SumOfLastMinute);
            Assert.Equal(95, Sut.SumOfLastHour);
        }

        [Fact]
        public void SumHour_rejects_counts_older_than_hour()
        {
            // arrange
            _now = new DateTime(2019, 4, 4);

            // act
            // add 5 ticks on 0secs and 30 secs => 5*2*60 per hour. 
            for (var i = 0; i < 200; i++)
            {
                Sut.Add(5);
                _now = _now.AddMinutes(0.5);
            }
            // Then we wait some secs so that the very first is not within the last hour anymore => 5*2*60-5
            _now = _now.AddSeconds(5);

            // assert
            Assert.Equal(5, Sut.SumOfLastMinute);
            Assert.Equal(5 * 2 * 60 - 5, Sut.SumOfLastHour);
        }
    }
}
