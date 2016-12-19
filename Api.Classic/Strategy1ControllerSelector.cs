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
    public class Strategy1ControllerSelector : DefaultHttpControllerSelector
    {       
        private static readonly int DefaultApiVersion = 1;

        public Strategy1ControllerSelector(HttpConfiguration configuration) 
            : base(configuration)
        {}

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var routeData = request.GetRouteData();
            if (routeData == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var requestedControllerName = string.Empty;
            if (routeData.Values != null && routeData.Values.ContainsKey("controller"))
                requestedControllerName = routeData.Values["controller"].ToString();

            if(string.IsNullOrEmpty(requestedControllerName))
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            var requestedVersionNo = request.GetRequestedApiVersion();
            if (requestedVersionNo == DefaultApiVersion)
                return base.SelectController(request);
            
            var allRegisteredControllers = GetControllerMapping();
            if(!allRegisteredControllers.Any())
                return base.SelectController(request);
            
            var controllerFormat = string.Format("{0}V{1}", requestedControllerName, requestedVersionNo);
            if(!allRegisteredControllers.ContainsKey(controllerFormat))
                return base.SelectController(request);

            return allRegisteredControllers[controllerFormat]; 
        } 
    }
}