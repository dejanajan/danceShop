﻿using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(DanceShop.Startup))]
namespace Prodaja_Pasa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            throw new NotImplementedException();
        }
    }
}
