using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;
using System;
using System.Net;
using System.Xml;

namespace Ralf.QrzCallsignRepository
{
    public class CallsignRepository : IUSCallsignLookupRepository
    {
        private string url = "https://xmldata.qrz.com/xml/1.33/";
        private string userName;
        private string password;
        public CallsignRepository(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
        CallsignData IUSCallsignLookupRepository.LookupCallsign(string callsign)
        {
            XmlDocument xmlDoc = makeRequest(callsign);
            return buildCallsignData(xmlDoc);
        }

        private CallsignData buildCallsignData(XmlDocument xmlDoc)
        {
            CallsignData data = new CallsignData();
            if (xmlDoc != null)
            {
                data.Callsign = xmlDoc.GetElementsByTagName("call")[0].InnerText;
                data.City = xmlDoc.GetElementsByTagName("addr2")[0].InnerText;
                data.LicenseClass = String.Empty;
                string firstName = xmlDoc.GetElementsByTagName("fname")[0].InnerText;
                string lastName = xmlDoc.GetElementsByTagName("name")[0].InnerText;
                data.Licensee = String.Format("{0} {1}", firstName, lastName).Trim();
                data.State = xmlDoc.GetElementsByTagName("state")[0].InnerText;
            }
            return data;
        }

        private XmlDocument makeRequest(string callsign)
        {
            XmlDocument xmlDoc = null;
            string requestUrl = String.Format("{0}?username={1}&password={2}&callsign={3}", url, userName, password, callsign);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (var sr = new System.IO.StreamReader(response.GetResponseStream()))
                    {
                        xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(sr.ReadToEnd());
                    }

                }
            }
            catch (Exception)
            {

            }
            return xmlDoc;
        }
    }
}
