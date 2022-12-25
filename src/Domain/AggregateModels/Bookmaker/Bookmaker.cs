// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bookmaker.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// Bookmaker
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Domain.AggregateModels.Bookmaker
{
    using System.Collections.Generic;
    using BookmakerService.Domain.SeedWork;

    /// <summary>
    /// <see cref="Bookmaker"/>
    /// </summary>
    /// <seealso cref="EntityBase" />
    /// <seealso cref="IAggregateRoot" />
    public class Bookmaker : EntityBase, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bookmaker"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="comments">The comments.</param>
        /// <param name="description">The description.</param>
        internal Bookmaker(string name, string baseUrl, string comments, string description)
            : this()
        {
            this.Name = name;
            this.BaseUrl = baseUrl;
            this.Comments = comments;
            this.Description = description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bookmaker"/> class.
        /// </summary>
        protected Bookmaker()
        {
        }

        /// <summary>
        /// Gets the base URL.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        public string BaseUrl { get; private set; }

        /// <summary>
        /// Gets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public string Comments { get; private set; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the atomic values.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.UUId;
        }
    }
}