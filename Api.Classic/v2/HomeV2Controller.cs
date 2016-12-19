using System.Web.Http;

namespace Api.Classic.v2
{
    public class HomeV2Controller : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok("Hello from api controller v2");
        }
    }
}