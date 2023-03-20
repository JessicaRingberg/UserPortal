using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserPortal
{
    [Route("/[controller]")]
    [ApiController]
    public class Style : ControllerBase
    {
        public async Task<ActionResult> ChangeTheme([FromQuery] bool style)
        {
            Response.Cookies.Append("style", style.ToString());
            return Redirect("/");
        }


    }
}
