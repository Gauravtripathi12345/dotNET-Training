using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Swashbuckle.Application;

namespace WebAPIDemo.App_Start
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                .EnableSwagger(c => c.SingleApiVersion("v1", "ErroHandlingWebAPI"))
                .EnableSwaggerUi();
        }
    }
}