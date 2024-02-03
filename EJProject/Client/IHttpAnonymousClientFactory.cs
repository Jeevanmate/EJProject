public interface IHttpAnonymousClientFactory
{
    HttpClient HttpClient { get; }
}

public class HttpAnonymousClientFactory : IHttpAnonymousClientFactory
{
    private readonly IHttpClientFactory httpClientFactory;

    public HttpAnonymousClientFactory(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public HttpClient HttpClient => httpClientFactory.CreateClient("EJProject.ServerAPI.Anonymous");
}


