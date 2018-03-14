// <copyright file="ISeeder.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.SqlServer.Seeders
{
    using Nicollas.Core;

    /// <summary>
    /// This innterface is used to automatically detect seed methods in an Migration.
    /// Implement an class with this interface and the Seed method will be called on an Migration
    /// </summary>
    internal interface ISeeder
    {
        /// <summary>
        /// Set here the seed logic
        /// </summary>
        /// <param name="worker">the Worker Context</param>
        /// <param name="extraDependencies">Extra dependencies if the seeder needs</param>
        void Seed(IUnitOfWork worker, params object[] extraDependencies);
    }
}
