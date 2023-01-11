// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateTeamAcronymDtoValidator.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateTeamAcronymDtoValidator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Presentation.WebAPI.Validation.Team
{
    using BookmakerService.Presentation.WebAPI.Dtos.Input.Team;
    using FluentValidation;

    /// <summary>
    /// <see cref="CreateTeamAcronymDtoValidator"/>
    /// </summary>
    /// <seealso cref="AbstractValidator{CreateTeamAcronymDto}"/>
    public class CreateTeamAcronymDtoValidator : AbstractValidator<CreateTeamAcronymDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTeamAcronymDtoValidator"/> class.
        /// </summary>
        public CreateTeamAcronymDtoValidator()
        {
            this.RuleFor(x => x.Acronym)
                .NotEmpty()
                    .WithMessage("The Acronym shouldn't be empty.")
                .MaximumLength(10)
                    .WithMessage("The Acronym shouldn't be longer than 10 characters.");
        }
    }
}