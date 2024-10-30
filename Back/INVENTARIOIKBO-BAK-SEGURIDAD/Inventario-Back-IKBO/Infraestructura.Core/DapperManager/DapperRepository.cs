// ***********************************************************************
// Assembly         : Infraestructure.Core
// Author           : Pablo Restrepo
// Created          : 07-21-2021
//
// Last Modified By : Pablo Restrepo
// Last Modified On : 07-21-2021
// ***********************************************************************
// <copyright file="DapperRepository.cs" company="Infraestructure.Core">
//     Copyright (c) Ingeneo S.A.S. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Infraestructura.Core.DapperManager
{
    /*
    /// <summary>
    /// Class DapperRepository.
    /// Implements the <see cref="Infraestructura.Core.DapperManager.Interface.IDapperRepository{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Infraestructura.Core.DapperManager.Interface.IDapperRepository{T}" />
    [ExcludeFromCodeCoverage]
    public class DapperRepository<T> : IDapperRepository<T> where T : class
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string connString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DapperRepository{T}"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public DapperRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.connString = this._configuration.GetConnectionString("ConnectionStringSQLServer");
        }

        /// <summary>
        /// Executes the action.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        public int? ExecuteAction(string query)
        {
            IDbConnection connection = this.GetConnection();

            var result = connection.Execute(query);

            this.CloseConnection(connection);

            return result;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public IEnumerable<T> GetList(T entity)
        {
            IDbConnection connection = this.GetConnection();

            var result = connection.Query<T>(GetColumnList(entity));

            this.CloseConnection(connection);

            return result;
        }

        /// <summary>
        /// Gets the list query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public IEnumerable<T> GetListQuery(string query, object parameters = null)
        {
            IDbConnection connection = this.GetConnection();
            var result = connection.Query<T>(query, parameters);
            this.CloseConnection(connection);
            return result;
        }

        /// <summary>
        /// Gets the list query async.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public async Task<IEnumerable<T>> ExecuteQuerySelectAsync(string query, object parameters = null)
        {
            IDbConnection connection = this.GetConnection();
            var result = await connection.QueryAsync<T>(query, parameters);
            this.CloseConnection(connection);
            return result;
        }

        /// <summary>
        /// execute store procedure as an asynchronous operation.
        /// </summary>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        public async Task<IEnumerable<T>> ExecuteStoreProcedureAsync(string storeProcedure, object filter = null)
        {
            IDbConnection connection = this.GetConnection();
            var result = await connection.QueryAsync<T>(storeProcedure, filter, commandType: CommandType.StoredProcedure,commandTimeout:600);
            this.CloseConnection(connection);
            return result.ToList();
        }

        /// <summary>
        /// Singles the or default.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <retur
        /// ns>T.</returns>
        public T SingleOrDefault(T entity)
        {
            IDbConnection connection = this.GetConnection();

            var result = connection.QueryFirstOrDefault<T>(GetColumnList(entity));

            this.CloseConnection(connection);

            return result;
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <retur
        /// /*ns>IDbConnection.</returns>
        /// 

        private IDbConnection GetConnection()
        {
           
            var conn = new SqlConnection(connString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
            
        }
  
        /// <summary>
        /// Closes the connection.
        /// </summary>
        /// <param name="conn">The connection.</param>
        private void CloseConnection(IDbConnection conn)
        {
            if (conn.State == ConnectionState.Open || conn.State == ConnectionState.Broken)
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Gets the column list.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.String.</returns>
        private string GetColumnList(T entity)
        {
            string selectedColumns = "Select ";
            foreach (var prop in entity.GetType().GetProperties())
            {
                if (!prop.Name.Contains("_"))
                {
                    selectedColumns = string.Concat(selectedColumns, ConvertToPascalCase(prop.Name), " AS ", prop.Name, ",");
                }
            }

            return selectedColumns + " From " + ConvertToPascalCase(entity.GetType().Name);
        }

        /// <summary>
        /// Converts to pascal case.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.String.</returns>
        private string ConvertToPascalCase(string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }

        /// <summary>
        /// Gets the list query async.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public async Task<IEnumerable<T>> GetListQueryAsync(string query, object parameters = null)
        {
            IDbConnection connection = this.GetConnection();
            var result = await connection.QueryAsync<T>(query, parameters, commandType: CommandType.Text, commandTimeout: 300);
            this.CloseConnection(connection);
            return result.ToList();
        }
    }
*/
}