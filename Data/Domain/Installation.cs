using System;

namespace AspNetCorePlayground.Data.Domain
{
    public class Installation
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }
    }
}