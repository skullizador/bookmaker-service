// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Team.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// Team
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookmakerService.Domain.AggregateModels.Team
{
    using System;
    using System.Collections.Generic;
    using BookmakerService.Domain.Exceptions;
    using BookmakerService.Domain.SeedWork;

    /// <summary>
    /// <see cref="Team"/>
    /// </summary>
    /// <seealso cref="EntityBase"/>
    /// <seealso cref="IAggregateRoot"/>
    public class Team : EntityBase, IAggregateRoot
    {
        /// <summary>
        /// The acronyms
        /// </summary>
        private readonly List<TeamAcronym> acronyms;

        /// <summary>
        /// Initializes a new instance of the <see cref="Team"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        internal Team(string name, string shortName)
            : this()
        {
            this.Name = name;
            this.ShortName = shortName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Team"/> class.
        /// </summary>
        protected Team()
        {
            this.acronyms = new List<TeamAcronym>();
        }

        /// <summary>
        /// Gets the acronyms.
        /// </summary>
        /// <value>The acronyms.</value>
        public virtual IReadOnlyCollection<TeamAcronym> Acronyms => this.acronyms;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the short name.
        /// </summary>
        /// <value>The short name.</value>
        public string ShortName { get; private set; }

        /// <summary>
        /// Adds the acronym.
        /// </summary>
        /// <param name="acronym">The acronym.</param>
        /// <exception cref="ArgumentNullException">The Acronym is null.</exception>
        /// <exception cref="DuplicatedException">
        /// The Acronym {acronym} already exists in team {this.Name}.
        /// </exception>
        public void AddAcronym(TeamAcronym acronym)
        {
            if (acronym == null)
            {
                throw new ArgumentNullException(nameof(acronym), "The Acronym is null.");
            }

            if (this.AcronymExists(acronym.Acronym))
            {
                throw new DuplicatedException($"The Acronym {acronym} already exists in team {this.Name}.");
            }

            this.acronyms.Add(acronym);
        }

        /// <summary>
        /// Gets the atomic values.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.UUId;
        }

        /// <summary>
        /// Acronyms the exists.
        /// </summary>
        /// <param name="acronym">The acronym.</param>
        /// <returns></returns>
        private bool AcronymExists(string acronym)
        {
            return this.acronyms.Exists(x => x.Acronym == acronym);
        }
    }
}