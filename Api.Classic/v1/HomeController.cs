using System.Web.Http;

namespace Api.Classic.v1
{
    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok("Hello from Api controller v1");
        }
    }
}