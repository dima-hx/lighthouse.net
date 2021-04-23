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
        public async Task<AuditResult> Run(string urlWithProtocol)
        {
            return await Run(new AuditRequest(urlWithProtocol)).ConfigureAwait(false);
        }
        public async Task<AuditResult> Run(AuditRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var cmd = new WhereCmd()
            {
                EnableDebugging = request.EnableLogging
            };
            var nodePath = await cmd.GetNodePath().ConfigureAwait(false);
            if (String.IsNullOrEmpty(nodePath) || !File.Exists(nodePath)) throw new Exception("Couldn't find NodeJs. Please, install NodeJs and make sure than PATH variable defined.");

            var npm = new Npm(nodePath)
            {
                EnableDebugging = request.EnableLogging
            };
            var npmPath = await npm.GetNpmPath().ConfigureAwait(false);

            var sm = new ScriptMaker();
            var content = sm.Produce(request, npmPath);
            if (!sm.Save(content)) throw new Exception($"Couldn't save JS script to %temp% directory. Path: {sm.TempFileName}");

            try
            {
                var node = new Node()
                {
                    EnableDebugging = request.EnableLogging
                };
                var stdoutJson = await node.Run(sm.TempFileName).ConfigureAwait(false);
                return AuditResult.Parse(stdoutJson);
            }
            catch (Exception ex)
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
        
    }
}
