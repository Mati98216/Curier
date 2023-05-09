using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using CurierProject.Domain;

[assembly: OwinStartup(typeof(CurierProject.Startup))]

namespace CurierProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
