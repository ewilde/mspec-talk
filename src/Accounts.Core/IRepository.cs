// -----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="UBS AG">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Accounts.Core
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IEnumerable<T> Get();

        void Save();
    }
}