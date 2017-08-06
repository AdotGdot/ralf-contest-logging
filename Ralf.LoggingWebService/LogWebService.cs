using AutoMapper;
using Newtonsoft.Json;
using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;
using Ralf.Logging.Common.Types.Requests;
using Ralf.Logging.Common.Types.Responses;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Ralf.LoggingWebService
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
            return await postRequest(qso, "insert");
        }

        public async Task<bool> Update(Qso qso)
        {
            return await postRequest(qso, "update");
        }

        internal async Task<bool> postRequest(Qso qso, string route)
        {
            bool result = false;
            try
            {
                LogEntry logEntry = Mapper.Map<LogEntry>(qso);
                LogEntryRequest request = new LogEntryRequest() { LogEntry = logEntry };
                var json = JsonConvert.SerializeObject(request);
                using (var client = new HttpClient())
                {
                    string url = String.Format("{0}{1}", serviceUrl, route);
                    var headerValue = new MediaTypeWithQualityHeaderValue("text/json");
                    client.DefaultRequestHeaders.Accept.Add(headerValue);

                    HttpResponseMessage response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "text/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        result = true;
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
