// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAllTeamsQuery.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetAllTeamsQuery
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Presentation.WebAPI.Queries.Team.GetAllTeamsQuery
{
    using Domain.AggregateModels.Team;
    using MediatR;

    /// <summary>
    /// <see cref="GetAllTeamsQuery"/>
    /// </summary>
    /// <seealso cref="IRequest{IEnumerable{Team}}"/>
    public class GetAllTeamsQuery : IRequest<IEnumerable<Team>>
    {
    }
}