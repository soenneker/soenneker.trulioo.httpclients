[![](https://img.shields.io/nuget/v/soenneker.trulioo.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.trulioo.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.trulioo.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.trulioo.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.trulioo.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.trulioo.httpclients/actions/workflows/codeql.yml)
[![](https://img.shields.io/nuget/dt/soenneker.trulioo.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.trulioo.httpclients/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Trulioo.HttpClients
Provides a cached, bearer-authenticated `HttpClient` for Trulioo's Customer API v2.5.

## Installation

```bash
dotnet add package Soenneker.Trulioo.HttpClients
```

## Configuration

```json
{
  "Trulioo": {
    "ApiKey": "your-license-or-access-token"
  }
}
```

The default base URL is `https://verification.trulioo.com/`. Set `Trulioo:ClientBaseUrl` for a regional or non-production endpoint.

Requests use `Authorization: Bearer {token}` by default. The Customer API uses different bearer credentials across its authorization and transaction flow, so configure the credential appropriate for the endpoints this client instance will call. Override `Trulioo:AuthHeaderName` or `Trulioo:AuthHeaderValueTemplate` only when your Trulioo integration requires it.

## Registration

```csharp
using Soenneker.Trulioo.HttpClients.Registrars;

services.AddTruliooOpenApiHttpClientAsScoped();
```

Scoped registration is useful when the wrapper's credential lifetime follows a transaction scope. Its shared HTTP-client cache remains singleton, while each wrapper owns and removes only its own cached client entry.

## Usage

```csharp
using Soenneker.Trulioo.HttpClients.Abstract;

HttpClient client = await truliooHttpClient.Get(cancellationToken);
HttpResponseMessage response =
    await client.GetAsync($"customer/transactions/{transactionId}", cancellationToken);

response.EnsureSuccessStatusCode();
```

Reuse the returned client within its configured credential scope. Do not dispose it directly; the wrapper owns its cached client entry. Treat request and response data as sensitive identity information and avoid logging payloads or credentials.
