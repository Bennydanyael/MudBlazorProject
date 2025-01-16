using Domain.Models.Claims;
using Domain.Models.Organization;
using Domain.Models.Personal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Abstraction.Context
{
    public interface IBaseDbContext : IDisposable
    {
        //Organization
        DbSet<Announcement> Announcement { get; }
        DbSet<CompanyProfile> CompanyProfile { get; }
        DbSet<CompanyPolicy> CompanyPolicy { get; }


        //Claims
        DbSet<Reimbursement> Reimbursement { get; }

        //Employee
        DbSet<Employee> Employee { get; }
    }
}
