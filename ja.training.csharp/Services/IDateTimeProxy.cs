using System;

namespace ja.training.csharp.Services
{
    public interface IDateTimeProxy
    {
        DateTime UtcNow { get; }
    }
}
