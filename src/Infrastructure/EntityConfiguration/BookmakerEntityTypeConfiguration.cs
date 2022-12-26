// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookmakerEntityTypeConfiguration.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// BookmakerEntityTypeConfiguration
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Infrastructure.EntityConfiguration
{
    using BookmakerService.Domain.AggregateModels.Bookmaker;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// <see cref="BookmakerEntityTypeConfiguration"/>
    /// </summary>
    /// <seealso cref="EntityTypeConfiguration{Bookmaker}" />
    internal class BookmakerEntityTypeConfiguration : EntityTypeConfiguration<Bookmaker>
    {
        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        protected override string TableName => "Bookmaker";

        /// <summary>
        /// Configures the entity.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void ConfigureEntity(EntityTypeBuilder<Bookmaker> builder)
        {
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.BaseUrl)
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(b => b.Country)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}