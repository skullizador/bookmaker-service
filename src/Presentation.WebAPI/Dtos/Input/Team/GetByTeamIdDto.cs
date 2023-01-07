// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetByTeamIdDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetByTeamIdDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Presentation.WebAPI.Dtos.Input.Team
{
    /// <summary>
    /// <see cref="GetByTeamIdDto"/>
    /// </summary>
    public class GetByTeamIdDto
    {
        /// <summary>
        /// Gets the team identifier.
        /// </summary>
        /// <value>The team identifier.</value>
        public Guid TeamId { get; init; }
    }
}