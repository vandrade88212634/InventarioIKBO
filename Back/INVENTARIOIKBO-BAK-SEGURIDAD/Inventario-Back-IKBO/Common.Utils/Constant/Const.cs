using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Constant
{
    [ExcludeFromCodeCoverage]
    public struct CacheKeys
    {
        public const string
           TokenKey = "SecurityToken",
           UniqueName = "UniqueName",
           UserName = "UserName",
           Microservicio = "MicroServiceNameId",
           Navegabilidad = "IdNavegavilidad",
           Ip = "Ip",
           SaveProcess = "SaveProcess";
    }

    [ExcludeFromCodeCoverage]
    public struct ClaimToken
    {
        public const string
            IdUsuario = "IdUsuario",
            UniqueName = "unique_name",
            NombreCompleto = "NombreCompleto",
            Roles = "Roles";
    }

    [ExcludeFromCodeCoverage]
    public struct RolesAcmeName
    {
        public const string
            ACME_ADMINISTRADOR = "ACME-ADMINISTRADOR",
            ACME_ANALISTA = "ACME-ANALISTA FINANCIERO",
            ACME_AGENTE = "ACME-AGENTE",
            ACME_BANCO = "ACME-BANCO",
            ACME_APROBADOR = "ACME-APROBADOR";
    }

    [ExcludeFromCodeCoverage]
    public struct ExpirationLoadState
    {
        public const string
            Pending = "Pending",
            Loaded = "Loaded",
            Closed = "Closed",
            Reversed = "Reversed";
    }

    [ExcludeFromCodeCoverage]
    public struct PaymentAppliedConcept
    {
        public const string
            Capital = "K",
            Interests = "I";
    }

    [ExcludeFromCodeCoverage]
    public struct LoadFileOrigin
    {
        public const string
            Multicash = "Multicash",
            BankFile = "Archivo Banco";
    }

    [ExcludeFromCodeCoverage]
    public struct LoadFileType
    {
        public const string
            Head = "Encabezado",
            Detail = "Detalle",
            NotApplied = "N/A";
    }

    [ExcludeFromCodeCoverage]
    public struct ApplicationConfig
    {
        public const string UsernameApplication = "SINTEG - Garantias";
        public const string CodeWithOutMove = "AG-SIN-MOV";
        public const string dateExecuteWithOut = "LASTDATEEXECUTEJOBWITHOUTMOVE";
        public const string daysAgenteWithoutMove = "DIASAGENTESSINMOVIMIENTOCUENTASSINMOVIMIENTOS";
    }

    [ExcludeFromCodeCoverage]
    public struct StateDataLoad
    {
        public const string
            Complete = "Completo",
            Error = "Error",
            Process = "Proceso",
            ErrorField = "Error campo";
    }


    [ExcludeFromCodeCoverage]
    public struct ProcessResultMulticash
    {
        public const string
            Processed = "Se ha procesado",
            NotProcessed = "No se ha procesado";
    }

    [ExcludeFromCodeCoverage]
    public struct EmailVariablesChangeScheme
    {
        public const string

            CodigoAgente = "&lt;&lt;CodigoAgente&gt;&gt;",
            NombreCortoEmpresa = "&lt;&lt;NombreCortoEmpresa&gt;&gt;",
            Concepto = "&lt;&lt;conceptos&gt;&gt;",
            FechaVencimiento = "&lt;&lt;Fecha Vencimiento&gt;&gt;",
            FechaInicial = "&lt;&lt;FechaInicial&gt;&gt;",
            FechaFinal = "&lt;&lt;FechaFinal&gt;&gt;",
            ValorSolicitado = "&lt;&lt;ValorSolicitado&gt;&gt;",
            ValorPendiente = "&lt;&lt;ValorPendiente&gt;&gt;",
            TotalEmpresa = "&lt;&lt;TotalEmpresa&gt;&gt;";
    }

    [ExcludeFromCodeCoverage]
    public struct TemplateVariables
    {
        public const string
            VarStartFixed = "&lt;&lt;",
            VarEndFixed = "&gt;&gt;";
    }

    [ExcludeFromCodeCoverage]
    public struct AzureBlobStorageMethod
    {
        public const string
            Updated = "Updated",
            Get = "Get",
            Save = "Save";
    }
}