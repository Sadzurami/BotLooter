﻿using System.Net;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using Serilog;

namespace BotLooter.Resources;

public class ProxyClientProvider : IClientProvider
{
    public int ClientCount => _proxiedClients.Count;
    
    private readonly List<RestClient> _proxiedClients;
    private int _proxyIndex;

    public ProxyClientProvider(List<RestClient> proxiedClients)
    {
        _proxiedClients = proxiedClients;
    }

    public RestClient Provide()
    {
        var proxiedClient = _proxiedClients[_proxyIndex];

        if (++_proxyIndex >= _proxiedClients.Count)
        {
            _proxyIndex = 0;
        }

        return proxiedClient;
    }
    
    public static async Task<(ProxyClientProvider? ProxyPool, string Message)> TryLoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return (null, $"Файла с прокси '{filePath}' не существует");
        }

        var lines = await File.ReadAllLinesAsync(filePath);

        var proxiedClients = new List<RestClient>();

        var lineNumber = 0;
        
        foreach (var line in lines)
        {
            lineNumber++;

            var proxy = TryParseProxy(line);

            if (proxy is null)
            {
                Log.Logger.Warning("Неверный формат прокси на строке {LineNumber}", lineNumber);
                continue;
            }

            var restClient = new RestClient(new RestClientOptions
            {
                UserAgent =
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36",
                Proxy = proxy
            }, configureSerialization: b => b.UseNewtonsoftJson());

            proxiedClients.Add(restClient);
        }

        return (new ProxyClientProvider(proxiedClients), "");
    }

    private static WebProxy? TryParseProxy(string line)
    {
        try
        {
            var uri = new Uri(line);

            var proxy = new WebProxy(uri);

            if (!string.IsNullOrEmpty(uri.UserInfo))
            {
                var credentials = uri.UserInfo.Split(':', 2);

                proxy.Credentials = new NetworkCredential(credentials[0], credentials[1]);
            }

            return proxy;
        }
        catch
        {
            return null;
        }
    }
}