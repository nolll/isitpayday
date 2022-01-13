using System.Text;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class JsonResult : ActionResult
{
    public JsonResult(object data)
    {
        Data = data;
    }

    [UsedImplicitly]
    public Encoding ContentEncoding { get; set; }

    [UsedImplicitly]
    public string ContentType { get; set; }

    [UsedImplicitly]
    public object Data { get; set; }
}