// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITeamRepository.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// ITeamRepository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Domain.AggregateModels.Team.Repository
{
    using BookmakerService.Domain.SeedWork;

    /// <summary>
    /// <see cref="ITeamRepository"/>
    /// </summary>
    /// <seealso cref="IRepository{Team}" />
    public interface ITeamRepository : IRepository<Team>
    {
    }
}