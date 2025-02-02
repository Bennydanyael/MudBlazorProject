﻿using Common.Abstract.SqlFactory;
using Common.Common.SqlFactory;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Service.Abstraction.Account;
using Service.Abstraction.Organization;
using Service.Abstraction.TokenHandler;
using Service.Service.Account;
using Service.Service.Organization;
using Service.Service.TokenHandler;
using Providers.Initializers;
using Providers.Abstraction.Context;

namespace Service.Infrastructure
{
    public static class ConfigurationServices
    {
        public static void AddConfigureServices(this IServiceCollection _service)
        {
            _service.AddScoped<IJWTTokenHandler, JWTTokenHandler>();
            _service.AddScoped<IAccountService, AccountService>();
            _service.AddScoped<IDbInitializer, InitializerData>();

            _service.AddScoped<IOrgStructureService, OrgStructureService>();

            //_service.AddScoped<ICompanyService, CompanyService>();
            //_service.AddScoped<IDepartmentService, DepartmentService>();
            //_service.AddScoped<IDivisionService, DivisionService>();
            //_service.AddScoped<ISectionService, SectionService>();
            //_service.AddScoped<IPositionService, PositionService>();
            //_service.AddScoped<IWorkLocationService, WorkLocationService>();

            //_service.AddScoped<IEmployeeService, EmployeeService>();
            //_service.AddScoped<IEmployeeService, EmployeeService>();
            //_service.AddScoped<IEmployeeTransactionService, EmployeeTransactionService>();

            _service.AddScoped<ISqlObjectFactory, SqlObjectFactory>();
        }

    }
}
