using Mobideo.Core.Extensions;
using ProjectAddIn3.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectAddIn3.Classes
{
    public class CustomerFilesFileUploader : IFileUploader
    {
        [DataContract(Name = "KeyValue", Namespace = "")]
        private class KeyValue
        {
            [DataMember(Name = "Username")]
            public string Username { get; set; }

            [DataMember(Name = "Password")]
            public string Password { get; set; }
        }

        [DataContract(Name = "TokenResponse", Namespace = "")]
        private class TokenResponse
        {
            [DataMember(Name = "access_token")]
            public string access_token { get; set; }
        }
        public Task UploadFile(string path, Stream stream)
        {
            var token = ProvideToken();

            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("Could not create token for file upload.");
            }

            var mobideoEnvironment = new Uri(ConfigurationManager.AppSettings["MobideoEnvironmentUrl"]);
            var mobideoCustomerFilesAddress = "GuideRepository/Repository/Customer/";
            var customerFilesFolderName = ConfigurationManager.AppSettings["CustomerFilesUploadFolderName"];
            var uploadUrl = new Uri(string.Format("{0}{1}{2}?folderName={3}", mobideoEnvironment.AbsoluteUri, mobideoCustomerFilesAddress, Path.GetFileName(path), customerFilesFolderName));
            var client = new RestClient(uploadUrl);
            Logger.Debug("uploadUrl = {0}", uploadUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddHeader("X-Mobideo-Scope", "Repository");
            request.AddHeader("X-Mobideo-Behalf-Of", "admin");
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddParameter("application/octet-stream", (stream as MemoryStream).ToArray(), ParameterType.RequestBody);

            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Service could not upload stream of import results");
            }
            Logger.Debug("succesfuly uploaded file to customer files at = {0}", uploadUrl);
            return Task.CompletedTask;

        }

        private string ProvideToken()
        {
            var mobideoEnvironment = new Uri(ConfigurationManager.AppSettings["MobideoEnvironmentUrl"]);
            var mobideoTokenAddress = "GuideWebApi/api/Authentication/Token";
            var mobideoUserName = ConfigurationManager.AppSettings["MobideoUserName"];
            var mobideoUserPassword = ConfigurationManager.AppSettings["MobideoUserPassword"];
            var Authurl = new Uri(string.Format("{0}{1}", mobideoEnvironment.AbsoluteUri, mobideoTokenAddress));

            var UserPassword = new KeyValue
            {
                Username = mobideoUserName,
                Password = mobideoUserPassword
            };
            var serialized = UserPassword.ToJson();
            var client = new RestClient(Authurl);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("X-Mobideo-Scope", "Repository");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", @"Basic R3VpZGVTZXJ2aWNlczplekZDT1VJeVJFWTBMVE5HUWpndE5ESkZOaTA0UlRKRkxUazJNRU0zTVROQlJqa3dOWDA9");
            request.AddParameter("application /json", serialized, ParameterType.RequestBody);
            var response = client.Execute(request);

            return response.Content.FromJson<TokenResponse>().access_token;
        }

    }
}
