using Ninject;
using WebApi.Classic.Services;

namespace WebApi.Classic
{
    public static class DependencyMap
    {
        public static void Init(IKernel kernel)
        {
            kernel.Bind<IHomeService>().To<HelloWorldHomeService>();
        }
    }
}