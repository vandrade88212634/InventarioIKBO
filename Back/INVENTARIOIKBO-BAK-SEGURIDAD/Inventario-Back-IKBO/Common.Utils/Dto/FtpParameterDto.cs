// ***********************************************************************
// Assembly         : Common.Utils
// Author           : Pablo Restrepo <pablo.restrepo@ingeneo.com.co>
// Created          : 04-12-2021
//
// Last Modified By : Pablo Restrepo <pablo.restrepo@ingeneo.com.co>
// Last Modified On : 04-08-2021
// ***********************************************************************
// <copyright file="FtpParameterDto.cs" company="Common.Utils">
//     Copyright (c) Ingeneo S.A.S. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Dto
{
    /// <summary>
    /// Class FtpParameterDto.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class FtpParameterDto
    {
        /// <summary>
        /// Gets or sets the FTP path.
        /// </summary>
        /// <value>The FTP path.</value>
        public string FtpPath { get; set; }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>The file path.</value>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [keep alive].
        /// </summary>
        /// <value><c>true</c> if [keep alive]; otherwise, <c>false</c>.</value>
        public bool KeepAlive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [use passive].
        /// </summary>
        /// <value><c>true</c> if [use passive]; otherwise, <c>false</c>.</value>
        public bool UsePassive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [use binary].
        /// </summary>
        /// <value><c>true</c> if [use binary]; otherwise, <c>false</c>.</value>
        public bool UseBinary { get; set; }
    }
}