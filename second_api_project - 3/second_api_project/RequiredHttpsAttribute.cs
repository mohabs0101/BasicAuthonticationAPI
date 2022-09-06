//enable this if u want auto call https when trigger  http


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;
//using System.Net.Http;
//namespace second_api_project
//{
//    public class RequiredHttpsAttribute :AuthorizationFilterAttribute
//    {
//        public override void OnAuthorization(HttpActionContext actionContext)
//        {
//            if(actionContext.Request.RequestUri.Scheme!=Uri.UriSchemeHttps)
//            {
//                //tell message 
//                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Found);
//                actionContext.Response.Content = new StringContent("<p>use https instade of http</p>");

//                //redirect to https automaticly
//                UriBuilder uriBuilder = new UriBuilder(actionContext.Request.RequestUri);
//                uriBuilder.Scheme = Uri.UriSchemeHttps;
//                uriBuilder.Port = 44328;

//                actionContext.Response.Headers.Location = uriBuilder.Uri;

//            }
//            else
//            {
//                base.OnAuthorization(actionContext);

//            }
//        }
//    }
//}