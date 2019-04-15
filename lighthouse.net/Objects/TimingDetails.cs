using System;
using System.Collections.Generic;
using System.Text;

namespace lighthouse.net.Objects
{
    public sealed class TimingDetails
    {
        public string Name { get; set; }
        public decimal? StartTime { get; set; }
        public decimal? Duration { get; set; }
    }
}
