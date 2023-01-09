// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetByTeamAcronymIdDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetByTeamAcronymIdDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Presentation.WebAPI.Dtos.Input.Team
{
    /// <summary>
    /// <see cref="GetByTeamAcronymIdDto"/>
    /// </summary>
    public class GetByTeamAcronymIdDto
    {
        /// <summary>
        /// Gets the team acronym identifier.
        /// </summary>
        /// <value>The team acronym identifier.</value>
        public Guid TeamAcronymId { get; init; }
    }
}