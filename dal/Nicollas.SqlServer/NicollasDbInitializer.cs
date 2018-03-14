// <copyright file="NicollasDbInitializer.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.SqlServer
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Nicollas.Core;
    using Nicollas.SqlServer.Seeders;

    /// <summary>
    /// This class is used to initialize the Database
    /// </summary>
    public static class NicollasDbInitializer
    {
        /// <summary>
        /// Run Update Database
        /// </summary>
        /// <param name="context">The Context</param>
        public static void Initialize(IDbContext context)
        {
            context.CreateDataBase();
        }

        /// <summary>
        /// Execute the Seed method to database
        /// </summary>
        /// <param name="worker">The UnitOfWorker</param>
        /// <param name="extradependencies">The array of deppendencies required by the seeders</param>
        public static void Seed(IUnitOfWork worker, params object[] extradependencies)
        {
#if DEBUG
            // AllocConsole();
            if (Debugger.IsAttached == false)
            {
                // Debugger.Launch(); // Uncomment this to debug the seeder method
            }
#endif

            // Calling assembly and get all types that implement an Interface and is classe
            var type = typeof(ISeeder);
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p) && p.IsClass);
            Console.WriteLine($"Found {types.Count()} seeders");

            // Now we get the type and convert to a instance of
            var instances = types.ToList().ConvertAll(row =>
            {
                var instance = Activator.CreateInstance(row);
                return instance as ISeeder; // cast to the Interface to be used
            });

            instances.ForEach(seeder =>
            {
                Console.WriteLine($"Running seeder {seeder.GetType().Name}");
                seeder.Seed(worker, extradependencies);
            });
        }
    }
}
