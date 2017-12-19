using Ninject.Web.Common.WebHost;
using System.Web.Http;
using Ninject;

namespace WebApi.Classic
{
    public class WebApiApplication : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            DependencyMap.Init(kernel);

            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
