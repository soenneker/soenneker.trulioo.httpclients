using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Trulioo.HttpClients.Abstract;

/// <summary>
/// Provides a cached, bearer-authenticated <see cref="HttpClient"/> for Trulioo's Customer API.
/// </summary>
public interface ITruliooOpenApiHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the configured Trulioo Customer API client.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
