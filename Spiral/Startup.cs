﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Spiral.Startup))]
namespace Spiral
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
