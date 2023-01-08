// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateTeamCommand.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateTeamCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Presentation.WebAPI.Command.Team.CreateTeamCommand
{
    using Domain.AggregateModels.Team;
    using MediatR;

    /// <summary>
    /// <see cref="CreateTeamCommand"/>
    /// </summary>
    /// <seealso cref="IRequest{Team}"/>
    public class CreateTeamCommand : IRequest<Team>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTeamCommand"/> class.
        /// </summary>
        public CreateTeamCommand()
        {
            this.ShortName = string.Empty;
            this.Name = string.Empty;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; init; }

        /// <summary>
        /// Gets the short name.
        /// </summary>
        /// <value>The short name.</value>
        public string ShortName { get; init; }
    }
}