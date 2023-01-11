// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateTeamDtoValidator.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateTeamDtoValidator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Presentation.WebAPI.Validation.Team
{
    using BookmakerService.Presentation.WebAPI.Dtos.Input.Team;
    using FluentValidation;

    /// <summary>
    /// <see cref="CreateTeamDtoValidator"/>
    /// </summary>
    /// <seealso cref="AbstractValidator{CreateTeamDto}"/>
    public class CreateTeamDtoValidator : AbstractValidator<CreateTeamDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTeamDtoValidator"/> class.
        /// </summary>
        public CreateTeamDtoValidator()
        {
            this.RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("The Name shouldn't be empty.")
                .NotNull()
                    .WithMessage("The Name shouldn't be null.");

            this.RuleFor(x => x.ShortName)
                .NotEmpty()
                    .WithMessage("The Short Name shouldn't be empty.")
                .NotNull()
                    .WithMessage("The Short Name shouldn't be null.");
        }
    }
}