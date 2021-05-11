﻿using FuntionalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public static class DbContextInitializer
    {
        public static async Task Initialize(DataProtectionKeysContext dataProtectionKeysContext, ApplicationDbContext applicationDbContext, IFunctionalSvc functionalSvc)
        {
            // Check, if db DataProtectionKeysContext is crated
            // Check, if db ApplicationDbContext is created
            await dataProtectionKeysContext.Database.EnsureCreatedAsync();
            await applicationDbContext.Database.EnsureCreatedAsync();

            // Check, if db contains any users. If db is not empty, then db has been already seeded
            if (applicationDbContext.ApplicationUsers.Any())
            {
                return;
            }

            // if empty create Admin User and App User
            await functionalSvc.CreateDefaultAdminUser();
            await functionalSvc.CreateDefaultUser();
        }
    }
}
