using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIService
{
    public class APICaller
    {

        const string cAuthKey = "CWB-543C4DBB-CE81-4E01-8CF2-F654C17D912C";
        const string cApi_base = "https://opendata.cwb.gov.tw/api";
        /// <summary>
        /// 一般天氣預報-今明 36 小時天氣預報
        /// </summary>
        public M_FC0032001 GetFC0032001Data()
        {            
            string sApi = "/v1/rest/datastore/F-C0032-001";
            string sApiUrl = string.Format("{0}{1}", cApi_base, sApi);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", cAuthKey);
            var result = client.GetAsync(sApiUrl).Result;
         
            string resultContent = result.Content.ReadAsStringAsync().Result;
            M_FC0032001 data = JsonConvert.DeserializeObject<M_FC0032001>(resultContent);

            return data;
        }
    }
}
