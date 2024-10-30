// ***********************************************************************
// Assembly         : Common.Utils
// Author           : Pablo Restrepo <pablo.restrepo@ingeneo.com.co>
// Created          : 04-12-2021
//
// Last Modified By : Pablo Restrepo <pablo.restrepo@ingeneo.com.co>
// Last Modified On : 04-15-2021
// ***********************************************************************
// <copyright file="Enums.cs" company="Common.Utils">
//     Copyright (c) Ingeneo S.A.S. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Common.Utils.Enums
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Class Enums.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Enums
    {
        /// <summary>
        /// Enums that maps operations in data base 
        /// </summary>
        public enum BdActions
        {
            /// <summary>
            /// Query in dada base
            /// </summary>
            [Display(Name = "QUERY")]
            QUERY,

            /// <summary>
            /// Insert in data base
            /// </summary>
            [Display(Name = "INSERT")]
            INSERT,

            /// <summary>
            /// Update in data base
            /// </summary>
            [Display(Name = "UPDATE")]
            UPDATE,

            /// <summary>
            /// Delete in data base
            /// </summary>
            [Display(Name = "DELETE")]
            DELETE
        }

        /// <summary>
        /// Enum AuditActions
        /// </summary>
        public enum AuditActions
        {
            /// <summary>
            /// The added
            /// </summary>
            [Description("Added")]
            [Display(Name = "Added")]
            Added,

            /// <summary>
            /// The modified
            /// </summary>
            [Description("Modified")]
            [Display(Name = "Modified")]
            Modified,

            /// <summary>
            /// The deleted
            /// </summary>
            [Description("Deleted")]
            [Display(Name = "Deleted")]
            Deleted,
        }

        /// <summary>
        /// Enum MasterTypeList
        /// </summary>
        public enum MasterTypeList
        {
            /// <summary>
            /// Master list of type business
            /// </summary>
            Business = 3,

            /// <summary>
            /// Master list of type schemas
            /// </summary>
            ScemaTypes = 66,

            /// <summary>
            /// Master list of concept Module Oracle
            /// </summary>
            ConceptLoadExpiration = 70,

            /// <summary>
            /// 
            /// </summary>
            Warranties = 97,

            /// <summary>
            /// 
            /// </summary>
            applicationsState = 90,

            /// <summary>
            /// Request type
            /// </summary>
            RequestType = 19,

            /// <summary>
            /// Master list homolagate concept ties
            /// </summary>
            homologateConceptMovTIES = 102,

            /// <summary>
            /// Master list Events
            /// </summary>
            [Description("Eventos")]
            Events = 80,

            /// <summary>
            /// Master list account state
            /// </summary>
            [Description("Informes")]
            ReportList = 45,

            /// <summary>
            /// Master list file type load banks
            /// </summary>
            [Description("Tipo de archivo carga bancos")]
            FileTypeLoadBanks = 276,

            /// <summary>
            /// Master list account state
            /// </summary>
            [Description("Rutas bancos multicash")]
            RoutesBankMulticash = 277
        }
        public enum ParametersNames
        {
            [Description("Rendimientos netos mes anteriores")]
            [Display(Name = "Rendimientos netos mes anteriores")]
            RETURNS = 1,
            [Description("Rendimientos conceptos")]
            [Display(Name = "Rendimientos conceptos")]
            RETURNS_CONCEPTS = 2,
            [Description("Contratos pendientes")]
            [Display(Name = "Contratos pendientes")]
            PENDINGS_CONTRACTS = 3,
            [Description("TOKEN GENÉRICO")]
            [Display(Name = "TOKEN_GENÉRICO")]
            TOKEN_GENERICO = 4,
            [Description("DIAJOBSTATE")]
            [Display(Name = "DIAJOBSTATE")]
            DIAJOBSTATE = 5,
            [Description("RUTADESTINOMULTICASH")]
            [Display(Name = "RUTADESTINOMULTICASH")]
            ROUTEDESTINEMULTICASH = 6,
            [Description("RUTADESTINOMULTICASHDEUDAS")]
            [Display(Name = "RUTADESTINOMULTICASHDEUDAS")]
            ROUTEDESTINEMULTICASHDEUDA = 7,
            [Description("CUENTASMULTICASHDEUDAS")]
            [Display(Name = "CUENTASMULTICASHDEUDAS")]
            ACCOUNTMULTICASH = 8,

        }

        public enum EventCode
        {
            [Description("Estados de cuenta conciliación")]
            [Display(Name = "STMTACCTCL")]
            STMTACCTCL = 20,

            [Description("Notificación agentes vencimiento garantías")]
            [Display(Name = "NTAGVENCGR")]
            NTAGVENCGR = 21,

            [Description("Notificación agentes liberación de garantías")]
            [Display(Name = "NTAGLIBGR")]
            NTAGLIBGR = 22,

            [Description("Notificación extractos bancarios - BBVA")]
            [Display(Name = "NTFEXTBAN1")]
            NTFEXTBAN1 = 23,

            [Description("Notificación extractos bancarios - OCCIDENTE")]
            [Display(Name = "NTFEXTBAN2")]
            NTFEXTBAN2 = 24,

            [Description("Agentes cambio de estado")]
            [Display(Name = "AGECHANSTA")]
            AGECHANSTA = 25,

            [Description("Notificación contabilidad")]
            [Display(Name = "NTCTB")]
            NTCTB = 26,

            [Description("Notificación conciliación cuenta custodia")]
            [Display(Name = "NTCCC")]
            NTCCC = 27,
        }

        public enum TokenParam
        {
            [Description("Estados de cuenta conciliación")]
            [Display(Name = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlBydWViYXMwMyIsIklkVXN1YXJpbyI6IjAiLCJSb2xlcyI6IkFDTUUtQVBST0JBRE9SLEFDTUUtQkFOQ08sSGVyb3BlQ29uc3VsdGFHZW5lcmFsQ2FsLEFDTUUtQU5BTElTVEEgRklOQU5DSUVSTyxBQ01FLUFETUlOSVNUUkFET1IsQUNNRS1BR0VOVEUsR2lkQWdlbnRlc0NhbEMsR2lkQWdlbnRlc1BydSxhZ2VudGVuYWNpb25hbHJlZGVzcGFjaG9QcnUsSGVyb3BlQ29uc3VsdGFHZW5lcmFsUHJ1LGFnZW50ZW5hY2lvbmFsQ2FsLGFnZW50ZWNvbWVyY2lhbGl6YWRvclJEQ2FsLGFnZW50ZW5hY2lvbmFscmVkZXNwYWNob0NhbCxhZ2VudGVjb21lcmNpYWxpemFkb3JQcnVSRCxBZ2VudGVOYWNpb25hbHBydSIsIk5vbWJyZUNvbXBsZXRvIjoiUHJ1ZWJhcyAwMyBDTkRuZXQiLCJuYmYiOjE2NTkwMzI0NDIsImV4cCI6MTY5MDU2ODQ0MiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo2MTgwNi8iLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYxODA2LyJ9.plkfzzdNUHkvil74lmOU9BVQLhg0BSxbES9MpUo0NCg")]
            TOKEN = 20
        }

        public enum RequestTypeCode
        {
            /// <summary>
            /// Solicitud de devolución cuenta custodia
            /// </summary>
            [Description("14")]
            CustodyAccountRefundRequest = 2686
        }

        public enum LoadFileOriginId
        {
            Multicash = 243,
            BankFile = 244
        }

        public enum TypeProcessValue
        {
            DateTime = 1,
            Integer = 2,
            Decimal = 3,
            String = 4,
            DateTime2 = 5
        }

        [ExcludeFromCodeCoverage]
        public struct LoadType
        {
            public const string
                Expiration = "Expiration";
        }

        [ExcludeFromCodeCoverage]
        public struct LoadExpirationType
        {
            public const string
                Manual = "Manual";
        }

        public enum SchemeTypeOracle
        {
            [Description("GARASEMA")]
            GARASEMA = 5,

            [Description("GARAMENS")]
            GARAMENS = 6,

            [Description("TIES")]
            TIES = 4,

            [Description("TIESEXTRA")]
            TIESEXTRA = 9,

            [Description("SEMAEXT")]
            SEMAEXT = 7,

            [Description("MENSUEXT")]
            MENSUEXT = 8,
        }

        public enum StatusApplication
        {
            [Description("NU")]
            nueva = 1,

            [Description("AP")]
            cerrada = 2,

            [Description("PEDEPR")]
            enviadaxm = 3,

            [Description("RE")]
            rechazada = 4,

            [Description("Validada")]
            validada = 5,
        }

        public enum StatusTypeTransfer
        {
            [Description("Devolución Disponible Cuenta Custodia")]
            devolucion = 11,
        }

        public enum SchemeType
        {
            [Description("Semanal")]
            SEMANAL = 5,

            [Description("Mensual")]
            MENSUAL = 6,

            [Description("TIES")]
            TIES = 4,

            [Description("TIESEXTRA")]
            TIESEXTRA = 4,

            [Description("SEMAEXT")]
            SEMAEXT = 7,

            [Description("MENSUEXT")]
            MENSUEXT = 8,
        }

        public enum StatusAccount
        {
            [Description("Activo")]
            Active = 30,


            [Description("Inactivo")]
            Inacive = 31,

        }

        public enum StatusLoadExpiration
        {
            [Description("Activo")]
            Active = 1,

            [Description("Cancelado")]
            Cancel = 2,

            [Description("Inactivo")]
            Inacive = 3,

            [Description("Reemplazado")]
            Replaced = 4,

            [Description("Vencido")]
            Due = 5,

            [Description("Cierre Ejecutado")]
            CloseExecuted = 6,

            [Description("CANCELADO-NO PAGADO")]
            CancelNoPayment = 7,

            [Description("CANCELADO-PAGADO")]
            CancelPayment = 8
        }

        public enum StatusPreClose
        {
            [Description("Aplicación Pendiente")]
            Pending = 6,

            [Description("Saldo a Favor")]
            PosBalance = 7,

            [Description("Saldo a Favor Pendiente")]
            posBalancePending = 8,

            [Description("Aplicado")]
            Applied = 9,

            [Description("Cierre Pendiente")]
            closePending = 10,

            [Description("Cierre Ejecutado")]
            closeEject = 11,

            [Description("Transferido")]
            transfered = 12,

            [Description("Pago Parcial")]
            PartialPay = 13
        }

        public enum StatusOperation
        {
            [Description("Crear")]
            addA = 1,

            [Description("Editar")]
            editA = 2,

            [Description("Eliminar")]
            deleteA = 8
        }

        public enum ListaCuenta
        {
            [Description("CUENTACUSTODIA")]
            Custody = 1,

            [Description("CUENTAPUENTE")]
            bridge = 2
        }

        public enum EnumAgentExportations
        {
            [Display(Name = "CNCC")]
            agent = 354,

            [Display(Name = "XMII")]
            agentXM = 407
        }
        public enum EnumAgentImportation
        {
            [Display(Name = "CNCG")]
            agent = 355,

            [Display(Name = "XMII")]
            agentXM = 407
        }

        public enum StatusSummaryMulticash
        {
            successfulLoaded = 1,
            emptyNotLoaded = 2
        }

        public enum BanckAccountId
        {
            BanckAccountId = 220
        }

        [ExcludeFromCodeCoverage]
        public struct LoadStateConst
        {
            public const string
                Successfull = "Carga Exitosa",
                SuccessfullAlert = "Carga Exitosa con Alertas",
                Error = "Carga No Exitosa";
        }

        [ExcludeFromCodeCoverage]
        public struct ExpirationType
        {
            public const string
            TIES = "TIES",
            TIESEXTRA = "TIESEXTRA",
            GARASEMA = "Semanal",
            GARAMENS = "Mensual",
            SEMAEXT = "SEMAEXT",
            MENSUEXT = "MENSUEXT";

        }

        [ExcludeFromCodeCoverage]
        public struct LanguageCulture
        {
            public const string
            ENUS = "en-US",
            ESUS = "es-US";
        }

        [ExcludeFromCodeCoverage]
        public struct MyDateFormat
        {
            public const string
            DD_SLASH_MM_SLASH_YYYY = "dd/MM/yyyy",
            YYYY_DASH_MM_DASH_DD = "yyyy-MM-dd";
        }

        public enum ValueNumbers
        {
            [Description("Cero")]
            ZERO = 0,

            [Description("Uno")]
            ONE = 1,

            [Description("Dos")]
            TWO = 2,

            [Description("Tres")]
            THREE = 3,

            [Description("Cuatro")]
            FOUR = 4,

            [Description("Cinco")]
            FIVE = 5,

            [Description("Seis")]
            SIX = 6,

            [Description("Siete")]
            SEVEN = 7,

            [Description("Ocho")]
            EIGTH = 8,

            [Description("Nueve")]
            NINE = 9,

            [Description("Diez")]
            TEN = 10,

            [Description("Once")]
            ELEVEN = 11,

            [Description("Doce")]
            TWELVE = 12,

            [Description("Cincuenta")]
            FIFTY = 50,

            [Description("Cien")]
            ONEHOUNDRED = 100,

            [Description("TrescientosCuatro")]
            THREEHOUNDREDFOUR = 304
        }

        [ExcludeFromCodeCoverage]
        public struct Concept
        {
            public const string
            ZERODESCRIPTION = "Vencimiento TIES",
            ONEDESCRIPTION = "Costo importaciones",
            INTERNATIONATIONALTRANSFER = "VENTA USD GIRO ECUADOR",
            INTERNATIONATIONALTRANSFERBUY = "COMPRA USD GIRO ECUADOR",
            TWODESCRIPTION = "Costo de coberturas vencimiento TIES",
            THREEDESCRIPTION = "Venta USD Giro Ecuador",
            FOURDESCRIPTION = "Compra USD Giro Ecuador",
            ZERO = "0",
            ONE = "1",
            TWO = "2",
            THREE = "3",
            FOUR = "4",
            NINE = "9";
        }

        [ExcludeFromCodeCoverage]
        public struct Business
        {
            public const string DESCRIPTION = "GARANTÍAS";
            public const int IDGARANTIAS = 44;
        }

        [ExcludeFromCodeCoverage]
        public struct WarrantyStatus
        {
            public const string Aprobado = "Aprobado";
            public const string Canceled = "Anulado";
            public const string Liberted = "Liberado";
        }

        public enum EnumBusiness
        {
            [Display(Name = "FOES")]
            FOES = 41,

            [Display(Name = "SIC")]
            SIC = 42,

            [Display(Name = "STN")]
            STN = 43,

            [Display(Name = "GARANTÍAS")]
            GARANTÍAS = 44,

            [Display(Name = "Garantias")]
            GarantiasFTP = 44,

            [Display(Name = "FAZNI")]
            FAZNI = 45,

            [Display(Name = "STR")]
            STR = 46,

            [Display(Name = "TIES")]
            TIES = 47,

            [Display(Name = "CRD")]
            CRD = 48,

            [Display(Name = "RFT")]
            RFT = 49,

            [Display(Name = "DCCT")]
            DCCT = 50,

            [Display(Name = "MS")]
            MS = 51,

            [Display(Name = "CONTRATOS")]
            CONTRATOS = 52,

            [Display(Name = "SALDOP")]
            [Description("SALDOP")]
            SALDOP = 14
        }

        public enum SummaryType
        {
            [Display(Name = "RTINC")]
            RTINC = 1,

            [Display(Name = "RTGMF")]
            RTGMF = 2
        }
        public enum FileTypeLoadBank
        {
            [Display(Name = "CEN")]
            CEN = 1,

            [Display(Name = "RGMF")]
            RGMF = 2,

            [Display(Name = "RING")]
            RING = 3
        }

        [ExcludeFromCodeCoverage]
        public struct PayAdminGrid2
        {
            public const string DESCRIPTIONONE = "No. Cuenta Custodia/ No. Garantia Bancaria";
            public const string DESCRIPTIONTWO = "Mes Garantizar Inicial Bancarias";
            public const string DESCRIPTIONTHREE = "Mes Garantizar Final Bancarias";
            public const string DESCRIPTIONFOUR = "Saldo Cuenta/Monto Garantía Bancaria";
            public const string DESCRIPTIONFIVE = "Valor Congelado Nacionales";
            public const string DESCRIPTIONSIX = "Valor Congelado TIE";
            public const string DESCRIPTIONSEVEN = "Saldo A Favor TIE ";
            public const string DESCRIPTIONEIGTH = "Total Devoluciones TIE";
            public const string DESCRIPTIONNINE = "Valor Congelado TIES Extraordinaria";
            public const string DESCRIPTIONTEN = "Valor Disponible De Saldo Cuenta Custodia/Monto Garantia Bancaria";
            public const string ORIREGISTRY = "RegistryName";
            public const string NEWREGISTRY = "registryName";
            public const string ORIPREPAID = "PrepaidTiesAndNational";
            public const string NEWPREPAID = "prepaidTiesAndNational";
            public const string ORIACCOUNT = "AccountNumber";
            public const string NEWACCOUNT = "accountNumber";
            public const string ORIDATATYPE = "DataType";
            public const string NEWDATATYPE = "dataType";
            public const string ORIGRID2 = "Grid2";
            public const string NEWGRID2 = "grid2";
            public const string ORIGRID3 = "Grid3";
            public const string NEWGRID3 = "grid3";
            public const string ORICOLSGRID2 = "ColsGrid2";
            public const string NEWCOLSGRID2 = "colsGrid2";
            public const string ORIGRID4 = "Grid4";
            public const string NEWGRID4 = "grid4";
            public const string ORICOLSGRID3 = "Colsgrid2";
            public const string NEWCOLSGRID3 = "colsGrid2";
        }

        public struct PayAdminGrid3
        {
            public const string ORIEXPIRATIONDETAILID = "ExpirationDetailId";
            public const string NEWEXPIRATIONDETAILID = "expirationDetailId";
            public const string ORISUMMARYID = "Summaryid";
            public const string NEWSUMARYID = "summaryid";
            public const string ORIBUSINESSCODE = "BusinessCode";
            public const string NEWBUSINESSCODE = "businessCode";
            public const string ORICONCEPTCODE = "ConceptCode";
            public const string NEWCONCEPTCODE = "conceptCode";
            public const string ORICONCEPTDES = "ConceptDescription";
            public const string NEWCONCEPTDES = "conceptDescription";
            public const string ORIEXPIRATIONDATE = "ExpirationDate";
            public const string NEWEXPIRATIONDATE = "ExpirationDate";
            public const string ORIVALUEREQ = "ValueRequested";
            public const string NEWVALUEREQ = "valueRequested";
            public const string ORIVALUEPEN = "ValuePending";
            public const string NEWVALUEPEN = "valuePending";
            public const string ORIVALUEAPP = "ValueApply";
            public const string NEWVALUEAPP = "valueApply";
            public const string ORIACCOUNT = "AccountNumber";
            public const string NEWACCOUNT = "accountNumber";
            public const string ORISCHEME = "Scheme";
            public const string NEWSCHEME = "scheme";
            public const string ORIAGENTCODE = "AgentCode";
            public const string NEWAGENTCODE = "agentCode";
            public const string ORIINVOICE = "InvoiceExpirationDate";
            public const string NEWINVOICE = "invoiceExpirationDate";
            public const string ORIDATESTART = "DateStart";
            public const string NEWDATESTART = "dateStart";
            public const string ORIDATEEND = "DateEnd";
            public const string NEWDATEEND = "dateEnd";
            public const string ORISTATUS = "Status";
            public const string NEWSTATUS = "status";
            public const string ORIDATEWAR = "DateWarranty";
            public const string NEWDATEWAR = "dateWarranty";
            public const string ORICONCATDAT = "ConcatDate";
            public const string NEWCONCATDAT = "concatDate";
            public const string ORICREATEDAT = "CreateDate";
            public const string NEWCREATEDAT = "createDate";
            public const string ORICREATEUSE = "CreatUser";
            public const string NEWCREATEUSE = "creatUser";
            public const string ORIOBSERVA = "Observations";
            public const string NEWOBSERVA = "observations";
            public const string ORIVERSION = "Version";
            public const string NEWVERSION = "version";
            public const string ORITYPELOA = "TypeLoad";
            public const string NEWTYPELOA = "typeLoad";
            public const string ORIVALID = "Valid";
            public const string NEWVALID = "valid";
            public const string ORIVALUEFRO = "ValueFrozenApplied";
            public const string NEWVALUEFRO = "valueFrozenApplied";
            public const string ORIVALUENEG = "ValueNegativeApplied";
            public const string NEWVALUENEG = "valueNegativeApplied";
            public const string ORIVALUEAPL = "ValueApplied";
            public const string NEWVALUEAPL = "valueApplied";
            public const string ORITOTALRET = "TotalReturns";
            public const string NEWTOTALRET = "totalReturns";
            public const string ORICONCEPTORD = "ConceptOrden";
            public const string NEWCONCEPTORD = "conceptOrden";
            public const string ORISEL = "Sel";
            public const string NEWSEL = "sel";
            public const string ORINAMECONAG = "NameConcepAgent";
            public const string NEWNAMECONAG = "nameConcepAgent";
            public const string ORIEXPIRAID = "ExpirationId";
            public const string NEWEXPIRAID = "expirationId";
            public const string ORICOMPANYAGE = "CompanyAgentId";
            public const string NEWCOMPANYAGE = "companyAgentId";
            public const string ORIEXPIRATIONDAT = "ExpirationDate";
            public const string NEWEXPIRATIONDAT = "expirationDate";
            public const string ORIGRID4 = "Grid4";
            public const string NEWORIGRID4 = "grid4";
            public const string ORIGRID41 = "WarrantyPaymentAppliedGarId";
            public const string NEWORIGRID41 = "warrantyPaymentAppliedGarId";
            public const string ORIGRID42 = "AgentGarId";
            public const string NEWORIGRID42 = "agentGarId";
            public const string ORIGRID43 = "ExpirationdetailGarId";
            public const string NEWORIGRID43 = "ExpirationdetailGarId";
            public const string ORIGRID44 = "ValueFrozenApplied";
            public const string NEWORIGRID44 = "valueFrozenApplied";
            public const string ORIGRID45 = "ValueReturnsApplied";
            public const string NEWORIGRID45 = "valueReturnsApplied";
            public const string ORIGRID46 = "Status";
            public const string NEWORIGRID46 = "status";
            public const string ORIGRID47 = "WarrantyNumber";
            public const string NEWORIGRID47 = "warrantyNumber";
            public const string ORIGRID48 = "BankName";
            public const string NEWORIGRID48 = "BankName";

            public const string ORIGRDNEGATIVE = "GrdNegative";
            public const string NEWORIGRDNEGATIVE = "grdNegative";

            public const string ORIGRDNEGATIVE1 = "LoadNegativeDetailGarId";
            public const string NEWORIGRDNEGATIVE1 = "loadNegativeDetailGarId";
            public const string ORIGRDNEGATIVE2 = "LoadExpirationdetailNegativeGarId";
            public const string NEWORIGRDNEGATIVE2 = "loadExpirationdetailNegativeGarId";
            public const string ORIGRDNEGATIVE3 = "LoadExpirationDetailGarId";
            public const string NEWORIGRDNEGATIVE3 = "loadExpirationDetailGarId";
            public const string ORIGRDNEGATIVE4 = "ValueRequestedNegatived";
            public const string NEWORIGRDNEGATIVE4 = "valueRequestedNegatived";
            public const string ORIGRDNEGATIVE5 = "ValueNegativeApplied";
            public const string NEWORIGRDNEGATIVE5 = "valueNegativeApplied";
            public const string ORIGRDNEGATIVE6 = "ExpirationDate";
            public const string NEWORIGRDNEGATIVE6 = "expirationDate";
            public const string ORIGRDNEGATIVE7 = "ApplyDate";
            public const string NEWORIGRDNEGATIVE7 = "applyDate";
        }

        [ExcludeFromCodeCoverage]
        public struct CurrencyAccepted
        {
            public const string
            COP = "COP",
            USD = "USD";
        }

        [ExcludeFromCodeCoverage]
        public struct WarrantyMinDate
        {
            public readonly static DateTime
            TwoThousandTen = new DateTime(2010, 1, 1);
        }

        [ExcludeFromCodeCoverage]
        public struct AgentWarrantyTypes
        {
            public const string
            GENERATOR = "G",
            MARKETER = "C",
            DISTRIBUTOR = "D",
            TRANSMITTER = "T";
        }

        [ExcludeFromCodeCoverage]
        public struct typeWarranty
        {
            public const string PREPAID = "Prepagos";
            public const string BANKS = "Bancarias";
        }
        public enum TrueOrFalse
        {
            [Description("true")]
            t = 'T',
            [Description("false")]
            f = 'F'
        }

        public enum PaymentClass
        {
            Normal = 1,
            Warranty = 2,
            Stamps = 3,
            HigherValue = 4,
            ManualPayments = 5,
            InternalTransfers = 6,
            TestWeight = 7,
            ReserveRefund = 8,
            FrozenWarranty = 9,
            WarrantyRefund = 10,
            AvailableRefund = 11,
            ManualPaymentsWarranty = 12,
            FrozenNational = 13,
            InvoiceDebtors = 14,
            YieldDistribution = 15,
            DueMonthCloseImportations = 16,
            DueMonthCloseExportations = 17,
            FrozenTiesExtra = 18,
            InvoiceDues = 19,
            TransferAccountFunds = 20,
            DistributionIncomeImports = 22
        }
        public enum AccountCustody
        {
            XmAccountCustody = 332
        }

        public enum AgentIdFromAccountCustody
        {
            XmAgentId = 407
        }

        public enum AccountClass
        {
            [Description("Beneficiaria")]
            Beneficiary = 28,
            [Description("Custodia")]
            Custody = 29,
            [Description("Propia")]
            Own = 36,
            [Description("Custodia y Beneficiaria")]
            CustodyAndBeneficiary = 35
        }

        public enum AccountClassCode
        {
            [Description("Beneficiaria")]
            Beneficiary = 1,

            [Description("Custodia")]
            Custody = 2,

            [Description("Propia")]
            Own = 3,

            [Description("Custodia y Beneficiaria")]
            CustodyAndBeneficiary = 4,
        }

        //sirve para preparados, distribución y transferencia
        /// <summary>
        /// Warning.
        /// When one more enumeration is added, the GetStatePreparedPaymentStateSpanish method must be updated within the ExtendedMethods class to devour the name of the state in Spanish
        /// </summary>
        public enum PreparedPaymentState
        {
            [Display(Name = "Preparado")]
            Prepared = 1,

            [Display(Name = "Pendiente de distribución")]
            PendingDistribute = 2,

            [Display(Name = "Distribuido")]
            Distributed = 3,

            [Display(Name = "Pendiente de distribución de estampilla")]
            PendingDistributeStamp = 4,

            [Display(Name = "Estampilla distribuida")]
            StampDistributed = 5,

            [Display(Name = "Pendiente de validación")]
            PendingValidation = 6,

            [Display(Name = "Validada")]
            Validated = 7,

            [Display(Name = "Pendiente aprobadores")]
            PendingApprovers = 8,

            [Display(Name = "Pendiente segundo aprobador")]
            PendingSecondApprover = 9,

            [Display(Name = "Rechazada")]
            Rejected = 10,

            [Display(Name = "Aprobada")]
            Approved = 11,

            [Display(Name = "En transferencia")]
            InTranfers = 12,

            [Display(Name = "N/A")]
            NA = 13
        }


        public enum EmailHermexParameters
        {
            IdElementEmail = 1,
            IdTypeListEmail = 1,
            IdElement = 0,
            IdTypeList = 0,
            IdApplication = 1,
            [Description("Email")]
            TypeNotification = 0
        }

        public enum TaskId
        {
            [Description("DebAgents")]
            TaskAgentDebtors = 25,

            [Description("NotiGBD")]
            TaskNotiAgentDebtors = 237
        }

        public enum EventsCodeList
        {
            [Description("Notificar cancelación de suministro agentes")]
            [Display(Name = "CANSUAGE")]
            CANSUAGE = 1,

            [Description("Notificar cancelación de suministro interna")]
            [Display(Name = "CANSUINT")]
            CANSUINT = 2,

            [Description("Notificar Cierre nacional")]
            [Display(Name = "NOTCINAL")]
            NOTCINAL = 3
        }

        public enum TypeNotification
        {
            [Description("Notificación Agentes")]
            [Display(Name = "NOTIAGENT")]
            NOTIAGENT = 1,

            [Description("Notificación Interna")]
            [Display(Name = "DebAgents")]
            NOTIINTER = 2
        }

        public enum NotCarGar
        {
            [Description("Notificación cargas 1")]
            [Display(Name = "NTCARG1")]
            NTCARG1,
            [Description("Notificación cargas 1")]
            [Display(Name = "NTCARG2")]
            NTCARG2,
        }

        public enum BinnacleOptions
        {
            /// <summary>
            /// Query in dada base
            /// </summary>
            [Display(Name = "ActivarLogAuditoria")]
            Audit,

            /// <summary>
            /// Insert in data base
            /// </summary>
            [Display(Name = "ActivarLogExcepciones")]
            Exceptions,

            /// <summary>
            /// Update in data base
            /// </summary>
            [Display(Name = "ActivarLogProceso")]
            Process,

            [Display(Name = "/Sinteg-Garantias")]
            Modulo,

        }

    }
}