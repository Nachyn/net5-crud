using System;

namespace TomskEdaRu.Logic.Common.ExternalServices.DateTimeService
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}