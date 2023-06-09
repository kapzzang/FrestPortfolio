using Microsoft.Owin;
using Owin;
using Portfolio;
using System;
using System.Collections.Generic;

[assembly: OwinStartupAttribute(typeof(SignalR.Startup))]
namespace SignalR
{
    public class Startup
    {
        public static Dictionary<string, string> userConIdDic = new Dictionary<string, string>();
        
       
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888   
            app.MapSignalR();
        }
    }
}