using System.Web.Http;
using WebApi.Classic.Services;

namespace WebApi.Classic.Controllers
{
    public class HomeController : ApiController
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public string Get()
        {
            return homeService.Greetings();
        }
    }
}