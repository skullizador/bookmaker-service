﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TeamAcronymController.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// TeamAcronymController
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Presentation.WebAPI.Controllers
{
    using System.Net;
    using AutoMapper;
    using BookmakerService.Domain.AggregateModels.Team;
    using BookmakerService.Presentation.WebAPI.Command.Team.CreateTeamAcronymCommand;
    using BookmakerService.Presentation.WebAPI.Command.Team.DeleteTeamAcronymCommand;
    using BookmakerService.Presentation.WebAPI.Dtos.Input.Team;
    using BookmakerService.Presentation.WebAPI.Dtos.Output.Team;
    using BookmakerService.Presentation.WebAPI.Queries.Team.GetTeamAcronymByTeamIdQuery;
    using BookmakerService.Presentation.WebAPI.Utils;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// <see cref="TeamAcronymController"/>
    /// </summary>
    /// <seealso cref="Controller"/>
    [ApiController]
    [Route("api/v1/TeamAcronym")]
    public class TeamAcronymController : Controller
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamAcronymController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="mapper">The mapper.</param>
        public TeamAcronymController(
            IMediator mediator,
            IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Adds the acronym to team asynchronous.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <param name="createAcronymDto">The create acronym dto.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(TeamAcronymDetailsDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> AddAcronymToTeamAsync(
            [FromQuery] GetByTeamIdDto filters,
            [FromBody] CreateTeamAcronymDto createAcronymDto,
            CancellationToken cancellationToken)
        {
            TeamAcronym acronym = await this.mediator.Send(new CreateTeamAcronymCommand
            {
                TeamId = filters.TeamId,
                Acronym = createAcronymDto.Acronym,
            }, cancellationToken);

            return this.Ok(this.mapper.Map<TeamAcronymDetailsDto>(acronym));
        }

        /// <summary>
        /// Deletes the team acronym asynchronous.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpDelete("{TeamAcronymId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteTeamAcronymAsync([FromRoute] GetByTeamAcronymIdDto filters, CancellationToken cancellationToken)
        {
            await this.mediator.Publish(new DeleteTeamAcronymCommand
            {
                TeamAcronymId = filters.TeamAcronymId,
            }, cancellationToken);

            return this.Ok();
        }

        /// <summary>
        /// Gets the team acronyms by team identifier asynchronous.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TeamAcronymDetailsDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetTeamAcronymsByTeamIdAsync([FromQuery] GetByTeamIdDto filters, CancellationToken cancellationToken)
        {
            IEnumerable<TeamAcronym> acronyms = await this.mediator.Send(new GetTeamAcronymByTeamIdQuery
            {
                TeamId = filters.TeamId
            }, cancellationToken);

            return this.Ok(this.mapper.Map<IEnumerable<TeamAcronymDetailsDto>>(acronyms));
        }
    }
}