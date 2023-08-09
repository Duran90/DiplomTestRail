using DiplomTestRail.Core.Models;
using RestSharp;
using RestSharp.Authenticators;

namespace DiplomTestRail.Core.Configuration.ApiConfiguration;

public class BaseApiClient
{
    private RestClient _restClient;
    private string baseAuth = "2Ot1SGp.hlkn2oYNNxdS-DX2U8egQVz4PKf0E0Ia7";
    
    
    public BaseApiClient(string url)
    {
        var options = new RestClientOptions(url)
        {
            Authenticator = new HttpBasicAuthenticator(UserBuilder.GetTestRailUser().Email, baseAuth),
            MaxTimeout = 10000,
            ThrowOnAnyError = true
        };
        _restClient = new RestClient();
        _restClient.AddDefaultHeader("Content-Type","application/json");
    }

    public RestResponse Execute(RestRequest request)
    {
        var response = _restClient.Execute(request);
        return response;
    }
    
    
}