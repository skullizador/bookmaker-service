// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetByTeamIdQueryHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetByTeamIdQueryHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Presentation.WebAPI.Queries.Team.GetByTeamIdQuery
{
    using BookmakerService.Domain.AggregateModels.Team.Repository;
    using Domain.AggregateModels.Team;
    using MediatR;

    /// <summary>
    /// <see cref="GetByTeamIdQueryHandler"/>
    /// </summary>
    /// <seealso cref="IRequestHandler{GetByTeamIdQuery, Team}"/>
    public class GetByTeamIdQueryHandler : IRequestHandler<GetByTeamIdQuery, Team>
    {
        /// <summary>
        /// The team repository
        /// </summary>
        private readonly ITeamRepository teamRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetByTeamIdQueryHandler"/> class.
        /// </summary>
        /// <param name="teamRepository">The team repository.</param>
        public GetByTeamIdQueryHandler(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        public async Task<Team> Handle(GetByTeamIdQuery request, CancellationToken cancellationToken)
        {
            return await this.teamRepository.GetAsync(request.TeamId, cancellationToken);
        }
    }
}