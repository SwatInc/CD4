﻿using Autofac;
using CD4.UI.Library.ViewModel;
using CD4.UI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //register application start
            builder.RegisterType<Cd4Application>().As<ICd4Application>();

            //register viewModels
            builder.RegisterAssemblyTypes(Assembly.Load("CD4.UI.Library"))
                .Where(t => t.Namespace.Contains("ViewModel"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == $"I{t.Name}"));

            return builder.Build();
        }
    }
}
