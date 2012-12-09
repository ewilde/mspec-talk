// -----------------------------------------------------------------------
// <copyright file="AppConfigConfigurationSerivce.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Services
{
    using System.Configuration;

    using Financial.Loan.Core.Utility;

    /// <summary>
    /// Retrieves configuration from the application config file.
    /// </summary>
    public class AppConfigConfigurationSerivce : IConfigurationService
    {
        /// <inheritdoc />
        public T GetApplicationSetting<T>(string key)
        {
            return ConfigurationManager.AppSettings[key].To<T>();
        }
    }
}