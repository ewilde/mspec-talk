// -----------------------------------------------------------------------
// <copyright file="InsufficientFundsException.cs" company="UBS AG">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Accounts.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InsufficientFundsException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public InsufficientFundsException()
        {
        }

        public InsufficientFundsException(string message)
            : base(message)
        {
        }

        public InsufficientFundsException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected InsufficientFundsException(
            SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}