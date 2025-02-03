using Domain.Models.Organization;
using Domain.Models.Personal;
using IdentityDomain.Abstract.Users;
using IdentityDomain.Models.Users;
using IdentityProvider.Abstraction;
using IdentityProvider.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Providers.Abstraction.Context;
using Providers.DataProvider.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Initializers
{
    public class InitializerData : IDbInitializer
    {
        #region [Fields]
        private readonly ModelBuilder _builder;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        #endregion [Fields]

        #region [Ctor]
        public InitializerData(UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            ModelBuilder builder)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _builder = builder;
        }
        #endregion [Ctor]

        #region [Method]
        public void InitializeSets(BaseDbContext _context, AccountDbContext _accountDbContext)
        {
            _context.Database.EnsureCreated();
            _accountDbContext.Database.EnsureCreated();
            try
            {
                if (!_accountDbContext.AccountUser.Any())
                {
                    if (_accountDbContext.AccountRole.Any(r => r.Name == "admin")) return;

                    _roleManager.CreateAsync(new IdentityRole("admin")).ConfigureAwait(false);
                    _roleManager.CreateAsync(new IdentityRole("SuperAdmin")).ConfigureAwait(false);

                    _userManager.CreateAsync(new AccountUser
                    {
                        UserName = "bennydanyael@gmail.com",
                        Email = "bennydanyael@gmail.com",
                        EmailConfirmed = true,
                        PhoneNumber = "+622112345"
                    }, "base-project").ConfigureAwait(false);
                    _userManager.AddToRoleAsync(
                         _accountDbContext.AccountUser.FirstOrDefault(u => u.Email == "bennydanyael@gmail.com"), "admin")
                        .ConfigureAwait(false);
                }
                #region Add Organization
                var _newCompId = Guid.NewGuid();
                var _newDivId = Guid.NewGuid();
                var _newDeptId = Guid.NewGuid();
                var _newPosId = Guid.NewGuid();

                if (!_context.CompanyProfile.Any())
                {
                    _builder.Entity<CompanyProfile>().HasData(
                        new CompanyProfile
                        {
                            Id = _newCompId,
                            Code = "BC",
                            Name = "PT Base Company Tbk",
                            Brand = "Base Project",
                            CreatedAt = "Initializer",
                            CreatedDate = DateTime.Now,
                            Phone = "123456",
                            IsDeleted = false,
                            Address = "DKI Jakarta"
                        });
                    _builder.Entity<Division>().HasData(
                        new Division
                        {
                            Id = _newDivId,
                            Code = "HRGA",
                            Name = "Human Resource General Affair",
                            CreatedAt = "Initializer",
                            CreatedDate = DateTime.Now,
                            CompanyId = _newCompId,
                        });
                    _builder.Entity<Department>().HasData(
                        new Department
                        {
                            Id = Guid.NewGuid(),
                            Code = "HRD",
                            Name = "Human Resource",
                            CreatedAt = "Initializaer",
                            CreatedDate = DateTime.Now,
                            IsDeleted = false,
                            DivisionId = _newDivId,
                        });
                    _builder.Entity<Position>().HasData(
                        new Position
                        {
                            Id = _newPosId,
                            Code = "CEO",
                            Name = "Chif Executive Office",
                            CreatedAt = "Initializer",
                            CreatedDate = DateTime.Now,
                            CompanyId = _newCompId,
                            DepartmentId = _newDeptId,
                            JobDescription = "The Chief Executive Officer (CEO) is the highest-ranking executive of any company. They are responsible for ensuring that the business operates at a profit and meets its goals. They need to know how best to approach new opportunities, including delegating tasks or directing agendas to drive profitability by managing organizational structure.",
                            Responsibilities = "Setting and executing the organization’s strategy\r\nAllocating capital\r\nBuilding and overseeing the executive team\r\nImplementing the goals, targets and strategic objectives as determined by the board of directors\r\nReporting the status of the business to the board of directors"
                        },
                        new Position
                        {
                            Id = Guid.NewGuid(),
                            Code = "COO",
                            Name = "Chif Operation Office",
                            CreatedAt = "Initializer",
                            CreatedDate = DateTime.Now,
                            CompanyId = _newCompId,
                            DepartmentId = _newDeptId,
                            JobDescription = "The Chief Executive Officer (CEO) is the highest-ranking executive of any company. They are responsible for ensuring that the business operates at a profit and meets its goals. They need to know how best to approach new opportunities, including delegating tasks or directing agendas to drive profitability by managing organizational structure.",
                            Responsibilities = "Setting and executing the organization’s strategy\r\nAllocating capital\r\nBuilding and overseeing the executive team\r\nImplementing the goals, targets and strategic objectives as determined by the board of directors\r\nReporting the status of the business to the board of directors"
                        },
                        new Position
                        {
                            Id = Guid.NewGuid(),
                            Code = "BoC",
                            Name = "Board of Commissioners",
                            CreatedAt = "Initializer",
                            CreatedDate = DateTime.Now,
                            CompanyId = _newCompId,
                            DepartmentId = _newDeptId,
                            JobDescription = "The duties of the Board of Commissioners is to conduct general and/or specific supervision in compliance with the Articles of Association of the Company and to give advice to the Board of Directors as they seem fit. Please be informed that the Commissioner is not involved in the day-to-day operations of the Company, such actions being the responsibility of the Director. Therefore, the Commissioner cannot represent the Company in transaction deals and/or signing agreements, unless in certain situations as stipulated in the Company Law.",
                            Responsibilities = "Mengawasi perusahaan\r\n\r\nDewan komisaris di Indonesia bertanggung jawab untuk mengawasi perusahaan dan memberikan rekomendasi yang baik kepada dewan direksi sesuai dengan anggaran dasar perusahaan.\r\n\r\nDireksi kemudian akan menggunakan rekomendasi dewan komisaris untuk mengelola perusahaan seefisien mungkin. Komisaris tidak dihitung dalam operasi bisnis sehari-hari.\r\n\r\nLaporan keuangan tahunan perusahaan yang disetujui\r\n\r\nKomisaris juga akan diminta untuk menyetujui laporan keuangan tahunan perusahaan.\r\n\r\nTinjau anggaran tahun keuangan berikutnya\r\n\r\nTugas lain komisaris adalah meninjau anggaran tahun buku berikutnya."
                        });
                }
                #endregion Add Organization

                #region Add Personal Employee
                if (!_context.Employee.Any())
                { 
                    _builder.Entity<Employee>().HasData(
                         new Employee
                         {
                             No = $"{string.Format(DateTime.UtcNow.Year.ToString() + DateTime.UtcNow.Month.ToString() + DateTime.UtcNow.Day.ToString())}",
                             Name = "Silaban, Benny",
                             FirstName = "Benny",
                             LastName = "Silaban",
                             CreatedAt = "System",
                             CreatedDate = DateTime.UtcNow,
                             IsDeleted = false,
                             PositionId = _newPosId,
                         });
                }
                #endregion Add Personal Employee

                #region Add Attendance 
                //_builder.Entity<ShiftType>().HasData(
                //    new ShiftType
                //    {
                //        Code = "OH",
                //        Name = "Office Hour",
                //        Description = "Shift Office Hour",
                //        InsertBy = "Initalizer",
                //        InsertDate = DateTime.Now,
                //        IsDeleted = false
                //    });

                //_builder.Entity<AttendanceStatus>().HasData(
                //    new AttendanceStatus
                //    {
                //        Code = "P",
                //        Name = "Present",
                //        InsertBy = "Initializer",
                //        InsertDate = DateTime.Now,
                //    },
                //    new AttendanceStatus
                //    {
                //        Code = "A",
                //        Name = "Absent",
                //        InsertBy = "Initializer",
                //        InsertDate = DateTime.Now,
                //    },
                //    new AttendanceStatus
                //    {
                //        Code = "O",
                //        Name = "Off",
                //        InsertBy = "Initializer",
                //        InsertDate = DateTime.Now,
                //    },
                //    new AttendanceStatus
                //    {
                //        Code = "AB",
                //        Name = "Abnomal",
                //        InsertBy = "Initializer",
                //        InsertDate = DateTime.Now,
                //    }
                //);

                //_builder.Entity<AttendanceTransaction>().HasData(
                //    new AttendanceTransaction
                //    {
                //        Code = "P",
                //        EmployeeId = 1,
                //        Status = "Present",
                //        Description = "Initializer",
                //        StartDate = DateTime.Now,
                //        TimeIn = DateTime.UtcNow,
                //        EndDate = DateTime.Now,
                //        TimeOut = DateTime.UtcNow,
                //        AttendanceStatusId = 1,
                //        InsertBy = "Initializer",
                //        InsertDate = DateTime.Now,
                //        IsAbnormal = false,
                //        ShiftId = 1
                //    });
                #endregion Add Attendance

                #region Add Menu
                //_builder.Entity<Domain.Models.Menu.MenuNavigation>().HasData(
                //    new Domain.Models.Menu.MenuNavigation
                //    {
                //        Id = 1,
                //        Label = "Organization",
                //        Area = "Organization",
                //        ParentGuid = Guid.NewGuid(),
                //        IsDeleted = false,
                //        Icon = "",
                //        Action = "Index",
                //        Controller = "",
                //        MenuGuid = Guid.NewGuid(),
                //        RoleName = "Organization_Index",
                //        InsertBy = "System",
                //        InsertDate = DateTime.UtcNow,
                //        Order = 1,
                //        ModifiedBy = null,
                //        ModifiedDate = null
                //    },
                //    new Domain.Models.Menu.MenuNavigation
                //    {
                //        Id = 2,
                //        Label = "Employee",
                //        Area = "Employee",
                //        ParentGuid = Guid.NewGuid(),
                //        IsDeleted = false,
                //        Icon = "",
                //        Action = "Index",
                //        Controller = "EmployeeController",
                //        MenuGuid = Guid.NewGuid(),
                //        RoleName = "Employee_Index",
                //        InsertBy = "System",
                //        InsertDate = DateTime.UtcNow,
                //        Order = 2,
                //        ModifiedBy = null,
                //        ModifiedDate = null
                //    },
                //    new Domain.Models.Menu.MenuNavigation
                //    {
                //        Id = 3,
                //        Label = "Leave",
                //        Area = "Leave",
                //        ParentGuid = Guid.NewGuid(),
                //        IsDeleted = false,
                //        Icon = "",
                //        Action = "Index",
                //        Controller = "LeaveController",
                //        MenuGuid = Guid.NewGuid(),
                //        RoleName = "Leave_Index",
                //        InsertBy = "System",
                //        InsertDate = DateTime.UtcNow,
                //        Order = 3,
                //        ModifiedBy = null,
                //        ModifiedDate = null
                //    },
                //    new Domain.Models.Menu.MenuNavigation
                //    {
                //        Id = 4,
                //        Label = "Attendance",
                //        Area = "Attendance",
                //        ParentGuid = Guid.NewGuid(),
                //        IsDeleted = false,
                //        Icon = "",
                //        Action = "Index",
                //        Controller = "AttendanceController",
                //        MenuGuid = Guid.NewGuid(),
                //        RoleName = "Attendance_Index",
                //        InsertBy = "System",
                //        InsertDate = DateTime.UtcNow,
                //        Order = 4,
                //        ModifiedBy = null,
                //        ModifiedDate = null
                //    });
                #endregion Add Menu
            }catch(Exception _ex)
            {

            }

            _context.SaveChanges();
            _accountDbContext.SaveChanges();
        }
        #endregion [Method]
    }
}
