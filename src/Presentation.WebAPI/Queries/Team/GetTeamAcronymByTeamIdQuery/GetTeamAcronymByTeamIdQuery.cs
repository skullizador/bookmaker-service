// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetTeamAcronymByTeamIdQuery.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetTeamAcronymByTeamIdQuery
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Presentation.WebAPI.Queries.Team.GetTeamAcronymByTeamIdQuery
{
    using BookmakerService.Domain.AggregateModels.Team;
    using MediatR;

    /// <summary>
    /// <see cref="GetTeamAcronymByTeamIdQuery"/>
    /// </summary>
    /// <seealso cref="IRequest{IEnumerable{TeamAcronym}}"/>
    public class GetTeamAcronymByTeamIdQuery : IRequest<IEnumerable<TeamAcronym>>
    {
        /// <summary>
        /// Gets or sets the team identifier.
        /// </summary>
        /// <value>The team identifier.</value>
        public Guid TeamId { get; init; }
    }
}