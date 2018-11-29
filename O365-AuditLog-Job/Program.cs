using AuditExtractJob.Models;
using AuditExtractJob.Models.AuditExtract;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AuditExtractJob
{
    class Program
    {
        //App Client ID & Secret
        private readonly static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private readonly static string clientSecret = ConfigurationManager.AppSettings["ida:ClientSecret"];

        //Azure ActiveDirectory details
        private readonly static string aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
        private readonly static string tenant = ConfigurationManager.AppSettings["ida:Tenant"];
        private readonly static string aadTenant = ConfigurationManager.AppSettings["ida:AADTenant"];

        //Source service endpoint
        private readonly static string serviceResourceId = ConfigurationManager.AppSettings["ida:ServiceResourceId"];
        private static string serviceBaseAddress = ConfigurationManager.AppSettings["endpoint:ServiceBaseAddress"];

        //Token Issuer authority
        private static readonly string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

        //Global Variables
        private static AuthenticationContext authContext = new AuthenticationContext(authority);
        private static ClientCredential clientCredential = new ClientCredential(clientId, clientSecret);
        private static AuthenticationResult authResult = null;

        static void Main1(string[] args)
        {
            List<Audit> audit = ExtractAuditEndpoints(System.IO.File.ReadAllText(@"C:\Users\Rathanavel\Documents\GitHub\O365-AuditLog-Extract\O365-AuditLog-Job\Sample.json"));
            Console.WriteLine(audit.Count.ToString());
            ExtractAudit(audit);

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            int retryCount = 0;
            bool retry = false;
            do
            {
                retry = false;
                try
                {
                    //synchronous way to aquire token.
                    //authResult = authContext.AcquireToken(serviceResourceId, clientCredential);

                    //asynchronous way to aquire token. 
                    Authenticate().Wait();

                }
                catch (AdalException ex)
                {
                    if (ex.ErrorCode == "temporarily_unavailable")
                    {
                        Console.WriteLine(ex.ErrorCode + Environment.NewLine + ex.Message);
                        retry = true;
                    }
                    else
                    {
                        retry = true;
                        Console.WriteLine(ex.ErrorCode + Environment.NewLine + ex.Message);
                    }

                    Console.WriteLine(string.Format("Retrying ({0}) of 3 attempt(s)", (retryCount + 1).ToString()));

                    retryCount++;
                    Thread.Sleep(3000);
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                    Console.ReadLine();
                    return;
                }
            } while ((retry == true) && (retryCount < 3));

            if (authResult == null)
            {
                Console.WriteLine("Cancelling attempt ..");
                Thread.Sleep(2000);
                return;
            }

            Console.WriteLine("Authenticated succesfully.." + Environment.NewLine + "Accessing Enpoint.." + Environment.NewLine);

            List<Audit> audit = ExtractAuditEndpoints(System.IO.File.ReadAllText(@"C:\Users\Rathanavel\Documents\GitHub\O365-AuditLog-Extract\O365-AuditLog-Job\Sample.json"));
            Console.WriteLine(audit.Count.ToString());
            ExtractAudit(audit);

            //AccessAuditEndpoint(authResult);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Completed!");
            Console.ReadLine();
            return;

        }

        private static async void AccessAuditEndpoint(AuthenticationResult authContext)
        {
            serviceBaseAddress = string.Format(serviceBaseAddress, aadTenant);

            string endpoint = "";

            string startSubscription = "/start?contentType=Audit.SharePoint";
            //endpoint = startSubscription + "&PublisherIdentifier=" + aadTenant;

            string stopSubscription = "/stop?contentType=Audit.SharePoint";
            //endpoint = stopSubscription + "&PublisherIdentifier=" + aadTenant;

            string listAllSubscription = "/list";
            //endpoint = listAllSubscription + "?PublisherIdentifier=" + aadTenant;

            string getContent = "/content?contentType=Audit.SharePoint";
            endpoint = getContent + "&PublisherIdentifier=" + aadTenant;

            string startDateTime = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm");
            string endDateTime = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm");
            string getSpecficDateTimeContent = "/content?contentType=Audit.SharePoint&startTime=" + startDateTime + "&endTime=" + endDateTime;
            //endpoint = getSpecficDateTimeContent + "&PublisherIdentifier=" + aadTenant;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authContext.AccessToken);

            HttpResponseMessage response = await httpClient.GetAsync(serviceBaseAddress + endpoint);

            //HttpResponseMessage response = await httpClient.PostAsync(serviceBaseAddress + endpoint, null);

            if (response.IsSuccessStatusCode)
            {
                string output = await response.Content.ReadAsStringAsync();
                List<Audit> auditExtrcatEndpoints = ExtractAuditEndpoints(output);

                Console.WriteLine(output);
            }
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Access Denied!");
                    //authContext.TokenCache.Clear();
                }
                else
                {
                    Console.WriteLine(response.ReasonPhrase);
                }
            }

            Console.WriteLine(Environment.NewLine + "*******" + Environment.NewLine);
        }

        private static List<Audit> ExtractAuditEndpoints(String rawResponse)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<List<Audit>>(rawResponse);
        }

        private static void ExtractAudit(List<Audit> auditEndpoints)
        {
            if (auditEndpoints.Count > 0)
            {
                string path = CheckAndCreateFolder();
                int counter = 1;

                foreach (Audit endpoint in auditEndpoints)
                {
                    DownloadBlob(endpoint.contentUri, path, counter).Wait();

                    counter++;
                }
            }
        }

        private static async Task DownloadBlob(string blobEndpoint, string path, int counter)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

                HttpResponseMessage response = await httpClient.GetAsync(blobEndpoint);

                path += "/unprocessed_" + counter.ToString() + DateTime.Now.ToString("_HH-mm") + ".json";
                File.WriteAllText(path, response.Content.ReadAsStringAsync().Result);
                Console.WriteLine("Extract " + counter.ToString() + " downloaded!");
            }
        }

        private static string CheckAndCreateFolder()
        {
            string path = Environment.CurrentDirectory + "/Blobs";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            path += "/" + DateTime.Now.ToString("yyyy");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            path += "/" + DateTime.Now.ToString("MM");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            path += "/" + DateTime.Now.ToString("dd");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            return path;
        }

        /// <summary>
        /// Helper method to acquire authentication result in async way.
        /// </summary>
        /// <param name="resource">Resource id</param>
        /// <param name="cred">Credentials</param>
        /// <returns></returns>
        private static async Task Authenticate()
        {
            authResult = await authContext.AcquireTokenAsync(serviceResourceId, clientCredential);
        }

    }
}
