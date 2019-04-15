using System;
using System.Collections.Generic;
using System.Text;

namespace lighthouse.net.Objects
{
    public class EnvironmentObj
    {
        public string networkUserAgent { get; set; }
        public string hostUserAgent { get; set; }
        public int benchmarkIndex { get; set; }
    }

    public class AuditDetails
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int score { get; set; }
        public string scoreDisplayMode { get; set; }
        public bool rawValue { get; set; }
        public string displayValue { get; set; }
        //public Details details { get; set; }
        public List<object> warnings { get; set; }
        public string explanation { get; set; }
    }
    

    //public class Audits
    //{

    //}

    public class Throttling
    {
        public int rttMs { get; set; }
        public double throughputKbps { get; set; }
        public double requestLatencyMs { get; set; }
        public double downloadThroughputKbps { get; set; }
        public int uploadThroughputKbps { get; set; }
        public int cpuSlowdownMultiplier { get; set; }
    }

    public class ConfigSettings
    {
        public string output { get; set; }
        public int maxWaitForFcp { get; set; }
        public int maxWaitForLoad { get; set; }
        public string throttlingMethod { get; set; }
        public Throttling throttling { get; set; }
        public bool auditMode { get; set; }
        public bool gatherMode { get; set; }
        public bool disableStorageReset { get; set; }
        public bool disableDeviceEmulation { get; set; }
        public string emulatedFormFactor { get; set; }
        public string channel { get; set; }
        public string locale { get; set; }
        public object blockedUrlPatterns { get; set; }
        public object additionalTraceCategories { get; set; }
        public object extraHeaders { get; set; }
        public object precomputedLanternData { get; set; }
        public object onlyAudits { get; set; }
        public object onlyCategories { get; set; }
        public object skipAudits { get; set; }
    }

    public class AuditRef
    {
        public string id { get; set; }
        public int weight { get; set; }
        public string group { get; set; }
    }

    public class Performance
    {
        public string title { get; set; }
        public List<AuditRef> auditRefs { get; set; }
        public string id { get; set; }
        public int score { get; set; }
    }

    public class AuditRef2
    {
        public string id { get; set; }
        public int weight { get; set; }
        public string group { get; set; }
    }

    public class Accessibility
    {
        public string title { get; set; }
        public string description { get; set; }
        public string manualDescription { get; set; }
        public List<AuditRef2> auditRefs { get; set; }
        public string id { get; set; }
        public double score { get; set; }
    }

    public class AuditRef3
    {
        public string id { get; set; }
        public int weight { get; set; }
    }

    public class BestPractices
    {
        public string title { get; set; }
        public List<AuditRef3> auditRefs { get; set; }
        public string id { get; set; }
        public double score { get; set; }
    }

    public class AuditRef4
    {
        public string id { get; set; }
        public int weight { get; set; }
        public string group { get; set; }
    }

    public class Seo
    {
        public string title { get; set; }
        public string description { get; set; }
        public string manualDescription { get; set; }
        public List<AuditRef4> auditRefs { get; set; }
        public string id { get; set; }
        public double score { get; set; }
    }

    public class AuditRef5
    {
        public string id { get; set; }
        public int weight { get; set; }
        public string group { get; set; }
    }

    public class Pwa
    {
        public string title { get; set; }
        public string description { get; set; }
        public string manualDescription { get; set; }
        public List<AuditRef5> auditRefs { get; set; }
        public string id { get; set; }
        public double score { get; set; }
    }

    public class Categories
    {
        public Performance performance { get; set; }
        public Accessibility accessibility { get; set; }
        //public BestPractices __invalid_name__best-practices { get; set; }
        public Seo seo { get; set; }
        public Pwa pwa { get; set; }
    }

    public class Metrics2
    {
        public string title { get; set; }
    }

    public class LoadOpportunities
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Diagnostics2
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class PwaFastReliable
    {
        public string title { get; set; }
    }

    public class PwaInstallable
    {
        public string title { get; set; }
    }

    public class PwaOptimized
    {
        public string title { get; set; }
    }

    public class A11yBestPractices
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class A11yColorContrast
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class A11yNamesLabels
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class A11yNavigation
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class A11yAria
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class A11yLanguage
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class A11yAudioVideo
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class A11yTablesLists
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class SeoMobile
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class SeoContent
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class SeoCrawl
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class CategoryGroups
    {
        //public Metrics2 metrics { get; set; }
        //public LoadOpportunities __invalid_name__load-opportunities { get; set; }
        //public Diagnostics2 diagnostics { get; set; }
        //public PwaFastReliable __invalid_name__pwa-fast-reliable { get; set; }
        //public PwaInstallable __invalid_name__pwa-installable { get; set; }
        //public PwaOptimized __invalid_name__pwa-optimized { get; set; }
        //public A11yBestPractices __invalid_name__a11y-best-practices { get; set; }
        //public A11yColorContrast __invalid_name__a11y-color-contrast { get; set; }
        //public A11yNamesLabels __invalid_name__a11y-names-labels { get; set; }
        //public A11yNavigation __invalid_name__a11y-navigation { get; set; }
        //public A11yAria __invalid_name__a11y-aria { get; set; }
        //public A11yLanguage __invalid_name__a11y-language { get; set; }
        //public A11yAudioVideo __invalid_name__a11y-audio-video { get; set; }
        //public A11yTablesLists __invalid_name__a11y-tables-lists { get; set; }
        //public SeoMobile __invalid_name__seo-mobile { get; set; }
        //public SeoContent __invalid_name__seo-content { get; set; }
        //public SeoCrawl __invalid_name__seo-crawl { get; set; }
    }

    public class Entry
    {
        public double startTime { get; set; }
        public string name { get; set; }
        public double duration { get; set; }
        public string entryType { get; set; }
    }

    public class Timing
    {
        public List<Entry> entries { get; set; }
        public double total { get; set; }
    }

    public class RendererFormattedStrings
    {
        public string auditGroupExpandTooltip { get; set; }
        public string crcInitialNavigation { get; set; }
        public string crcLongestDurationLabel { get; set; }
        public string errorLabel { get; set; }
        public string errorMissingAuditInfo { get; set; }
        public string labDataTitle { get; set; }
        public string lsPerformanceCategoryDescription { get; set; }
        public string manualAuditsGroupTitle { get; set; }
        public string notApplicableAuditsGroupTitle { get; set; }
        public string opportunityResourceColumnLabel { get; set; }
        public string opportunitySavingsColumnLabel { get; set; }
        public string passedAuditsGroupTitle { get; set; }
        public string scorescaleLabel { get; set; }
        public string snippetCollapseButtonLabel { get; set; }
        public string snippetExpandButtonLabel { get; set; }
        public string toplevelWarningsMessage { get; set; }
        public string varianceDisclaimer { get; set; }
        public string warningAuditsGroupTitle { get; set; }
        public string warningHeader { get; set; }
    }

    public class Values
    {
        public double timeInMs { get; set; }
    }

    public class LighthouseCoreLibI18nI18nJsSeconds
    {
        public Values values { get; set; }
        public string path { get; set; }
    }

    public class Values2
    {
        public double timeInMs { get; set; }
    }

    public class LighthouseCoreLibI18nI18nJsMs
    {
        public Values2 values { get; set; }
        public string path { get; set; }
    }

    public class Values3
    {
        public double timeInMs { get; set; }
    }

    public class LighthouseCoreAuditsTimeToFirstByteJsDisplayValue
    {
        public Values3 values { get; set; }
        public string path { get; set; }
    }

    public class Values4
    {
        public int itemCount { get; set; }
    }

    public class LighthouseCoreAuditsByteEfficiencyUsesLongCacheTtlJsDisplayValue
    {
        public Values4 values { get; set; }
        public string path { get; set; }
    }

    public class Values5
    {
        public int totalBytes { get; set; }
    }

    public class LighthouseCoreAuditsByteEfficiencyTotalByteWeightJsDisplayValue
    {
        public Values5 values { get; set; }
        public string path { get; set; }
    }

    public class Values6
    {
        public int itemCount { get; set; }
    }

    public class LighthouseCoreAuditsDobetterwebDomSizeJsDisplayValue
    {
        public Values6 values { get; set; }
        public string path { get; set; }
    }

    public class Values7
    {
        public int decimalProportion { get; set; }
    }

    public class LighthouseCoreAuditsSeoFontSizeJsDisplayValue
    {
        public Values7 values { get; set; }
        public string path { get; set; }
    }

    public class Values8
    {
        public int decimalProportion { get; set; }
    }

    public class LighthouseCoreAuditsSeoTapTargetsJsDisplayValue
    {
        public Values8 values { get; set; }
        public string path { get; set; }
    }


    public class LighthouseRsp
    {
        public string userAgent { get; set; }
        public EnvironmentObj environment { get; set; }
        public string lighthouseVersion { get; set; }
        public string fetchTime { get; set; }
        public string requestedUrl { get; set; }
        public string finalUrl { get; set; }
        public List<object> runWarnings { get; set; }
        public Dictionary<string, AuditDetails> audits { get; set; }
        public ConfigSettings configSettings { get; set; }
        public Categories categories { get; set; }
        public CategoryGroups categoryGroups { get; set; }
        public Timing timing { get; set; }
    }
}
