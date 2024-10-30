// ***********************************************************************
// Assembly         : Infraestructure.Core
// Author           : Pablo Restrepo
// Created          : 07-21-2021
//
// Last Modified By : Pablo Restrepo
// Last Modified On : 07-21-2021
// ***********************************************************************
// <copyright file="IDapperRepository.cs" company="Infraestructure.Core">
//     Copyright (c) Ingeneo S.A.S. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Infraestructura.Core.DapperManager.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface IDapperRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDapperRepository<T> where T : class
    {
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        IEnumerable<T> GetList(T entity);

        /// <summary>
        /// Gets the list query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        IEnumerable<T> GetListQuery(string query, object parameters = null);

        /// <summary>
        /// Executes the store procedure asynchronous.
        /// </summary>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        Task<IEnumerable<T>> ExecuteStoreProcedureAsync(string storeProcedure, object filter = null);

        /// <summary>
        /// Singles the or default.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        T SingleOrDefault(T entity);

        /// <summary>
        /// Executes the action.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        int? ExecuteAction(string query);

        /// <summary>
        /// Gets the list query asynchronous.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        Task<IEnumerable<T>> ExecuteQuerySelectAsync(string query, object parameters = null);
        /// <summary>
        /// Gets the list query asynchronous.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        Task<IEnumerable<T>> GetListQueryAsync(string query, object parameters = null);
    }
}