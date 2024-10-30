// ***********************************************************************
// Assembly         : Common.Utils
// Author           : Luis Carlos Uribe Lozano
// Created          : 07-21-2020
//
// Last Modified By : Luis Carlos Uribe Lozano
// Last Modified On : 08-05-2020
// ***********************************************************************
// <copyright file="EnumsGeneric.cs" company="Common.Utils">
//     Copyright (c) Ingeneo SAS. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Common.Utils.Enums.Exts;
using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Enums
{
    /// <summary>
    /// Class EnumsGeneric.
    /// </summary>
    /// <remarks>Luis Carlos Uribe</remarks>
    [ExcludeFromCodeCoverage]
    public class EnumsGeneric
    {

        /// <summary>
        /// Enum NotificationType
        /// </summary>
        /// <remarks>Luis Carlos Uribe</remarks>
        public enum NotificationType
        {
            /// <summary>
            /// The announcement creation
            /// </summary>
            [StringValue("Creación convocatoria")]
            AnnouncementCreation = 1,
            /// <summary>
            /// The stage update
            /// </summary>
            [StringValue("Actualización de etapas")]
            StageUpdate = 2,
            /// <summary>
            /// The status update
            /// </summary>
            [StringValue("Actualización de estados")]
            StatusUpdate = 3,
            /// <summary>
            /// The schedule
            /// </summary>
            [StringValue("Cronograma")]
            Schedule = 4
        }


        /// <summary>
        /// Enum NotificationGroup
        /// </summary>
        /// <remarks>Luis Carlos Uribe</remarks>
        public enum NotificationGroup
        {
            /// <summary>
            /// The administrators
            /// </summary>
            Administrators = 1,
            /// <summary>
            /// The control entities
            /// </summary>
            ControlEntities = 2,
            /// <summary>
            /// The auditor
            /// </summary>
            Auditor = 3,
            /// <summary>
            /// The subscribed
            /// </summary>
            Subscribed = 4,
            /// <summary>
            /// The email manager
            /// </summary>
            EmailManager = 5
        }

        /// <summary>
        /// Enum Separator
        /// </summary>
        /// <remarks>Luis Carlos Uribe</remarks>
        public enum Separator
        {
            /// <summary>
            /// The slash
            /// </summary>
            [StringValue("/")]
            Slash,
            /// <summary>
            /// The hyphen
            /// </summary>
            [StringValue("-")]
            Hyphen,
            /// <summary>
            /// The semicolon
            /// </summary>
            [StringValue(";")]
            Semicolon,
            /// <summary>
            /// The UnderLine
            /// </summary>
            [StringValue("_")]
            UnderLine,
            /// <summary>
            /// The Space
            /// </summary>
            [StringValue(" ")]
            Space,
            /// <summary>
            /// The TwoPoint
            /// </summary>
            [StringValue(":")]
            TwoPoint,
            /// <summary>
            /// The Comma
            /// </summary>
            [StringValue(",")]
            Comma,



        }

        /// <summary>
        /// Enum FormatDate
        /// </summary>
        /// <remarks>Luis Carlos Uribe</remarks>
        public enum FormatDate
        {
            /// <summary>
            /// The day month year
            /// </summary>
            [StringValue("dd/MM/yyyy")]
            DayMonthYear,
            /// <summary>
            /// The day month year hour minute
            /// </summary>
            [StringValue("dd/MM/yyyy HH:mm")]
            DayMonthYearHourMinute,
            /// <summary>
            /// The year month day separator hour minute second
            /// </summary>
            [StringValue("yyyyMMdd-HHmmss")]
            YearMonthDaySeparatorHourMinuteSecond,
            /// <summary>
            /// The year month day
            /// </summary>
            [StringValue("yyyy-MM-dd")]
            YearMonthDay,

            /// <summary>
            /// The year month day hour minute
            /// </summary>
            [StringValue("yyyy-MM-dd HH:mm")]
            YearMonthDayHourMinute,

            /// <summary>
            /// The long date
            /// </summary>
            [StringValue("D")]
            LongDate,

            /// <summary>
            /// The day month year hour
            /// </summary>
            [StringValue("dd/MM/yyyy HH")]
            DayMonthYearHour,

            /// <summary>
            /// The year month day separator hour minute second
            /// </summary>
            [StringValue("yyyyMMdd-HHmmssfff")]
            YearMonthDaySeparatorHourMinuteSecondMilli,

            /// <summary>
            /// The day month year hour minutes
            /// </summary>
            [StringValue("dd-MM-yyy HH:mm")]
            DayMonthYearHourMinutes
        }

        /// <summary>
        /// Enum Status
        /// </summary>
        /// <remarks>Luis Carlos Uribe</remarks>
        public enum Status
        {
            /// <summary>
            /// The ok
            /// </summary>
            [StringValue("OK")]
            Ok = 1,

            /// <summary>
            /// The error
            /// </summary>
            [StringValue("ERROR")]
            Error
        }

        /// <summary>
        /// Enum OperationType
        /// </summary>
        /// <remarks>Luis Carlos Uribe</remarks>
        public enum OperationType
        {
            /// <summary>
            /// EnableTool
            /// </summary>
            Enable = 1,
            /// <summary>
            /// ReplaceDocument
            /// </summary>
            Replace = 2,
            /// <summary>
            /// UpdateTool
            /// </summary>
            Update = 3,
            /// <summary>
            /// DeleteTool
            /// </summary>
            Delete = 4,
            /// <summary>
            /// The create
            /// </summary>
            Create = 5
        }

        /// <summary>
        /// Enum FileType
        /// </summary>
        /// <remarks>Luis Carlos Uribe</remarks>
        public enum FileType
        {
            /// <summary>
            /// The attached document
            /// </summary>
            AttachedDocument = 1,

            /// <summary>
            /// The attached image
            /// </summary>
            AttachedImage = 2,

            /// <summary>
            /// The external link
            /// </summary>
            ExternalLink = 3,

            /// <summary>
            /// The link video/
            /// </summary>
            LinkVideo = 4
        }

        /// <summary>
        /// Enum Visualize
        /// </summary>
        /// <remarks>Luis Carlos Uribe</remarks>
        public enum Visualize
        {
            /// <summary>
            /// The home
            /// </summary>
            [StringValue("Home")]
            Home,
            /// <summary>
            /// The pop up
            /// </summary>
            [StringValue("PopUp")]
            PopUp
        }

        /// <summary>
        /// Enum TypeRequest
        /// </summary>
        /// <remarks>Juan David Cárdenas</remarks>
        public enum TypeRequest
        {
            /// <summary>
            /// The request
            /// </summary>
            Request,
            /// <summary>
            /// The respponse
            /// </summary>
            Response,
            /// <summary>
            /// The exception
            /// </summary>
            Exception
        }

        /// <summary>
        /// Enum UserIntegration
        /// </summary>
        /// <remarks>Juan David Cárdenas</remarks>
        public enum UserIntegration
        {
            /// <summary>
            /// The contract formalization
            /// </summary>
            [StringValue("GesCon")]
            GesCon,
            /// <summary>
            /// The audit
            /// </summary>
            [StringValue("Audit")]
            Audit
        }

        /// <summary>
        /// Enum MicroService
        /// </summary>
        /// <remarks>Juan David Cárdenas</remarks>
        public enum MicroService
        {
            /// <summary>
            /// The MS core
            /// </summary>
            [StringValue("MsParameters")]
            MsParameters
        }

        /// <summary>
        /// Enum LogType
        /// </summary>
        /// <remarks>Juan David Cárdenas</remarks>
        public enum LogType
        {
            /// <summary>
            /// The information
            /// </summary>
            [StringValue("Info")]
            Info,
            /// <summary>
            /// The error
            /// </summary>
            [StringValue("Error")]
            Error
        }

        public enum NavegabilityBInnacle
        {
            /// <summary>
            /// The announcement creation
            /// </summary>
            [StringValue("/solicitud-devolucion")]
            pathApplicationDevolutions,
            /// <summary>
            /// The stage update
            /// </summary>
            [StringValue("Solicitud Devolucion Cuenta Custodia")]
            namePathApplicationDevolutions,


            [StringValue("/WarrantyGeneral")]
            pathWarrantyGeneral,

            [StringValue("WarrantyGeneral")]
            namePathWarrantyGeneral,
        }

        public struct BinnacleTypesLoadingOfBankMovements
        {
            public const string OptionName = "Carga movimientos bancos",
                    OptionPath = "/cargaArchivosBancos";
        }
    }
}
