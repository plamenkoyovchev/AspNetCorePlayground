using System;

namespace AspNetCorePlayground.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetDate()
        {
            return DateTime.Now;
        }
    }
}