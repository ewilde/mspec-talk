// -----------------------------------------------------------------------
// <copyright file="LoanQuoteController.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------

using Rule.Financial.Loan.Core.Data;

namespace Rule.Financial.Loan.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Financial.Loan.Core.Data;

    /// <summary>
    /// Implements the default way for handling requests for quotes.
    /// </summary>
    public class LoanQuoteController : ILoanQuoteController
    {
        /// <summary>
        /// Caches the list of offers from the <see cref="Repository"/>.
        /// </summary>
        private IEnumerable<IOffer> offers;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoanQuoteController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="loanQuote">The loan quote.</param>
        public LoanQuoteController(IRepository<IOffer> repository, ILoanQuote loanQuote)
        {
            this.Repository = repository;
            this.Quote = loanQuote;
        }

        /// <summary>
        /// Gets or sets the loan quote repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        public IRepository<IOffer> Repository { get; set; }

        /// <summary>
        /// Gets or sets the loan quote.
        /// </summary>
        /// <value>
        /// The loan quote.
        /// </value>
        public ILoanQuote Quote { get; set; }

        /// <summary>
        /// Gets the list of offers.
        /// </summary>
        public IEnumerable<IOffer> Offers
        {
            get
            {
                if (this.offers == null)
                {
                    this.offers = this.Repository.Get();
                }

                return this.offers;
            }
        }

        /// <summary>
        /// Gets the total amount available to be loaned out.
        /// </summary>
        public decimal TotalAmountAvailable
        {
            get
            {
                return this.Offers.Sum(item => item.Amount);
            }
        }

        /// <summary>
        /// Gets or sets the amount requested.
        /// </summary>
        /// <value>
        /// The amount requested.
        /// </value>
        protected decimal AmountRequested { get; set; }

        /// <inheritdoc />
        public ILoanQuote Prepare(decimal amount)
        {
            this.Quote = new StandardLoanQuote { RequestedAmount = amount };
            this.AmountRequested = amount;

            if (this.AmountRequested > this.TotalAmountAvailable)
            {
                throw new InvalidAmountRequestedException(
                    string.Format(
                        "You requested {0}, unfortunately there is only {1} being offered by our lenders at the moment. Please choose a loan of no more than {1}.",
                        this.AmountRequested.ToString("c", this.Quote.Currency),
                        this.TotalAmountAvailable.ToString("c", this.Quote.Currency)));
            }

            this.AssignLenders();
            this.Quote.Calculate();
            return this.Quote;
        }

        /// <summary>
        /// Assigns the lenders to the current <see cref="Quote"/>.
        /// </summary>
        public void AssignLenders()
        {
            List<IAssignedOffer> assignedOffers = new List<IAssignedOffer>();
            this.Quote.Lenders.Clear();

            foreach (var offer in this.BestAvailableOffers())
            {
                decimal totalAssigned = assignedOffers.Sum(item => item.AmountAssigned);
                if (totalAssigned < this.AmountRequested)
                {
                    assignedOffers.Add(
                        new AssignedOffer
                            {
                                AmountAssigned = Math.Min(offer.Amount, this.AmountRequested - totalAssigned),
                                Offer = offer,
                                Quote = this.Quote                               
                            });
                }
                else
                {
                    break;
                }
            }

            this.Quote.Lenders.AddRange(assignedOffers);
        }

        /// <summary>
        /// Calculates the bests the available offers.
        /// </summary>
        /// <returns>The bests the available offers</returns>
        public IOrderedEnumerable<IOffer> BestAvailableOffers()
        {
            return this.Offers.OrderBy(item => item.Rate);
        }
    }
}