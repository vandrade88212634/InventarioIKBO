// ***********************************************************************
// Assembly         : Common.Utils
// Author           : Pablo Restrepo <pablo.restrepo@ingeneo.com.co>
// Created          : 04-12-2021
//
// Last Modified By : Pablo Restrepo <pablo.restrepo@ingeneo.com.co>
// Last Modified On : 04-12-2021
// ***********************************************************************
// <copyright file="InternalFilePathBusinnesDto.cs" company="Common.Utils">
//     Copyright (c) Ingeneo S.A.S. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Common.Utils.Dto
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Class InternalFilePathBusinnesDto.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class InternalFilePathBusinnesDto
    {
        /// <summary>
        /// Gets or sets the internal business file identifier.
        /// </summary>
        /// <value>The internal business file identifier.</value>
        public int InternalBusinessFileId { get; set; }
        /// <summary>
        /// Gets or sets the internal file path identifier.
        /// </summary>
        /// <value>The internal file path identifier.</value>
        public int InternalFilePathId { get; set; }
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; set; }
        /// <summary>
        /// Gets or sets the business code.
        /// </summary>
        /// <value>The business code.</value>
        public string BusinessCode { get; set; }
        /// <summary>
        /// Gets or sets the internal file code.
        /// </summary>
        /// <value>The internal file code.</value>
        public string InternalFileCode { get; set; }
    }
}