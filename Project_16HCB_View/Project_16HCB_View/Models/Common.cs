using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_16HCB_View.Models
{
    /// <summary>
    /// This class set functions general
    /// </summary>
    public class Common
    {
        /// <summary>
        /// convert response result api to list obj type T
        /// </summary>
        /// <typeparam name="T">object type output</typeparam>
        /// <param name="res">HttpResponseMessage</param>
        /// <param name="lstReceiver">list output</param>
        public static void ConvertLst<T>(System.Net.Http.HttpResponseMessage res, ref List<T> lstReceiver)
        {
            string strResult = res.Content.ReadAsStringAsync().Result;
            strResult = strResult.Replace("C", "");

            if (strResult.IndexOf('[') == -1)
            {
                strResult = strResult.Insert(1, "[");
                strResult = strResult.Insert(strResult.Length - 1, "]");
            }
            
            var json_serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            lstReceiver = json_serializer.Deserialize<List<T>>(json_serializer.Deserialize<string>(strResult));
        }
    }
}