//-----------------------------------------------------------------------
// <copyright file="NicollasIdentity.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
// <author>Alejandro Ferrandiz</author>
//-----------------------------------------------------------------------
namespace Nicollas.SqlServer.Identity
{
    using System;
    using System.Linq;
    using Core;
    using Core.Entities.Identity;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// This class implement a lot of Identity Store interface
    /// </summary>
    public sealed partial class NicollasIdentity :
        IQueryableUserStore<User>,
        IQueryableRoleStore<Role>
    {
        /// <summary>
        /// The unitOfWork
        /// </summary>
        private IUnitOfWork unitOfWork;

        /// <summary>
        /// The logger
        /// </summary>
        private ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="NicollasIdentity" /> class
        /// </summary>
        /// <param name="unitOfWork">The context</param>
        /// <param name="logger">The logger</param>
        public NicollasIdentity(IUnitOfWork unitOfWork, ILogger logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        /// <summary>
        /// Gets the roles
        /// </summary>
        public IQueryable<Role> Roles
        {
            get
            {
                this.Logger("IQueryable<Role> Roles -> Obtain all the roles");

                return this.unitOfWork.Repository<Role, Guid>().GetAllQueryableAsync(false).Result;
            }
        }

        /// <summary>
        /// Gets the users
        /// </summary>
        public IQueryable<User> Users
        {
            get
            {
                this.Logger("IQueryable<User> Users -> Obtain all the users");
                return this.unitOfWork.Repository<User, Guid>().GetAllQueryableAsync(false).Result;
            }
        }

        /// <summary>
        /// Dispose the store
        /// </summary>
        public void Dispose()
        {
            this.Logger($"Dispose the context in Identity");

            this.unitOfWork.Dispose();
        }

        /// <summary>
        /// Logger like a debug
        /// </summary>
        /// <param name="msg">The info message</param>
        private void Logger(string msg)
        {
            if (this.logger != null)
            {
                this.logger.Info = msg;
            }
        }
    }
}
