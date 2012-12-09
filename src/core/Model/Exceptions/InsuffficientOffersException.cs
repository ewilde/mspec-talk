// -----------------------------------------------------------------------
// <copyright file="InsuffficientOffersException.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Model
{
    using System;
    using System.Runtime.Serialization;

    using global::Machine.Specifications.Annotations;

    /// <summary>
    /// Exception is thrown when preparing a quote and there are insufficient
    /// lenders available.
    /// </summary>
    public class InsuffficientOffersException : Exception
    {
        /// <inheritdoc />
        public InsuffficientOffersException()
        {
        }

        /// <inheritdoc />
        public InsuffficientOffersException(string message)
            : base(message)
        {
        }

        /// <inheritdoc />
        public InsuffficientOffersException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <inheritdoc />
        protected InsuffficientOffersException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}