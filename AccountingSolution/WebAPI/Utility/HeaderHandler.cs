using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class HeaderHandler : DelegatingHandler
{
    private readonly string _headerName;
    private readonly string _headerValue;

    public HeaderHandler(string headerName, string headerValue)
    {
        _headerName = headerName;
        _headerValue = headerValue;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add(_headerName, _headerValue);
        return base.SendAsync(request, cancellationToken);
    }
}