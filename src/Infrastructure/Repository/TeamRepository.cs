// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TeamRepository.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// TeamRepository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Infrastructure.Repository
{
    using BookmakerService.Domain.AggregateModels.Team;
    using BookmakerService.Domain.AggregateModels.Team.Repository;

    /// <summary>
    /// <see cref="TeamRepository"/>
    /// </summary>
    /// <seealso cref="GenericRepository{Team}" />
    /// <seealso cref="ITeamRepository" />
    internal class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TeamRepository(BookmakerServiceDBContext context)
            : base(context)
        {
        }
    }
}