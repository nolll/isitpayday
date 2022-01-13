using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Web.Settings;

namespace Web.Bootstrapping;

public class ServiceConfig
{
    private readonly AppSettings _settings;
    private readonly IServiceCollection _services;

    public ServiceConfig(AppSettings settings, IServiceCollection services)
    {
        _settings = settings;
        _services = services;
    }

    public void Configure()
    {
        AddCompression();
        AddLogging();
        AddDependencies();
        AddMvc();
    }

    private void AddCompression()
    {
        _services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<GzipCompressionProvider>();
        });
    }

    private void AddLogging()
    {
        _services.AddLogging(logging =>
        {
            if (_settings.Logging.Loggers.Debug)
                logging.AddDebug();

            if (_settings.Logging.Loggers.Console)
                logging.AddConsole();

            logging.SetMinimumLevel(_settings.Logging.LogLevel);
        });
    }

    private void AddDependencies()
    {
        _services.AddSingleton(_settings);
    }

    private void AddMvc()
    {
        _services.AddMvc(options =>
        {
            options.EnableEndpointRouting = false;
        });
    }
}