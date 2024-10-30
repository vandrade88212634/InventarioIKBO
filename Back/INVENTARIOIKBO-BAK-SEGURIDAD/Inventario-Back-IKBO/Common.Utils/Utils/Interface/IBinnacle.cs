// ***********************************************************************
// Assembly         : Common.Utils
// Author           : sbustamante
// Created          : 07-19-2021
//
// Last Modified By : sbustamante
// Last Modified On : 07-19-2021
// ***********************************************************************
// <copyright file="IBinnacle.cs" company="Common.Utils">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Common.Utils.Dto;

namespace Common.Utils.Utils.Interface
{
    /// <summary>
    /// This IO define the actions of binnacle by any application
    /// </summary>
    public interface IBinnacle
    {
        /// <summary>
        /// This method save the audit of the application in data base
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="idRecord">The identifier record.</param>
        /// <param name="action">The action.</param>
        /// <param name="affectRecord">The affect record.</param>
        /// <returns>Task.</returns>
        Task SaveAudit(string comment, int? idRecord, string action, object affectRecord, string entity);

        AuditLogDto MakeObjectAuditLogDto(string action, object affectRecord, string entity);

        /// <summary>
        /// This method save all exceptions make in the application in data base
        /// </summary>
        /// <param name="exceptionLogDto">The exception log dto.</param>
        /// <returns>Task.</returns>
        Task SaveException(ExceptionLogDto exceptionLogDto);

        /// <summary>
        /// This method save ths traceability on application in data base
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logProcessDto">The log process dto.</param>
        /// <returns>Task.</returns>
        Task SaveProcess(ProcessLogDto logProcessDto);

        /// <summary>
        /// This method make object for error exceptions
        /// </summary>
        /// <param name="codigoError">The error code in exception</param>
        /// <param name="metodo">Method affected</param>
        /// <param name="mensaje">Message description</param>
        /// <param name="tipo">Error type</param>
        /// <returns>ExceptionLogDto.</returns>
        ExceptionLogDto MakeObjectExceptionLog(string codigoError, string metodo, string mensaje, string tipo);

        /// <summary>
        /// This method make object to traceability
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action">Action in method</param>
        /// <param name="idFatherProcess">Id fhater process</param>
        /// <param name="affectEntity">Entity affected</param>
        /// <returns>ProcessLogDto.</returns>
        ProcessLogDto MakeObjectLogProcess(string action, string idFatherProcess, string affectEntity);

        /// <summary>
        /// This methods get a entity name
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>System.String.</returns>
        string GetEntityName<TEntity>(TEntity entity);

        /// <summary>
        /// This method get a error message
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns>System.String.</returns>
        string GetErrorMessage(Exception ex);

        /// <summary>
        /// This metod get a id mircorservce
        /// </summary>
        /// <returns>System.Int32.</returns>
        string GetIdAppMicroService();

        /// <summary>
        /// This method get a user name
        /// </summary>
        /// <returns>System.String.</returns>
        string GetUserNameCache();

        /// <summary>
        /// This method get a primary key name
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>System.String.</returns>
        string GetPk<TEntity>(TEntity entity);

        /// <summary>
        /// Get estate for crud in data base
        /// </summary>
        /// <param name="bdActions">The bd actions.</param>
        /// <returns>System.String.</returns>
        string GetState(string bdActions);

        /// <summary>
        /// Gets or sets the token azure function.
        /// </summary>
        /// <value>The token azure function.</value>
        string TokenAzureFunction { get; set; }
    }
}