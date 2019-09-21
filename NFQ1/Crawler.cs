using System.IO;
using System.Net;
using System;
using System.Web.Script.Serialization;


public class Crawler


{


    public static void CrawlAll(string jobDescription)


    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://jobs.github.com/positions.json?description="+jobDescription);
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "GET";
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls| SecurityProtocolType.Ssl3;
        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            try
            {
                var responseFromServer = streamReader.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                var obj = jss.Deserialize<dynamic>(responseFromServer);
                for (int i = 0; i < obj.Length; i++)
                {
                    Console.WriteLine("\nCompany name: " + obj[i]["company"]);
                    Console.WriteLine("Title: " + obj[i]["title"]);
                    Console.WriteLine("Type: " + obj[i]["type"]);
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Sorry, there are currently no job that having {jobDescription} description available.");
            }
            
        }
    }

    

    public static void CrawlParttime(string jobDescription)
    {

        var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://jobs.github.com/positions.json?description=" + jobDescription +"&full_time=false");
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "GET";
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            try
            {
                var responseFromServer = streamReader.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                var obj = jss.Deserialize<dynamic>(responseFromServer);
                int count = 0;
                for (int i = 0; i < obj.Length; i++)
                {
                    if(obj[i]["type"] != "Full Time")
                    {
                        Console.WriteLine("\nCompany name: " + obj[i]["company"]);
                        Console.WriteLine("Title: " + obj[i]["title"]);
                        Console.WriteLine("Location: " + obj[i]["location"]);
                    }
                    else
                    {
                        count += 1;
                    }
                }
                if(count == obj.Length)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Sorry, there are currently no part-time job that having {jobDescription} description available.");
            }
        }
    }
}