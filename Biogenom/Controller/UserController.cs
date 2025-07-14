using Biogenum.Domain.Models.Request;
using Biogenum.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biogenum.Controller
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController(IUserService userService) : CustomBaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserInfo([FromQuery]UserNutrientReportRequest request)
        {
            var response = await userService.GetUserInfoAsync(request);
            return CreateActionResult(response);
        }
    }
}