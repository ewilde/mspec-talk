// -----------------------------------------------------------------------
// <copyright file="InvalidAmountRequestedException.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Model
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception that is thrown when an invalid amount of money is
    /// request during a loan applicatin.
    /// </summary>
    [Serializable]
    public class InvalidAmountRequestedException : Exception
    {
        /// <inheritdoc />
        public InvalidAmountRequestedException()
        {
        }

        /// <inheritdoc />
        public InvalidAmountRequestedException(string message)
            : base(message)
        {
        }

        /// <inheritdoc />
        public InvalidAmountRequestedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <inheritdoc />
        protected InvalidAmountRequestedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}