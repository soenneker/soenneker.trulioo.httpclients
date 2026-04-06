using Soenneker.Trulioo.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Trulioo.HttpClients.Tests;

[Collection("Collection")]
public sealed class TruliooOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly ITruliooOpenApiHttpClient _httpclient;

    public TruliooOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<ITruliooOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
