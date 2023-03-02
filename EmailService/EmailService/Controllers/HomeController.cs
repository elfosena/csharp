using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.Controllers
{
    [Authorize]
    [ApiController]
    public class HomeController : Controller
    {
        public List<string> colorList = new List<string>() { "blue", "red", "green" };

        [HttpGet("GetColorList")]
        public List<string> GetColorList()
        {
            try
            {
                return colorList;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
