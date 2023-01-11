// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetByTeamAcronymIdDtoValidator.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetByTeamAcronymIdDtoValidator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Presentation.WebAPI.Validation.Team
{
    using BookmakerService.Presentation.WebAPI.Dtos.Input.Team;
    using FluentValidation;

    /// <summary>
    /// <see cref="GetByTeamAcronymIdDtoValidator"/>
    /// </summary>
    /// <seealso cref="AbstractValidator{GetByTeamAcronymIdDto}"/>
    public class GetByTeamAcronymIdDtoValidator : AbstractValidator<GetByTeamAcronymIdDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetByTeamAcronymIdDtoValidator"/> class.
        /// </summary>
        public GetByTeamAcronymIdDtoValidator()
        {
            this.RuleFor(x => x.TeamAcronymId)
                .NotEqual(Guid.Empty)
                    .WithMessage("The Team Acronym Id shouldn't be empty.");
        }
    }
}