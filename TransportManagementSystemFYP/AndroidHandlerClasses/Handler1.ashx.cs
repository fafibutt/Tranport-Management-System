using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JsonServices;
using JsonServices.Web;

namespace TransportManagementSystemFYP.AndroidHandlerClasses
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public Handler1()
        {
            this.service.Name = "JSONWebAPI";
            this.service.Description = "JSON API for android appliation";
            InterfaceConfiguration IConfig = new InterfaceConfiguration("RestAPI", typeof(TransportManagementSystemFYP.AndroidHandlerClasses.IServiceAPI), typeof(TransportManagementSystemFYP.AndroidHandlerClasses.ServiceAPI));
            this.service.Interfaces.Add(IConfig);
        }

    }
}
