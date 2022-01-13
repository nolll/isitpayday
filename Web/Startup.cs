using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Bootstrapping;
using Web.Settings;

namespace Web;

public class Startup
{
    private readonly AppSettings _settings;

    public Startup(IConfiguration configuration)
    {
        _settings = configuration.Get<AppSettings>();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        new ServiceConfig(_settings, services).Configure();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        new AppConfig(app, env).Configure();
    }
}