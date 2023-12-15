using API.BusinessLayer.Builders;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyIp : ControllerBase
    {
        [HttpGet(Name = "GetMyIp")]
        public string Get()
        {
            var ip = HttpContext.Connection.RemoteIpAddress!.ToString();
            var guid = GetGuidInCookie();

            if (!EntityBuilder.ContainsUser(guid))
                EntityBuilder.CreateUser(guid, ip);

            return EntityBuilder.GetIpInfo(guid);
        }

        private string GetGuidInCookie()
        {
            Request.Cookies.TryGetValue("Guid", out string? guid);
            return guid ?? CreateCookieAndGetGuid();
        }

        private string CreateCookieAndGetGuid()
        {
            var cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now,
                MaxAge = new TimeSpan(365, 0, 0, 0),
                IsEssential = true
            };
            var guid = Guid.NewGuid().ToString();
            Response.Cookies.Append("Guid", guid, cookieOptions);
            return guid;
        }
    }
}
