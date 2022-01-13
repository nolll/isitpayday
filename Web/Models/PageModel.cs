using Web.Settings;

namespace Web.Models;

public class PageModel
{
    public string Version { get; }

    public PageModel(AppSettings appSettings)
    {
        Version = appSettings.Version;
    }
}