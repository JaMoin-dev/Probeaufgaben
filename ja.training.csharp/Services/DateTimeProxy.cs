using System;
using System.Collections.Generic;
using System.Text;

namespace ja.training.csharp.Services
{
    public class DateTimeProxy : IDateTimeProxy
    {
        public DateTime UtcNow { get; } = DateTime.UtcNow;
    }
}
