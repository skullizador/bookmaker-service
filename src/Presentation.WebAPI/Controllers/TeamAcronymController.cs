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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TeamDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTeamAcronymsByTeamIdAsync([FromQuery] , CancellationToken cancellationToken)
        {
            var teams = await this.mediator.Send(new GetAllTeamsQuery(), cancellationToken);
            var teamDtos = this.mapper.Map<IEnumerable<TeamDto>>(teams);
            return this.Ok(teamDtos);
        }
    }
}