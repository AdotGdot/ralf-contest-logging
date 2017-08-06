using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;
using Ralf.Multipliers.States.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ralf.HamCallUsCallsignRepository
{
    public class CallsignRepository : IUSCallsignLookupRepository
    {
        private readonly string textToBreakOn = "<HR NOSHADE SIZE=\"2\">";
        private readonly char splitChar = '^';
        public CallsignData LookupCallsign(string callsign)
        {
            CallsignData cd = new CallsignData();
            cd.Callsign = callsign.ToUpper();
            string data = makeRequest(callsign);
            if (!String.IsNullOrEmpty(data))
            {
                data = cleanInitialData(data);
                string nameAndAddressData = getNameAndAddressData(data);
                data = clearToTag(data, textToBreakOn);
                string additionalData = cleanAdditionalData(data);
                cd = getCallsignData(callsign, nameAndAddressData, additionalData);
            }
            return cd;
        }

        private CallsignData getCallsignData(string callsign, string nameAndAddressData, string additionalData)
        {
            CallsignData cd = new CallsignData();
            cd.Callsign = callsign.ToUpper();
            string[] parts = nameAndAddressData.Trim().Split(splitChar);
            cd.Licensee = parts[0].Trim();
            string[] addrParts = parts[parts.Length - 1].Trim().Split(' ');
            if (addrParts.Length >= 3)
            {
                cd.State = addrParts[addrParts.Length - 2].Trim();

                if (!UsStateListBuilder.isValidState(cd.State))
                {
                    cd.Licensee = String.Empty;
                    cd.LicenseClass = String.Empty;
                    cd.State = String.Empty;
                    cd.City = String.Empty;
                    return cd;
                }
                string city = String.Empty;
                for (int i = 0; i < addrParts.Length - 2; i++)
                {
                    city += addrParts[i] + " ";
                }
                cd.City = city.Trim();
            }
            parts = additionalData.Split(splitChar);
            foreach (string part in parts)
            {
                if (part.StartsWith("Class"))
                {
                    string[] children = part.Split(':');
                    if (children.Length == 2)
                    {
                        cd.LicenseClass = children[1].Trim();
                    }
                    break;
                }
            }
            return cd;
        }


        private string getNameAndAddressData(string data)
        {
            string nameAndAddressData = getToTag(data, textToBreakOn);
            return replaceEncodings(nameAndAddressData);
        }

        private string cleanInitialData(string data)
        {
            string tag = "Lookups:";
            data = clearToTag(data, tag);

            tag = "color=\"#000000\">";
            data = clearToTag(data, tag);

            return data;
        }
        private string cleanAdditionalData(string data)
        {
            string additionalData = getToTag(data, textToBreakOn);
            string tag = "<font face=verdana, helvetica, arial size=2>";
            additionalData = clearToTag(additionalData, tag);
            tag = "License Expires:";
            additionalData = getToTag(additionalData, tag);
            additionalData = replaceEncodings(additionalData);
            return additionalData;
        }

        private string clearToTag(string data, string tag)
        {
            int i = data.IndexOf(tag);
            if (i != -1)
            {
                data = data.Substring(i + tag.Length);
            }
            return data;
        }

        private string getToTag(string data, string tag)
        {
            string result = String.Empty;
            int i = data.IndexOf(tag);
            if (i != -1)
            {
                result = data.Substring(0, i);
            }
            return result;
        }
        private CallsignData parseLicenseData(string callsign, string[] parts)
        {
            CallsignData cd = new CallsignData();
            cd.Callsign = callsign.ToUpper();

            return cd;
        }

        private string replaceEncodings(string data)
        {
            // replace HTML and special chars
            data = data.Replace("<p>", "");
            data = data.Replace("</font>", "");
            data = data.Replace("</b>", "");
            data = data.Replace("<b>", "");
            data = data.Replace("<br><br>", "<br>");
            data = data.Replace("\n", "");
            data = data.Replace("<br>", splitChar.ToString());
            if (data.EndsWith(splitChar.ToString()))
            {
                data = data.Substring(0, data.Length - 1);
            }
            return data;
        }

        private string makeRequest(string callsign)
        {
            string data = String.Empty;
            string url = String.Format("http://hamdata.com/getcall.html?callsign={0}", callsign.Trim());
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 5000;
            try
            {
                using (WebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        data = reader.ReadToEnd();
                    }
                }
            }
            catch { }
            return data;
        }
    }
}