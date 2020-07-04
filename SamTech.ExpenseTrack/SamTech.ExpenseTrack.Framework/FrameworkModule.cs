using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamTech.ExpenseTrack.Framework
{
    public class FrameworkModule : Module
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public FrameworkModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FrameworkContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ExpenseRepository>().As<IExpenseRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExpenseUnitOfWork>().As<IExpenseUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExpenseService>().As<IExpenseService>()
                .InstancePerLifetimeScope();
            
            base.Load(builder);
        }
    }
}
