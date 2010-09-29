using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace TwitterClient
{
    static class WebClient
    {
        public static string Get(string url, Dictionary<string, string> parameters)
        {
            return Get(url, Dictionary2String(parameters));
        }

        public static string Get(string url, string parameters)
        {
            if (parameters != null && parameters != "")
            {
                if (url.Contains("?"))
                {
                    url += "&" + parameters;
                }
                else
                {
                    url += "?" + parameters;
                }
            }

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.ASCII);
            string content = reader.ReadToEnd();
            reader.Close();
            stream.Close();

            return content;
        }

        public static string Post(string url, Dictionary<string, string> parameters)
        {
            return Post(url, Dictionary2String(parameters));
        }

        public static string Post(string url, string parameters)
        {
            byte[] postData = System.Text.Encoding.ASCII.GetBytes(parameters);

            System.Net.ServicePointManager.Expect100Continue = false;
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;

            Stream requestStream = request.GetRequestStream();

            requestStream.Write(postData, 0, postData.Length);
            requestStream.Close();

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.ASCII);
            string content = reader.ReadToEnd();
            reader.Close();
            stream.Close();

            return content;
        }

        public static string Dictionary2String(Dictionary<string, string> parameters)
        {
            string queryParameter = "";
            foreach (string key in parameters.Keys)
            {
                if (queryParameter != "") queryParameter = "&";
                queryParameter += key + "=" + parameters[key];
            }

            return queryParameter;
        }

        public static Dictionary<string, string> String2Dictionary(string queryParameter)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (string keyvalue in queryParameter.Split(new char[] { '&' }))
            {
                string[] values = keyvalue.Split(new char[] { '=' });
                parameters.Add(values[0], values[1]);
            }

            return parameters;
        }
    }
}
