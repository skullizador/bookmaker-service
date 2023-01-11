// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetByTeamIdDtoValidator.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetByTeamIdDtoValidator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Presentation.WebAPI.Validation.Team
{
    using BookmakerService.Presentation.WebAPI.Dtos.Input.Team;
    using FluentValidation;

    /// <summary>
    /// <see cref="GetByTeamIdDtoValidator"/>
    /// </summary>
    /// <seealso cref="AbstractValidator{GetByTeamIdDto}"/>
    public class GetByTeamIdDtoValidator : AbstractValidator<GetByTeamIdDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetByTeamIdDtoValidator"/> class.
        /// </summary>
        public GetByTeamIdDtoValidator()
        {
            this.RuleFor(x => x.TeamId)
                .NotEqual(Guid.Empty)
                    .WithMessage("The Team Id shouldn't be empty.");
        }
    }
}