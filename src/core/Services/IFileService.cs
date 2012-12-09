// -----------------------------------------------------------------------
// <copyright file="IFileService.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Services
{
    using System.IO;

    /// <summary>
    /// Wrapper around <see cref="File"/> to provide testability.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string array containing all lines of the file.</returns>
        string[] ReadAllLines(string path);

        /// <summary>
        /// Deletes the specified file. An exception is not thrown if the specified file does not exist.
        /// </summary>
        /// <param name="path">The name of the file to be deleted. Wildcard characters are not supported.</param>
        void Delete(string path);

        /// <summary>
        /// Determines whether the specified file exists.
        /// </summary>
        /// <param name="path">The file to check.</param>
        /// <returns><c>true</c> if the caller has the required permissions and path contains the name of an existing file; otherwise, <c>false</c>. This method also returns false if path is null, an invalid path, or a zero-length string. If the caller does not have sufficient permissions to read the specified file, no exception is thrown and the method returns false regardless of the existence of path.</returns>
        bool Exists(string path);

        /// <summary>
        /// Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this method creates a file, writes the specified string to the file, then closes the file        /// </summary>
        /// <param name="path">The path to the file to append to.</param>
        /// <param name="contents">The contents.</param>
        void AppendAllText(string path, string contents);

        /// <summary>
        /// Copies an existing file to a new file. Overwriting a file of the same name is allowed.
        /// </summary>
        /// <param name="sourceFileName">The source file.</param>
        /// <param name="destFileName">The destination file.</param>
        /// <param name="overwrite">if set to <c>true</c> overwrites an existing file.</param>
        void Copy(string sourceFileName, string destFileName, bool overwrite);
    }
}