using Microsoft.AspNetCore.Mvc;

namespace Biogenum.Controller;

public class CustomBaseController : ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(Response<T> response)
    {
        if (response.StatusCode == 204)
            return (IActionResult)new ObjectResult((object)null)
            {
                StatusCode = new int?(response.StatusCode)
            };
        return (IActionResult)new ObjectResult((object)response)
        {
            StatusCode = new int?(response.StatusCode)
        };
    }
}