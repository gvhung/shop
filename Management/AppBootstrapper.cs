﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Business.Services;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;
using Shop.Business.Managers;
using Shop.Contracts.Services;
using Shop.Management.ViewModels;

namespace Shop.Management
{
    public class AppBootstrapper : AutofacBootstrapper<ShellViewModel>
    {
        protected override void ConfigureContainer(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>();
            builder.RegisterType<CustomerManager>();
            builder.RegisterType<InvoiceManager>();

            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<InvoiceService>().As<IInvoiceService>();

            builder.RegisterType<MenuItemViewModel<SummaryViewModel>>();
            builder.RegisterType<MenuItemViewModel<ProductsViewModel>>();
            builder.RegisterType<MenuItemViewModel<CustomersViewModel>>();

            base.ConfigureContainer(builder);
        }

    }  
}
