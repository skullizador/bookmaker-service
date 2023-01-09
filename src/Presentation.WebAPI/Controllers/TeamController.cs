// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TeamController.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// TeamController
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Presentation.WebAPI.Controllers
{
    using System.Net;
    using AutoMapper;
    using BookmakerService.Domain.AggregateModels.Team;
    using BookmakerService.Presentation.WebAPI.Command.Team.CreateTeamCommand;
    using BookmakerService.Presentation.WebAPI.Command.Team.DeleteTeamCommand;
    using BookmakerService.Presentation.WebAPI.Command.Team.UpdateTeamCommand;
    using BookmakerService.Presentation.WebAPI.Dtos.Input.Team;
    using BookmakerService.Presentation.WebAPI.Dtos.Output.Team;
    using BookmakerService.Presentation.WebAPI.Queries.Team.GetAllTeamsQuery;
    using BookmakerService.Presentation.WebAPI.Queries.Team.GetByTeamIdQuery;
    using BookmakerService.Presentation.WebAPI.Utils;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// <see cref="TeamController"/>
    /// </summary>
    /// <seealso cref="Controller"/>
    [ApiController]
    [Route("api/v1/Team")]
    public class TeamController : Controller
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
        /// Initializes a new instance of the <see cref="TeamController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="mapper">The mapper.</param>
        public TeamController(
            IMediator mediator,
            IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Creates the team asynchronous.
        /// </summary>
        /// <param name="createTeamDto">The create team dto.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(TeamDetailsDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateTeamAsync([FromBody] CreateTeamDto createTeamDto, CancellationToken cancellationToken)
        {
            Team team = await this.mediator.Send(new CreateTeamCommand
            {
                Name = createTeamDto.Name,
                ShortName = createTeamDto.ShortName,
            }, cancellationToken);

            return this.Ok(this.mapper.Map<TeamDetailsDto>(team));
        }

        /// <summary>
        /// Deletes the team asynchronous.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpDelete("{TeamId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteTeamAsync([FromRoute] GetByTeamIdDto filters, CancellationToken cancellationToken)
        {
            await this.mediator.Publish(new DeleteTeamCommand
            {
                TeamId = filters.TeamId
            }, cancellationToken);

            return this.Ok();
        }

        /// <summary>
        /// Gets all teams asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TeamDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllTeamsAsync(CancellationToken cancellationToken)
        {
            IEnumerable<Team> teams = await this.mediator.Send(new GetAllTeamsQuery(), cancellationToken);

            return this.Ok(this.mapper.Map<IEnumerable<TeamDto>>(teams));
        }

        /// <summary>
        /// Gets the team details asynchronous.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet("{TeamId}")]
        [ProducesResponseType(typeof(TeamDetailsDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetTeamDetailsAsync([FromRoute] GetByTeamIdDto filters, CancellationToken cancellationToken)
        {
            Team team = await this.mediator.Send(new GetByTeamIdQuery
            {
                TeamId = filters.TeamId
            }, cancellationToken);

            return this.Ok(this.mapper.Map<TeamDetailsDto>(team));
        }

        /// <summary>
        /// Updates the team asynchronous.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <param name="updateTeamDto">The update team dto.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPut("{TeamId}")]
        [ProducesResponseType(typeof(TeamDetailsDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateTeamAsync(
            [FromRoute] GetByTeamIdDto filters,
            [FromBody] UpdateTeamDto updateTeamDto,
            CancellationToken cancellationToken)
        {
            Team team = await this.mediator.Send(new UpdateTeamCommand
            {
                TeamId = filters.TeamId,
                Name = updateTeamDto.Name,
                ShortName = updateTeamDto.ShortName,
            }, cancellationToken);

            return this.Ok(this.mapper.Map<TeamDetailsDto>(team));
        }
    }
}