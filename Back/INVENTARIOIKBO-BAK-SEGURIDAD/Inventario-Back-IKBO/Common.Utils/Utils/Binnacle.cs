using Common.Utils.Constant;
using Common.Utils.Dto;
using Common.Utils.Enums;
using Common.Utils.Resources;
using Common.Utils.RestServices.Interface;
using Common.Utils.Utils.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Reflection;
using System.Text;

namespace Common.Utils.Utils
{
    /// <summary>
    /// This clase map the behaviour of an binnacle by log process, log Exception and log Audit
    /// </summary>

    [ExcludeFromCodeCoverage]
    public class Binnacle : IBinnacle
    {
        #region Variables

        /// <summary>
        /// Implementation a IO restService
        /// </summary>
        private readonly IRestService _restService;
        private readonly IConfiguration _configuration;
        private readonly IAuthentication _authentication;
        private readonly IUtils _utils;

        #endregion Variables

        #region Constructors

        public Binnacle(IConfiguration iConfiguration, IAuthentication authentication, IRestService restService, IUtils utils)
        {
            _configuration = iConfiguration;
            _authentication = authentication;
            _restService = restService;
            _utils = utils;
            _configExecMicroService = new ConfigExecMicroService();
        }

        #endregion Constructors

        #region Properties

        public ConfigExecMicroService _configExecMicroService { get; set; }

        public string UserName { get; set; }

        public string TokenAzureFunction { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// This method save the audit of the application in data base
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="auditLogDto">Object audit</param>
        /// <returns>sucess</returns>
        public async Task SaveAudit(string comment, int? idRecord,
            string action, object affectRecord, string entity)
        {
            AuditLogDto auditLogDto = MakeObjectAuditLogDto(GetState(action), affectRecord, entity);
            _configExecMicroService = GetExecMicroService("Audit", "Audit");
            await _restService.PostRestServiceAsync<AuditLogDto>(_configExecMicroService.Url, _configExecMicroService.Controller, _configExecMicroService.Method, auditLogDto, _configExecMicroService.headers);
        }

        /// <summary>
        /// Method who make the object audit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="comment">Comment </param>
        /// <param name="idRecord">Id create for record</param>
        /// <param name="optionName">Table name affected</param>
        /// <param name="action">Action on data base [Insert, Update, Delete]</param>
        /// <param name="affectRecord">Information of record</param>
        /// <returns></returns>
        public AuditLogDto MakeObjectAuditLogDto(string action, object affectRecord, string entity)
        {
            AuditLogDto outAuditLogDto = new AuditLogDto
            {
                IdMicroservicio = _utils.GetDataInCache<string>(CacheKeys.Microservicio),
                IdNavegabilidad = _utils.GetDataInCache<string>(CacheKeys.Navegabilidad),
                DireccionIp = _utils.GetDataInCache<string>(CacheKeys.Ip),
                Modulo = Enums.Enums.BinnacleOptions.Modulo.GetDisplayName(),
                Tabla = entity,
                TipoAccion = action.ToString(),
                AccionRealizada = JsonConvert.SerializeObject(affectRecord, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                })
            };
            return outAuditLogDto;
        }

        /// <summary>
        /// This method save all exceptions make in the application in data base
        /// </summary>
        /// <param name="exceptionLogDto"></param>
        /// <returns></returns>
        public async Task SaveException(ExceptionLogDto exceptionLogDto)
        {
            //Get all information for micro service execution
            _configExecMicroService = GetExecMicroService("Exception", "Exception");
            await _restService.PostRestServiceAsync<ExceptionLogDto>(_configExecMicroService.Url, _configExecMicroService.Controller, _configExecMicroService.Method, exceptionLogDto, _configExecMicroService.headers);
        }

        /// <summary>
        /// Method who make the object exception
        /// </summary>
        /// <param name="codigoError">excepcion.HResult</param>
        /// <param name="metodo">Method affected</param>
        /// <param name="mensaje">excepcion.message</param>
        /// <param name="tipo"> excepcion.GetType().FullName</param>
        /// <param name="nombreUsuarioIdentificado">User name</param>
        /// <returns></returns>
        public ExceptionLogDto MakeObjectExceptionLog(string codigoError, string metodo, string mensaje, string tipo)
        {
            ExceptionLogDto exceptionLog = new ExceptionLogDto()
            {
                IdMicroservicio = _utils.GetDataInCache<string>(CacheKeys.Microservicio),
                IdNavegabilidad = _utils.GetDataInCache<string>(CacheKeys.Navegabilidad),
                DireccionIp = _utils.GetDataInCache<string>(CacheKeys.Ip),
                NombreComponente = metodo,
                Descripcion = string.Concat(codigoError, tipo, mensaje)
            };
            return exceptionLog;
        }

        /// <summary>
        /// This method save ths traceability on application in data base
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logProcessDto"></param>
        /// <returns></returns>
        public async Task SaveProcess(ProcessLogDto logProcessDto)
        {
            var saveBinnacle = _utils.GetDataInCache<bool>(CacheKeys.SaveProcess);
            if (saveBinnacle)
            {
                _configExecMicroService = GetExecMicroService("Process", "Process");
                await _restService.PostRestServiceAsync<ProcessLogDto>(_configExecMicroService.Url, _configExecMicroService.Controller, _configExecMicroService.Method, logProcessDto, _configExecMicroService.headers);
            }
        }

