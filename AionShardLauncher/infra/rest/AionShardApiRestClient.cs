using System;
using AionShardLauncher.infra.dto;
using AionShardLauncher.infra.exception;
using RestSharp;

namespace AionShardLauncher.infra.rest
{
    public class AionShardApiRestClient
    {
        private static AionShardApiRestClient _instance;
        private const string Version = "/version";

        private readonly IRestClient _httpClient;

        public static AionShardApiRestClient GetInstance(ApiInfos apiInfos)
        {
            if (_instance == null)
            {
                _instance = new AionShardApiRestClient(apiInfos);
            }

            return _instance;
        }

        private AionShardApiRestClient(ApiInfos apiInfos)
        {
            _httpClient = new RestClient(new Uri("http://" + apiInfos.Url + ":" + apiInfos.Port));
        }

        public string GetVersionLauncher()
        {
            var restRequest = new RestRequest(Version, Method.GET);
            var restResponse = _httpClient.Execute<Response>(restRequest);

            if (restResponse.IsSuccessful)
            {
                return restResponse.Data.Version;
            }

            throw new VersionException();
        }
    }
}