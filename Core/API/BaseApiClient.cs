using Core.Configuration;
using NLog;
using NLog.Fluent;
using RestSharp;
using RestSharp.Authenticators;

namespace Core.API;

public class BaseApiClient
{
    
    private readonly RestClient _restClient;
    private Logger _logger;

    public BaseApiClient(string url)
    {
        var options = new RestClientOptions(url)
        {
            Authenticator = new HttpBasicAuthenticator(
                AppConfiguration.API.User,
                AppConfiguration.API.Password
            ),

            MaxTimeout = 10000,
            ThrowOnAnyError = false
        };
        _restClient = new RestClient(options);
        _restClient.AddDefaultHeader("Content-Type", "application/json");
        _logger = LogManager.GetCurrentClassLogger();
        
    }
    
    public RestResponse Execute(RestRequest request)
    {
        _logger.Info($"Request method: {request.Method},\r\n URI: {_restClient.BuildUri(request)}");
        var response = _restClient.Execute<RestResponse>(request);
        _logger.Info($"Response content: {response.Content?.Normalize()}");
        return response;
    }
    
    public T? Execute<T>(RestRequest request)
    {
        _logger.Info($"Request method: {request.Method},\r\n URI: {_restClient.BuildUri(request)}");
        var response = _restClient.Execute<T>(request);
        _logger.Info($"Response content: {response.Content?.Normalize()}");
        return response.Data;
    }
    
}