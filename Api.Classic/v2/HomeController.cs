using System.Web.Http;

namespace Api.Classic.v2
{
    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok("v2 with same name");
        }
    }
}