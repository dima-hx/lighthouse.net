using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace lighthouse.net.Objects
{
    /// <summary>
    /// Lighthouse Audit Result
    /// </summary>
    public sealed class AuditResult
    {
        /// <summary>
        /// Performance scope
        /// </summary>
        public decimal? Performance { get; set; }
        /// <summary>
        /// Accessibility scope
        /// </summary>
        public decimal? Accessibility { get; set; }
        /// <summary>
        /// Best practices scope
        /// </summary>
        public decimal? BestPractices { get; set; }
        /// <summary>
        /// SEO scope
        /// </summary>
        public decimal? Seo { get; set; }
        /// <summary>
        /// Progressive Web App scope
        /// </summary>
        public decimal? Pwa { get; set; }


        public decimal? BenchmarkIndex { get; set; }
        public List<Details> Details { get; set; }
        public List<TimingDetails> TimingDetails { get; set;}
        public decimal? TotalDuration { get; set;}
    }

}
