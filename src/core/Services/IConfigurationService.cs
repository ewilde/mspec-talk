// -----------------------------------------------------------------------
// <copyright file="IConfigurationService.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Services
{
    /// <summary>
    /// Defines the behaviour for a configuration service
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// Gets the application setting.
        /// </summary>
        /// <typeparam name="T">type of the setting</typeparam>
        /// <param name="key">The key of the setting.</param>
        /// <returns>The value of the setting specified by the supplied <param name="key">key</param></returns>
        T GetApplicationSetting<T>(string key);
    }
}