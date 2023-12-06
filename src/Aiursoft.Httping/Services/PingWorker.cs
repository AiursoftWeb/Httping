namespace Aiursoft.Httping.Services;

public class PingWorker
{
    public async Task HttpPing(string url, int count, TimeSpan timeout, TimeSpan interval, bool insecure = false, bool quiet = false)
    {
        var handler = new HttpClientHandler();
        if (insecure)
        {
            handler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;
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
                        $"{i + 1}: {elapsed.response.Version}, {elapsed.response.RequestMessage?.RequestUri?.Host}:{elapsed.response.RequestMessage?.RequestUri?.Port}, code={elapsed.response.StatusCode}, size={elapsed.response.Content.Headers.ContentLength} bytes, time={elapsed.TimeElapsed.TotalMilliseconds} ms");
                }

                // Statistics
                total += elapsed.TimeElapsed;
                minimum = TimeSpan.FromMilliseconds(Math.Min(minimum.TotalMilliseconds,
                    elapsed.TimeElapsed.TotalMilliseconds));
                maximum = TimeSpan.FromMilliseconds(Math.Max(maximum.TotalMilliseconds,
                    elapsed.TimeElapsed.TotalMilliseconds));
                
                // Wait
                var wait = interval - elapsed.TimeElapsed;
                if (wait > TimeSpan.Zero)
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

    private async Task<(HttpResponseMessage response, TimeSpan TimeElapsed)> SendHttpRequest(HttpClient client, UriBuilder uri)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var response = await client.GetAsync(uri.Uri);
        watch.Stop();
        return (response, watch.Elapsed);
    }
}