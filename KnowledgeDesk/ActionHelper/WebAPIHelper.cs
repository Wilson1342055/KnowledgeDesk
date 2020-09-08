using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using KnowledgeDesk.Model.Common;
using KnowledgeModel.Common;
using Newtonsoft.Json;

namespace KnowledgeDesk.ActionHelper
{
    public class WebAPIHelper
    {
        private const string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.31 (KHTML, like Gecko) Chrome/26.0.1410.64 Safari/537.31"; //"Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.2; Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1) ; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
        public DataTable QueryDataTable(string url, string postData, string method, ref string ErrorMessage)
        {
            try
            {
                HttpWebRequest httpRequest;
                DataTable dtReturn = null;
                if (method.ToLower() == "post")
                {
                    httpRequest = (HttpWebRequest)WebRequest.Create(url);
                }
                else
                {
                    if (string.IsNullOrEmpty(postData))
                    {
                        httpRequest = (HttpWebRequest)WebRequest.Create(url);
                    }
                    else
                    {
                        //对特殊符号进行编码，避免被转义;
                        postData = postData.Replace("+", "%2B").Replace(" ", "%20").Replace("/", "%2F").Replace("?", "%3F").Replace("#", "%23");
                        httpRequest = (HttpWebRequest)WebRequest.Create(url + "?" + postData.Trim());
                    }
                }
                httpRequest.Method = method.ToUpper();
                //httpRequest.CookieContainer = cc;
                // httpRequest.Headers.Set("Accept-Language", "en-us");
                if (method.ToLower() == "post")
                {
                    httpRequest.ContentLength = postData.Length;
                }
                httpRequest.Timeout = 600000;
                //httpRequest.ContentType = "application/x-www-form-urlencoded";

                httpRequest.Accept = "*/*";
                httpRequest.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                //加入头信息
                httpRequest.UserAgent = UserAgent;
                httpRequest.AutomaticDecompression = DecompressionMethods.GZip;
                httpRequest.Proxy = null;
                if (method.ToLower() == "post")
                {
                    httpRequest.ContentType = "application/json";
                    byte[] bytesToPost = Encoding.UTF8.GetBytes(postData);
                    httpRequest.ContentLength = bytesToPost.Length;
                    Stream requestStream = httpRequest.GetRequestStream();
                    requestStream.Write(bytesToPost, 0, bytesToPost.Length);
                    requestStream.Close();
                }
                HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();

                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string reStr = sr.ReadToEnd();
                try
                {
                    ResponseDataModel rdReturn = JsonConvert.DeserializeObject<ResponseDataModel>(reStr);
                    if (rdReturn.IsSuccess)
                    {
                        dtReturn = JsonConvert.DeserializeObject<DataTable>(rdReturn.Content.ToString());
                    }
                    ErrorMessage = rdReturn.ErrorMsg;

                    //dtReturn = JsonToDataTable(rdReturn.Content.ToString(), ref ErrorMessage);
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
                sr.Close();
                if (httpRequest != null)
                {
                    httpRequest.Abort();
                    httpRequest = null;
                }
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
                return dtReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("出现异常或等待时间过长.\n详细信息:\n" + ex);
            }

        }//查询返回DataTable


        public ExecResult ExecuteResultList(string url, string postData, string method, ref string ErrorMessage)
        {
            ErrorMessage = "";
            ExecResult rdReturn = new ExecResult();
            try
            {
                HttpWebRequest httpRequest;
                if (method.ToLower() == "post")
                {
                    httpRequest = (HttpWebRequest)WebRequest.Create(url);
                }
                else
                {
                    if (string.IsNullOrEmpty(postData))
                    {
                        httpRequest = (HttpWebRequest)WebRequest.Create(url);
                    }
                    else
                    {
                        //对特殊符号进行编码，避免被转义;
                        postData = postData.Replace("+", "%2B").Replace(" ", "%20").Replace("/", "%2F").Replace("?", "%3F").Replace("#", "%23");
                        httpRequest = (HttpWebRequest)WebRequest.Create(url + "?" + postData.Trim());
                    }
                }
                httpRequest.Proxy = null;
                httpRequest.Method = method.ToUpper();
                if (method.ToLower() == "post")
                {
                    httpRequest.ContentLength = postData.Length;
                }
                httpRequest.Timeout = 60000;
                httpRequest.Accept = "*/*";
                httpRequest.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                //加入头信息
                httpRequest.UserAgent = UserAgent;
                httpRequest.AutomaticDecompression = DecompressionMethods.GZip;
                httpRequest.Proxy = null;
                if (method.ToLower() == "post")
                {
                    httpRequest.ContentType = "application/json";
                    byte[] bytesToPost = Encoding.UTF8.GetBytes(postData);
                    httpRequest.ContentLength = bytesToPost.Length;
                    Stream requestStream = httpRequest.GetRequestStream();
                    requestStream.Write(bytesToPost, 0, bytesToPost.Length);
                    requestStream.Close();
                }
                HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string reStr = sr.ReadToEnd();
                try
                {
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    rdReturn = JsonConvert.DeserializeObject<ExecResult>(reStr, settings);
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
                sr.Close();
                if (httpRequest != null)
                {
                    httpRequest.Abort();
                    httpRequest = null;
                }
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ("出现异常或等待时间过长.\n详细信息:\n" + ex);
            }
            return rdReturn;
        }//执行返回INT


       

    }
}
