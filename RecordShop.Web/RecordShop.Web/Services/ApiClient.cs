using System.Net;
using System.Net.Http.Json;

namespace RecordShop.Web.Services;

public class ApiClient
{
    private readonly HttpClient _http;

    public ApiClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<T?> GetWithRetryAsync<T>(string requestUri)
    {
        const int maxAttempts = 12;

        for (var attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                var response = await _http.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<T>();
                }

                var apiMayBeStarting =
                    response.StatusCode == HttpStatusCode.BadGateway ||
                    response.StatusCode == HttpStatusCode.ServiceUnavailable ||
                    response.StatusCode == HttpStatusCode.GatewayTimeout;

                if (!apiMayBeStarting)
                {
                    response.EnsureSuccessStatusCode();
                }

                if (attempt == maxAttempts)
                {
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException) when (attempt < maxAttempts)
            {
                // The API may still be waking up.
            }

            await Task.Delay(TimeSpan.FromSeconds(8));
        }

        throw new HttpRequestException(
            "The API did not become available after several attempts.");
    }
}