        /// <summary>
        /// Method who make the traceability in a process
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action">Method process</param>
        /// <param name="idAplicacionMicroservicio">id aplication micro service</param>
        /// <param name="userName">user name</param>
        /// <param name="idFatherProcess">id father process</param>
        /// <param name="affectEntity">information of entity</param>
        /// <returns></returns>
        public ProcessLogDto MakeObjectLogProcess(string action, string idFatherProcess, string affectEntity)
        {
            ProcessLogDto logProcessDto = new ProcessLogDto()
            {
                IdMicroservicio = _utils.GetDataInCache<string>(CacheKeys.Microservicio),
                IdNavegabilidad = _utils.GetDataInCache<string>(CacheKeys.Navegabilidad),
                DireccionIp = _utils.GetDataInCache<string>(CacheKeys.Ip),
                Modulo = Enums.Enums.BinnacleOptions.Modulo.GetDisplayName(),
                Opcion = idFatherProcess,
                Subopcion = affectEntity,
                Agente = "XM",
                descripcionVariable = action
            };
            return logProcessDto;
        }

        /// <summary>
        /// This method get the ip address
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetIpAddress()
        {
            string ip = string.Empty;

            foreach (var ipClient in Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ipClient => ipClient.AddressFamily.ToString() == "InterNetwork"))
            {
                ip = ipClient.ToString();
            }

            if (string.IsNullOrEmpty(ip))
            {
                foreach (var ipClient in Dns.GetHostAddresses(Dns.GetHostName()).Where(ipClient => ipClient.AddressFamily.ToString() == "InterNetwork"))
                {
                    ip = ipClient.ToString();
                }
            }

            return ip;
        }

        /// <summary>
        /// This method that a entity name
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        public string GetEntityName<TEntity>(TEntity entity)
        {
            string entityName = typeof(TEntity).Name.ToString().Replace("Entity", "");
            return entityName;
        }

        /// <summary>
        /// This method get alla configurations for excecution mirco service
        /// </summary>
        /// <param name="controller">Name controller</param>
        /// <param name="methodName">Name method</param>
        /// <returns></returns>
        public ConfigExecMicroService GetExecMicroService(string controller, string methodName)
        {
            ConfigExecMicroService configExec = new ConfigExecMicroService();
            //Get all information for micro service execution
            IConfiguration conf = _configuration.GetSection("BinnacleService");
            configExec.Url = conf.GetSection("UrlBinnacleNew").Value;
            configExec.Controller = conf.GetSection(controller).GetSection("Controller").Value;
            configExec.Method = conf.GetSection(methodName).GetSection("Registrar").Value;
            configExec.Token = _authentication.GetToken();
            configExec.AddHeaders("Authorization", configExec.Token);
            return configExec;
        }

        /// <summary>
        /// Metodo que obtiene los errores de la exception
        /// </summary>
        /// <param name="ex">Ecepcion con el error</param>
        /// <param name="level">Número de niveles que deberia iterar en la propiedad InnerException</param>
        /// <returns>Retorna una cadena con el detalle del error por cada Exception e InnerException</returns>
        public string GetErrorMessage(Exception ex)
        {
            IConfiguration conf = _configuration.GetSection("BinnacleService");
            StringBuilder sb = new StringBuilder();
            int counter = 1;
            int level = conf.GetSection("LevelException").Value == null ? 30 : Convert.ToInt32(conf.GetSection("LevelException").Value);
            while (ex != null && counter <= level)
            {
                sb.AppendLine(string.Format(ExceptionResouce.ErrorLevel, counter, counter));
                sb.AppendLine(string.Format(ExceptionResouce.ErrorMessage, counter, ex.Message));
                sb.AppendLine(string.Format(ExceptionResouce.ErrorSource, counter, ex.Source));
                sb.AppendLine(string.Format(ExceptionResouce.ErrorTargetSite, counter, ex.TargetSite));
                sb.Append(string.Format(ExceptionResouce.ErrorStackTrace, counter, ex.StackTrace));
                ex = ex.InnerException;
                counter++;
            }
            return sb.ToString();
        }

        /// <summary>
        /// This method get id micro service
        /// </summary>
        /// <returns></returns>
        public string GetIdAppMicroService()
        {
            IConfiguration conf = _configuration.GetSection("BinnacleService");
            string idAppMicroService = Convert.ToString(conf.GetSection("IdAplicacionMicroservicio").Value);
            return idAppMicroService;
        }

        /// <summary>
        /// This method get a user name
        /// </summary>
        /// <returns></returns>
        public string GetUserNameCache()
        {
            return ApplicationConfig.UsernameApplication;
        }

        /// <summary>
        /// This method get a Pk name property to entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name=""></param>
        public string GetPk<TEntity>(TEntity entity)
        {
            string pk = string.Empty;
            Type type = entity.GetType();
            PropertyInfo[] properties = type.GetProperties();
            //This replaces all the iteration above:
            PropertyInfo property = properties
                .FirstOrDefault(p => p.GetCustomAttributes(false)
                    .Any(a => a.GetType().Equals(typeof(KeyAttribute))));
            if (property != null)
            {
                pk = property.Name;
            }
            return pk;
        }

        /// <summary>
        /// This method get a state save in BD
        /// </summary>
        /// <returns></returns>
        public string GetState(string bdActions)
        {
            var enums = Enum.GetValues(typeof(Enums.Enums.AuditActions)).Cast<Enums.Enums.AuditActions>();
            var action = enums.FirstOrDefault(w => w.ToDescriptionString().Equals(bdActions));
            switch (action)
            {
                case Enums.Enums.AuditActions.Added:
                    bdActions = Enums.Enums.BdActions.INSERT.ToString();
                    break;

                case Enums.Enums.AuditActions.Modified:
                    bdActions = Enums.Enums.BdActions.UPDATE.ToString();
                    break;

                case Enums.Enums.AuditActions.Deleted:
                    bdActions = Enums.Enums.BdActions.DELETE.ToString();
                    break;
            }
            return bdActions;
        }
        #endregion Methods
    }
}