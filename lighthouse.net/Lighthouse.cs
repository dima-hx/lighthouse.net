using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using lighthouse.net.Core;
using lighthouse.net.Objects;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace lighthouse.net
{
    public sealed class Lighthouse
    {
        public Lighthouse()
        {
        }
        public async Task<AuditResult> Run(string urlWithProtocol)
        {
            return await Run(new AuditRequest(urlWithProtocol));
        }
        public async Task<AuditResult> Run(AuditRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var npm = new Npm();
            var npmPath = npm.GetNpmPath();

            var sm = new ScriptMaker($"{AppDomain.CurrentDomain.BaseDirectory}\\Node\\template.js");

            var content = sm.Produce(request, npmPath.Result);
            if (sm.Save(content))
            {
                try
                {
                    var node = new Node();
                    var stdoutJson = await node.Run(sm.TempFileName);
                    var obj = parseJson(stdoutJson);
                    return await Task.FromResult(obj);
                }
                finally
                {
                    sm.Delete();
                }
            }

            return await Task.FromResult<AuditResult>(null);
        }

        private AuditResult parseJson(string json)
        {
            if (String.IsNullOrEmpty(json)) return null;
            dynamic jObj = JObject.Parse(json);
            if (jObj == null) return null;

            var a = new AuditResult
            {
                Details = new List<Details>(),
                TimingDetails = new List<TimingDetails>(),
                BenchmarkIndex = jObj.environment?.benchmarkIndex,
                Performance = jObj.categories?.performance?.score,
                Accessibility = jObj.categories?.accessibility?.score,
                BestPractices = jObj.categories?["best-practices"]?.score,
                Seo = jObj.categories?.seo?.score,
                Pwa = jObj.categories?.pwa?.score
            };


            var audits = jObj.audits as JObject;
            if (audits != null)
            {
                foreach (var audit in audits)
                {
                    var val = (dynamic)audit.Value;
                    a.Details.Add(new Details()
                    {
                        Name = audit.Key,
                        Score = val.score,
                        RowValue = val.rawValue
                    });

                }
            }
            var timingDetails = jObj.timing?.entries as JArray;
            if (timingDetails != null)
            {
                foreach (var timingDetail in timingDetails)
                {
                    var val = (dynamic)timingDetail;
                    a.TimingDetails.Add(new TimingDetails()
                    {
                        Name = val?.name,
                        StartTime = val?.startTime,
                        Duration = val?.duration
                    });
                }
                a.TotalDuration = jObj.timing?.total;
            }

            return a;
        }
    }
}
