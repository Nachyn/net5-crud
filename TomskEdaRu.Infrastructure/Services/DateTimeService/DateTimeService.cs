using System;
using TomskEdaRu.Logic.Common.ExternalServices.DateTimeService;

namespace TomskEdaRu.Infrastructure.Services.DateTimeService
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}