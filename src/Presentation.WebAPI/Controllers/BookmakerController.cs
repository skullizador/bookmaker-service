﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookmakerController.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// BookmakerController
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Presentation.WebAPI.Controllers
{
    using System.Net;
    using AutoMapper;
    using BookmakerService.Domain.AggregateModels.Bookmaker;
    using BookmakerService.Presentation.WebAPI.Command.Bookmaker.CreateBookmakerCommand;
    using BookmakerService.Presentation.WebAPI.Dtos.Input.Bookmaker;
    using BookmakerService.Presentation.WebAPI.Dtos.Output.Bookmaker;
    using BookmakerService.Presentation.WebAPI.Utils;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// <see cref="BookmakerController"/>
    /// </summary>
    /// <seealso cref="Controller" />
    [ApiController]
    [Route("api/v1/Bookmaker")]
    public class BookmakerController : Controller
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
        /// Initializes a new instance of the <see cref="BookmakerController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="mapper">The mapper.</param>
        public BookmakerController(
            IMediator mediator,
            IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Creates the bookmaker asynchronous.
        /// </summary>
        /// <param name="createBookmakerDto">The create bookmaker dto.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(BookmakerDetailsDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateBookmakerAsync([FromBody] CreateBookmakerDto createBookmakerDto, CancellationToken cancellationToken)
        {
            Bookmaker bookmaker = await this.mediator.Send(new CreateBookmakerCommand
            {
                BaseUrl = createBookmakerDto.BaseUrl,
                Comments = createBookmakerDto.Comments,
                Country = createBookmakerDto.Country,
                Description = createBookmakerDto.Description,
                Name = createBookmakerDto.Name
            }, cancellationToken);

            return this.Created(string.Empty, this.mapper.Map<BookmakerDetailsDto>(bookmaker));
        }
    }
}