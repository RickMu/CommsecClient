using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace CommSecClient
{
        public class DebugLoggingHandler: DelegatingHandler
        {
            public DebugLoggingHandler(HttpMessageHandler innerHandler = null)
            : base(innerHandler ?? new HttpClientHandler())
            { }
            async protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Console.WriteLine("[INFO] Http Delegator");
                await HttpMessageConsoleLoggingAsync(request);

                var response = await base.SendAsync(request,cancellationToken);
                await HttpResponseConsoleLoggingAsync(response);
                return response;
            }

            readonly string[] types = new[] { "html", "text", "xml", "json", "txt", "x-www-form-urlencoded" };
            bool IsTextBasedContentType(HttpHeaders headers)
            {
                IEnumerable<string> values;
                if (!headers.TryGetValues("Content-Type", out values))
                    return false;
                var header = string.Join(" ", values).ToLowerInvariant();

                return types.Any(t => header.Contains(t));
            }
            private async Task HttpResponseConsoleLoggingAsync(HttpResponseMessage response)
            {
                
                var id = Guid.NewGuid().ToString();
                var msg = $"[{id} -   Request]";

                Console.WriteLine($"{msg}=========Response Start=========");

                var resp = response;

                
                foreach (var header in resp.Headers)
                    Console.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");

                if (resp.Content != null)
                {
                    foreach (var header in resp.Content.Headers)
                        Console.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");

                    if (resp.Content is StringContent || this.IsTextBasedContentType(resp.Headers) || this.IsTextBasedContentType(resp.Content.Headers))
                    {
                        var result = await resp.Content.ReadAsStringAsync();

                        Console.WriteLine($"{msg} Content:");
                        Console.WriteLine($"{msg} {string.Join("", result.Cast<char>().Take(255))}...");
                    }
                }

                Console.WriteLine($"{msg}==========End==========");
            }
            private async Task HttpMessageConsoleLoggingAsync(HttpRequestMessage requestMessage)
            {
                    var req = requestMessage;
                    var id = Guid.NewGuid().ToString();
                    var msg = $"[{id} -   Request]";

                    Console.WriteLine($"{msg}========Start==========");
                    Console.WriteLine($"{msg} {req.Method} {req.RequestUri.PathAndQuery} {req.RequestUri.Scheme}/{req.Version}");
                    Console.WriteLine($"{msg} Host: {req.RequestUri.Scheme}://{req.RequestUri.Host}");

                    foreach (var header in req.Headers)
                        Console.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");

                    if (req.Content != null)
                    {
                        foreach (var header in req.Content.Headers)
                            Console.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");

                        if (req.Content is StringContent || this.IsTextBasedContentType(req.Headers) || this.IsTextBasedContentType(req.Content.Headers))
                        {   
                            var result = await req.Content.ReadAsStringAsync();

                            Console.WriteLine($"{msg} Content:");
                            Console.WriteLine($"{msg} {result}");

                        }
                    }

                    Console.WriteLine($"{msg}==========End==========");
            }
        }
}