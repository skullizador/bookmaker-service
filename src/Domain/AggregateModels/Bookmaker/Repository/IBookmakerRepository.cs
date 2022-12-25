// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBookmakerRepository.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// IBookmakerRepository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Domain.AggregateModels.Bookmaker.Repository
{
    using BookmakerService.Domain.SeedWork;

    /// <summary>
    /// <see cref="IBookmakerRepository"/>
    /// </summary>
    /// <seealso cref="IRepository{Bookmaker}" />
    public interface IBookmakerRepository : IRepository<Bookmaker>
    {
    }
}