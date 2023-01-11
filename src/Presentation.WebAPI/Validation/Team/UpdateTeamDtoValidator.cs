// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateTeamDtoValidator.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateTeamDtoValidator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Presentation.WebAPI.Validation.Team
{
    using BookmakerService.Presentation.WebAPI.Dtos.Input.Team;
    using FluentValidation;

    /// <summary>
    /// <see cref="UpdateTeamDtoValidator"/>
    /// </summary>
    /// <seealso cref="AbstractValidator{UpdateTeamDto}"/>
    public class UpdateTeamDtoValidator : AbstractValidator<UpdateTeamDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTeamDtoValidator"/> class.
        /// </summary>
        public UpdateTeamDtoValidator()
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