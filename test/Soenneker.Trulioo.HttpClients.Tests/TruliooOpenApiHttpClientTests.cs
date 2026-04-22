using Soenneker.Trulioo.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Trulioo.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class TruliooOpenApiHttpClientTests : HostedUnitTest
{
    private readonly ITruliooOpenApiHttpClient _httpclient;

    public TruliooOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<ITruliooOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
