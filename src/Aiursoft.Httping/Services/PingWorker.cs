using System.Net;

namespace Aiursoft.Httping.Services;

public class PingWorker
{
    public async Task HttpPing(
        string url,
        int count,
        TimeSpan timeout,
        TimeSpan interval,
        bool insecure = false,
        bool quiet = false,
        bool followRedirect = false,
        bool noProxy = false)
    {
        if (!url.Contains("://"))
        {
            url = "http://" + url;
        }
        
        var proxy = WebRequest.GetSystemWebProxy();
        var handler = new HttpClientHandler
        {
            AllowAutoRedirect = followRedirect,
            Proxy = proxy,
            UseProxy = !noProxy
        };

        if (insecure)
        {
            handler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;
        }
        
        if (!quiet)
        {
            if (!noProxy)
            {
                var actualProxyUrl = proxy.GetProxy(new Uri(url));
                if (actualProxyUrl != null && actualProxyUrl.ToString() != url)
                {
                    Console.WriteLine($"[Proxy] Using system proxy: {actualProxyUrl}");
                }
            }
            else
            {
                Console.WriteLine("[Proxy] Proxy disabled by user override.");
            }
        }

        var client = new HttpClient(handler) { Timeout = timeout };
        var uri = new UriBuilder(url);

        var total = TimeSpan.Zero;
        var minimum = TimeSpan.MaxValue;
        var maximum = TimeSpan.Zero;
        var loss = 0;

        for (var i = 0; i < count; i++)
        {
            try
            {
                var elapsed = await SendHttpRequest(client, uri);
                if (!quiet)
                {
                    Console.WriteLine(
                        $"{i + 1}: {elapsed.response.Version}, {elapsed.response.RequestMessage?.RequestUri?.Host}:{elapsed.response.RequestMessage?.RequestUri?.Port}, code={(int)elapsed.response.StatusCode}, size={elapsed.response.Content.Headers.ContentLength} bytes, time={elapsed.TimeElapsed.TotalMilliseconds} ms");
                }

                // Statistics
                total += elapsed.TimeElapsed;
                minimum = TimeSpan.FromMilliseconds(Math.Min(minimum.TotalMilliseconds,
                    elapsed.TimeElapsed.TotalMilliseconds));
                maximum = TimeSpan.FromMilliseconds(Math.Max(maximum.TotalMilliseconds,
                    elapsed.TimeElapsed.TotalMilliseconds));

                // Wait
                var wait = interval - elapsed.TimeElapsed;
                if (wait > TimeSpan.Zero && i != count - 1)
                {
                    await Task.Delay(wait);
                }
            }
            catch (TaskCanceledException)
            {
                loss++;
                Console.WriteLine($"PING {url} timeout");
                
                var wait = interval - timeout;
                if (wait > TimeSpan.Zero && i != count - 1)
                {
                    await Task.Delay(wait);
                }
            }
            catch (Exception ex)
            {
                loss++;
                Console.WriteLine($"PING {url} {ex.Message}");
            }
        }

        var average = total / count;

        Console.WriteLine();
        Console.WriteLine($"Ping statistics for {url}");
        Console.WriteLine(
            $"    Packets: Sent = {count}, Received = {count - loss}, Lost = {loss} ({loss * 100 / count}% loss),");
        Console.WriteLine($"Approximate round trip times in milli-seconds:");
        Console.WriteLine(
            $"    Minimum = {minimum.TotalMilliseconds}ms, Maximum = {maximum.TotalMilliseconds}ms, Average = {average.TotalMilliseconds}ms");
    }

    private async Task<(HttpResponseMessage response, TimeSpan TimeElapsed)> SendHttpRequest(
        HttpClient client, 
        UriBuilder uri)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var response = await client.GetAsync(uri.Uri);
        watch.Stop();
        return (response, watch.Elapsed);
    }
}