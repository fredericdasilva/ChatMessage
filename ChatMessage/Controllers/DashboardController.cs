using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatMessage.Models.Entities;
using System.Security.Claims;

namespace ChatMessage.Controllers
{
    //[Authorize(Policy = "ApiUser")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        // GET api/dashboard/home
        [HttpGet("home")]
        public async Task<IActionResult> GetHome()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            AppUser user = await _userManager.FindByNameAsync(currentUserName);

            return new OkObjectResult(new { Message = "Welcome to the chat " + user.FirstName +" !" });
        }
    }
}
