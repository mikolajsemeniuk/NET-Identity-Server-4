using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace api.service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public string Get() => 
            "works";

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IEnumerable<string> Get(int id) => 
            ((ClaimsIdentity)User.Identity)
                                .Claims
                                .Where(c => c.Type == ClaimTypes.NameIdentifier)
                                .Select(c => c.Value)
                                .ToList();

        [HttpPost]
        public string Post() =>
            "added";

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public ActionResult<string> Put()
        {
            // won't work
            var role = User.FindFirstValue("role");
            return Ok(new { Id = User.FindFirstValue(Sub), Role = role });
        }

        [HttpGet("go")]
        [Authorize(Policy = "read_access")]
        public ActionResult Go() =>
            Ok("only moderator which has scope equals catalog.fullaccess");
            

        [HttpDelete]
        public ActionResult Delete()
        {
            if (User.IsInRole("Admin"))
                return Ok(new 
                { 
                    roles = ((ClaimsIdentity)User.Identity)
                                .Claims
                                .Where(c => c.Type == ClaimTypes.Role)
                                .Select(c => c.Value) 
                });
            return Forbid();
        }
    }
}
