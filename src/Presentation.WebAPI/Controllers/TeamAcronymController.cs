// --------------------------------------------------------------------------------------------------------------------
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
        /// Gets the team acronyms by team identifier asynchronous.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TeamAcronymDetailsDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
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