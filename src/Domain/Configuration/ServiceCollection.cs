// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceCollection.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// ServiceCollection
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Domain.Configuration
{
    using BookmakerService.Domain.AggregateModels.Bookmaker.Builder.BookmakerBuilder;
    using BookmakerService.Domain.AggregateModels.Team.Builder.TeamAcronymBuilder;
    using BookmakerService.Domain.AggregateModels.Team.Builder.TeamBuilder;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// <see cref="ServiceCollection"/>
    /// </summary>
    public static class ServiceCollection
    {
        /// <summary>
        /// Registers the domain services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IBookmakerBuilder, BookmakerBuilder>();
            services.AddScoped<ITeamBuilder, TeamBuilder>();
            services.AddScoped<ITeamAcronymBuilder, TeamAcronymBuilder>();
        }
    }
}