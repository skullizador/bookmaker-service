// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateTeamAcronymCommandHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateTeamAcronymCommandHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Presentation.WebAPI.Command.Team.CreateTeamAcronymCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    using BookmakerService.Domain.AggregateModels.Team;
    using BookmakerService.Domain.AggregateModels.Team.Builder.TeamAcronymBuilder;
    using BookmakerService.Domain.AggregateModels.Team.Repository;
    using BookmakerService.Domain.Exceptions;
    using MediatR;

    /// <summary>
    /// <see cref="CreateTeamAcronymCommandHandler"/>
    /// </summary>
    /// <seealso cref="IRequestHandler{CreateTeamAcronymCommand, TeamAcronym}"/>
    public class CreateTeamAcronymCommandHandler : IRequestHandler<CreateTeamAcronymCommand, TeamAcronym>
    {
        /// <summary>
        /// The team acronym builder
        /// </summary>
        private readonly ITeamAcronymBuilder teamAcronymBuilder;

        /// <summary>
        /// The team repository
        /// </summary>
        private readonly ITeamRepository teamRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTeamAcronymCommandHandler"/> class.
        /// </summary>
        /// <param name="teamRepository">The team repository.</param>
        /// <param name="teamAcronymBuilder">The team acronym builder.</param>
        public CreateTeamAcronymCommandHandler(
            ITeamRepository teamRepository,
            ITeamAcronymBuilder teamAcronymBuilder)
        {
            this.teamRepository = teamRepository;
            this.teamAcronymBuilder = teamAcronymBuilder;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        /// <exception cref="BookmakerService.Domain.Exceptions.NotFoundException">
        /// The team with id {request.TeamId} wasn't found.
        /// </exception>
        public async Task<TeamAcronym> Handle(CreateTeamAcronymCommand request, CancellationToken cancellationToken)
        {
            Team team = await this.teamRepository.GetAsync(request.TeamId, cancellationToken);

            if (team is null)
            {
                throw new NotFoundException($"The team with id {request.TeamId} wasn't found.");
            }

            TeamAcronym teamAcronym = this.teamAcronymBuilder
                .NewTeamAcronym(request.Acronym)
                .Build();

            team.AddAcronym(teamAcronym);

            await this.teamRepository.Update(team, cancellationToken);

            await this.teamRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return teamAcronym;
        }
    }
}