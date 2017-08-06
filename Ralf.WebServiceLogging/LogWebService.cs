using AutoMapper;
using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;
using Ralf.Logging.Common.Types.Requests;
using Ralf.Logging.Common.Types.Responses;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Ralf.WebServiceLogging
{
    public class LogWebService : ILogWebService
    {
        private readonly string serviceUrl;
        public LogWebService(string serviceUrl)
        {
            this.serviceUrl = serviceUrl;
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<QsoToLogEntryMappingProfile>();
            });
        }

        public async Task<bool> Insert(Qso qso)
        {
            LogEntryRequest logEntryRequest = mapQsoToLogEntryRequest(qso);
            return await postQso(logEntryRequest, "insert");
        }

        private LogEntryRequest mapQsoToLogEntryRequest(Qso qso)
        {
            LogEntry logEntry = Mapper.Map<LogEntry>(qso);
            return new LogEntryRequest() { LogEntry = logEntry };
        }

        public async Task<bool> Update(Qso qso)
        {
            LogEntryRequest logEntryRequest = mapQsoToLogEntryRequest(qso);
            return await postQso(logEntryRequest, "update");
        }

        private async Task<bool> postQso(LogEntryRequest logEntryRequest, string path)
        {
            bool result = false;
            using (var client = new HttpClient())
            {
                string url = String.Format("{0}/{1}", serviceUrl, path);
                var headerValue = new MediaTypeWithQualityHeaderValue("text/json");
                client.DefaultRequestHeaders.Accept.Add(headerValue);

                HttpResponseMessage response = await client.PostAsync(url, null);
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync();
                    result = true;
                }
            }
            return result;
        }
    }
}
