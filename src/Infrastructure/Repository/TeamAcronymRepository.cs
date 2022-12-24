// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TeamAcronymRepository.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// TeamAcronymRepository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Infrastructure.Repository
{
    using BookmakerService.Domain.AggregateModels.Team;
    using BookmakerService.Domain.AggregateModels.Team.Repository;

    /// <summary>
    /// <see cref="TeamAcronymRepository"/>
    /// </summary>
    /// <seealso cref="GenericRepository{TeamAcronym}" />
    /// <seealso cref="ITeamAcronymRepository" />
    internal class TeamAcronymRepository : GenericRepository<TeamAcronym>, ITeamAcronymRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamAcronymRepository" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TeamAcronymRepository(BookmakerServiceDBContext context)
            : base(context)
        {
        }
    }
}