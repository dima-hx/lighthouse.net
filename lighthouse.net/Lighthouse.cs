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
using System.Text.RegularExpressions;
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

            var cmd = new WhereCmd()
            {
                EnableDebugging = request.EnableLogging
            };
            var nodePath = await cmd.GetNodePath();
            if (String.IsNullOrEmpty(nodePath) || !File.Exists(nodePath)) throw new Exception("Couldn't find NodeJs. Please, install NodeJs and make shure than PATH variable defined.");

            var npm = new Npm(nodePath)
            {
                EnableDebugging = request.EnableLogging
            };
            var npmPath = await npm.GetNpmPath();

            var sm = new ScriptMaker();
            var content = sm.Produce(request, npmPath);
            if (!sm.Save(content)) throw new Exception($"Couldn't save JS script to %temp% directory. Path: {sm.TempFileName}");

            try
            {
                var node = new Node()
                {
                    EnableDebugging = request.EnableLogging
                };
                var stdoutJson = await node.Run(sm.TempFileName);
                var obj = parseJson(stdoutJson);
                return await Task.FromResult(obj);
            }
            catch(Exception ex)
            {
                if (!String.IsNullOrEmpty(ex.Message) && Regex.IsMatch(ex.Message, @"Cannot find module[\s\S]+?node_modules\\lighthouse'"))
                {
                    throw new Exception("Lighthouse is not installed. Please, execute `npm install -g lighthouse` in console.");
                }
                throw;
            }
            finally
            {
                if (!npm.EnableDebugging) sm.Delete();
            }
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
