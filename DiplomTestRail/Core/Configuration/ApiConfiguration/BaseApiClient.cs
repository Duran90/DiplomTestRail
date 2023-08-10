using DiplomTestRail.Core.Models;
using RestSharp;
using RestSharp.Authenticators;

namespace DiplomTestRail.Core.Configuration.ApiConfiguration;

public class BaseApiClient
{
    private RestClient _restClient;
    private string baseAuth = "2Ot1SGp.hlkn2oYNNxdS-DX2U8egQVz4PKf0E0Ia7"; //todo Перенести в конфиг
    
    
    public BaseApiClient(string url) //todo Берем из конфига
    {
        
        var options = new RestClientOptions(url) 
        {
           
            Authenticator = new HttpBasicAuthenticator(UserBuilder.GetTestRailUser().Email, UserBuilder.GetTestRailUser().Password), //todo Брать из конфига
            MaxTimeout = 10000,
            ThrowOnAnyError = true
        };
        _restClient = new RestClient(options);
        _restClient.AddDefaultHeader("Content-Type","application/json");
    }

    public RestResponse Execute(RestRequest request)
    {
        var response = _restClient.Execute(request);
        return response;
    }
    
    public T Execute<T>(RestRequest request)
    {
        var response = _restClient.Execute<T>(request);
        return response.Data;
    }
    
}