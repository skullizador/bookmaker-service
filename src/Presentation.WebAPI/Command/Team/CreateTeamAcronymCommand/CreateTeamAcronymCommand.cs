// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateTeamAcronymCommand.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateTeamAcronymCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Presentation.WebAPI.Command.Team.CreateTeamAcronymCommand
{
    using BookmakerService.Domain.AggregateModels.Team;
    using MediatR;

    /// <summary>
    /// <see cref="CreateTeamAcronymCommand"/>
    /// </summary>
    /// <seealso cref="IRequest{TeamAcronym}"/>
    public class CreateTeamAcronymCommand : IRequest<TeamAcronym>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTeamAcronymCommand"/> class.
        /// </summary>
        public CreateTeamAcronymCommand()
        {
            this.Acronym = string.Empty;
        }

        /// <summary>
        /// Gets the acronym.
        /// </summary>
        /// <value>The acronym.</value>
        public string Acronym { get; init; }

        /// <summary>
        /// Gets the team identifier.
        /// </summary>
        /// <value>The team identifier.</value>
        public Guid TeamId { get; init; }
    }
}