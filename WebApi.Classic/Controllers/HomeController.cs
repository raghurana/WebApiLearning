using System.Web.Http;

namespace WebApi.Classic.Controllers
{
    public class HomeController : ApiController
    {
        public string Get()
        {
            return "Hello World";
        }
    }
}