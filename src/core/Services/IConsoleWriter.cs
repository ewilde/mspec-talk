// -----------------------------------------------------------------------
// <copyright file="IConsoleWriter.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Services
{
    using System;

    /// <summary>
    /// Defines behaviour for a console writer.
    /// </summary>
    public interface IConsoleWriter
    {
        /// <summary>
        /// Writes an information message to the console.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="formattingArguments">The formatting arguments.</param>
        void WriteInformation(string message, params object[] formattingArguments);

        /// <summary>
        /// Writes a debug message to the console.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="formattingArguments">The formatting arguments.</param>
        void WriteDebug(string message, params object[] formattingArguments);

        /// <summary>
        /// Writes an error message to the console.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="formattingArguments">The formatting arguments.</param>
        void WriteError(string message, params object[] formattingArguments);

        /// <summary>
        /// Writes a sucess message to the console.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="formattingArguments">The formatting arguments.</param>
        void WriteSucess(string message, params object[] formattingArguments);

        /// <summary>
        /// Writes a message to the console using a specific color.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="color">The color to use whilst writing to the console.</param>
        /// <param name="formattingArguments">The formatting arguments.</param>
        void Write(string message, ConsoleColor color = ConsoleColor.White, params object[] formattingArguments);
    }
}