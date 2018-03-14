//-----------------------------------------------------------------------
// <copyright file="NicollasContextFactory.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.SqlServer
{
    using Microsoft.EntityFrameworkCore.Design;

    /// <summary>
    /// This class implement <see cref="IDesignTimeDbContextFactory{NicollasContext}"/>
    /// </summary>
    public class NicollasContextFactory : IDesignTimeDbContextFactory<NicollasContext>
    {
        /// <summary>
        /// Connection string
        /// </summary>
#if DEBUG
        private const string CONNECTIONSTRING = "server=localhost;user id=snappetChallenge;password=Pa$$word;database=snappet";
#else
        private const string CONNECTIONSTRING = "server=localhost;user id=snappetChallenge;password=Pa$$word;database=snappet";
#endif

        /// <summary>
        /// This method create a DataBase Context
        /// </summary>
        /// <param name="args">Arguments to context</param>
        /// <returns>Return a DataBase Context</returns>
        public NicollasContext CreateDbContext(string[] args)
        {
            return new NicollasContext(CONNECTIONSTRING, null);
        }
    }
}