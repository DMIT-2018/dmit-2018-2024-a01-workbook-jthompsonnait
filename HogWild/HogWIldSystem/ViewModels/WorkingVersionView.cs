// ***********************************************************************
// Assembly         : HogWildSystem
// Author           : James Thompson
// Created          : 01-30-2024
//
// Last Modified By : James Thompson
// Last Modified On : 01-30-2024
// ***********************************************************************
// <copyright file="WorkingVersionView.cs" company="HogWildSystem">
//     Copyright (c) NAIT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogWildSystem.ViewModels
{
    /// <summary>
    /// Class WorkingVersionView.
    /// </summary>
    public class WorkingVersionView
    {
        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        /// <value>The version identifier.</value>
        public int VersionId { get; set; }
        /// <summary>
        /// Gets or sets the major.
        /// </summary>
        /// <value>The major.</value>
        public int Major { get; set; }
        /// <summary>
        /// Gets or sets the minor.
        /// </summary>
        /// <value>The minor.</value>
        public int Minor { get; set; }
        /// <summary>
        /// Gets or sets the build.
        /// </summary>
        /// <value>The build.</value>
        public int Build { get; set; }
        /// <summary>
        /// Gets or sets the revision.
        /// </summary>
        /// <value>The revision.</value>
        public int Revision { get; set; }
        /// <summary>
        /// Gets or sets as of date.
        /// </summary>
        /// <value>As of date.</value>
        public DateTime AsOfDate { get; set; }
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>The comments.</value>
        public string Comments { get; set; }
    }
}
