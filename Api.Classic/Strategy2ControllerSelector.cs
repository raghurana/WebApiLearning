using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Api.Classic
{
    public class Strategy2ControllerSelector : DefaultHttpControllerSelector
    {
        private readonly HttpConfiguration configuration;
        private readonly ICollection<Type> controllerTypes;

        public Strategy2ControllerSelector(HttpConfiguration configuration) 
            : base(configuration)
        {
            this.configuration      = configuration;
            var assembliesResolver  = configuration.Services.GetAssembliesResolver();
            var controllersResolver = configuration.Services.GetHttpControllerTypeResolver();
            controllerTypes         = controllersResolver.GetControllerTypes(assembliesResolver);
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var routeData = request.GetRouteData();
            if (routeData == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var requestedControllerName = string.Empty;
            if (routeData.Values != null && routeData.Values.ContainsKey("controller"))
                requestedControllerName = routeData.Values["controller"].ToString();

            if (string.IsNullOrEmpty(requestedControllerName))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var requestedVersion = request.GetRequestedApiVersion().ToString();
            var matchedType      = controllerTypes.FirstOrDefault(type =>
                                        type.Name.StartsWith(requestedControllerName, StringComparison.InvariantCultureIgnoreCase) &&
                                        type.Namespace.Contains(requestedVersion));

            if(matchedType == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return new HttpControllerDescriptor(configuration, matchedType.Name, matchedType);
        }
    }
}