// -----------------------------------------------------------------------
// <copyright file="FileService.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Services
{
    using System.IO;

    /// <inheritdoc />
    public class FileService : IFileService
    {
        /// <inheritdoc />
        public string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }

        /// <inheritdoc />
        public void Delete(string path)
        {
            File.Delete(path);
        }

        /// <inheritdoc />
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        /// <inheritdoc />
        public void AppendAllText(string path, string contents)
        {
            File.AppendAllText(path, contents);
        }

        /// <inheritdoc />
        public void Copy(string sourceFileName, string destFileName, bool overwrite)
        {
            File.Copy(sourceFileName, destFileName, true);
        }
    }
}