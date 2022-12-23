// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookmakerRepository.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// BookmakerRepository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Infrastructure.Repository
{
    using BookmakerService.Domain.AggregateModels.Bookmaker;
    using BookmakerService.Domain.AggregateModels.Bookmaker.Repository;

    /// <summary>
    /// <see cref="BookmakerRepository"/>
    /// </summary>
    /// <seealso cref="GenericRepository{Bookmaker}" />
    /// <seealso cref="IBookmakerRepository" />
    internal class BookmakerRepository : GenericRepository<Bookmaker>, IBookmakerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookmakerRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BookmakerRepository(BookmakerServiceDBContext context)
            : base(context)
        {
        }
    }
}