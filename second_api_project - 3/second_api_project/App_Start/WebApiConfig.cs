using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using WebApiContrib.Formatting.Jsonp;
using System.Web.Http.Cors;

namespace second_api_project
{

    //aproch 2 will set default json formatter to browser 
    //public class CustomJsonFormatter : JsonMediaTypeFormatter
    //{
    //    public CustomJsonFormatter()

    //    {
    //        this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

    //    }

    //    public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
    //    {
    //        base.SetDefaultContentHeaders(type, headers, mediaType);
    //        headers.ContentType= new MediaTypeHeaderValue("application/json");
    //    }


    //}



    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //this class will aoutomaticly redirect to https
            //un comment this if u want required https for entire projct
            //config.Filters.Add(new RequiredHttpsAttribute());



            ////allow ajax access api jasonp way 1
            ////create jsonp formatter jsonpmediatypeformatter is refrenced from another client app
            //var jsonpformatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            ////insert jsonp formatter to formatters
            //config.Formatters.Insert(0,jsonpformatter);


            ////allow ajax access api cors way 2
            //EnableCorsAttribute cors = new EnableCorsAttribute("*","*","*");
            config.EnableCors(/*cors*/);


            //two approches to return json to browse insatade of xml 
            //approch 1 html
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            //aproch 1 json
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));


            ////aproch 2  above 
            //// register aproch 2 class
            //config.Formatters.Add(new CustomJsonFormatter());


            //this will remove xml formater if we even send xml in formate header in postman
            //will return json to browser because there is no xml
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            ////this will remove json formater if we even send json in formate header ofpostman
            ////will return xml to browser  
            //config.Formatters.Remove(config.Formatters.JsonFormatter);

            //this will change the shape of json in response to client from pascal to camel
            //intend json data 
            //config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            ////camel case insted of pascal case 
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();



        }
    }
}
