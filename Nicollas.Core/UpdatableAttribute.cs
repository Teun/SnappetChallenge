// <copyright file="UpdatableAttribute.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>

namespace Nicollas.Core
{
    using System;

    /// <summary>
    /// Decorate an property with this to define the attribute can be updatable by default UnitOfWork Update
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class UpdatableAttribute : Attribute
    {
    }
}
