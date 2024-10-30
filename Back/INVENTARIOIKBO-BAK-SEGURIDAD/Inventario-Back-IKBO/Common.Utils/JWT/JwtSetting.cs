// ***********************************************************************
// Assembly         : Common.Utils
// Author           : Pablo Restrepo <pablo.restrepo@ingeneo.com.co>
// Created          : 04-12-2021
//
// Last Modified By : Pablo Restrepo <pablo.restrepo@ingeneo.com.co>
// Last Modified On : 04-08-2021
// ***********************************************************************
// <copyright file="JwtSetting.cs" company="Common.Utils">
//     Copyright (c) Ingeneo S.A.S. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Common.Utils.JWT
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Class JwtSetting. This class cannot be inherited.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class JwtSetting
    {
        /// <summary>
        /// Gets or sets the secret key.
        /// </summary>
        /// <value>The secret key.</value>
        public string SecretKey { get; set; }

        /// <summary>
        /// Gets or sets the issuer.
        /// </summary>
        /// <value>The issuer.</value>
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}