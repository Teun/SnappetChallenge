// <copyright file="UserExecutor.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.SqlServer.Seeders.Executors
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using Nicollas.Core;
    using Nicollas.Core.Entities.Identity;

    /// <summary>
    /// This class seed the User
    /// </summary>
    internal class UserExecutor : ISeeder
    {
        /// <inheritdoc/>
        public void Seed(IUnitOfWork worker, params object[] extraDependencies)
        {
            this.CheckDependencies(extraDependencies);

            var roleRep = worker.Repository<Role, Guid>();
            Role role = roleRep.GetAllQueryableAsync(false).Result.FirstOrDefault();
            if (role == null)
            {
                role = new Role
                {
                    Name = "Admin",
                    Strong = 1000f,
                };

                worker.BeginTransaction();
                roleRep.Add(role);

                role.Claims.Add(new RoleClaim(ClaimDefinition.Type.Bill, ClaimDefinition.Value.Allow));
                role.Claims.Add(new RoleClaim(ClaimDefinition.Type.Order, ClaimDefinition.Value.Allow));
                role.Claims.Add(new RoleClaim(ClaimDefinition.Type.Product, ClaimDefinition.Value.Allow));
                role.Claims.Add(new RoleClaim(ClaimDefinition.Type.Table, ClaimDefinition.Value.Allow));
                role.Claims.Add(new RoleClaim(ClaimDefinition.Type.User, ClaimDefinition.Value.Allow));
                role.Claims.Add(new RoleClaim(ClaimDefinition.Type.Register, ClaimDefinition.Value.Allow));
                roleRep.Update(role);

                worker.Commit();
            }

            var userRepo = worker.Repository<User, Guid>();
            var userManager = extraDependencies.First(row => row is UserManager<User>) as UserManager<User>;
            User user = userRepo.GetAllQueryableAsync(false).Result.FirstOrDefault();

            if (user == null)
            {
                user = new User()
                {
                    UserName = "Admin",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    FirstName = "System ",
                    LastName = "Administrator",
                };

                worker.BeginTransaction();

                var userResult = userManager.CreateAsync(user, "$naPPe1").Result;
                userResult = userManager.AddToRoleAsync(user, "Admin").Result;

                worker.Commit();
            }
        }

        private void CheckDependencies(object[] dependencies)
        {
            if (!dependencies.Any())
            {
                throw new ArgumentException($"The UserExecutors needs an {nameof(UserManager<User>)} and an {nameof(RoleManager<Role>)}");
            }

            if (!dependencies.Any(row => row is UserManager<User>))
            {
                throw new ArgumentException($"cannot find the {nameof(UserManager<User>)} dependency");
            }

            if (!dependencies.Any(row => row is RoleManager<Role>))
            {
                throw new ArgumentException($"cannot find the {nameof(RoleManager<Role>)} dependency");
            }
        }
    }
}
