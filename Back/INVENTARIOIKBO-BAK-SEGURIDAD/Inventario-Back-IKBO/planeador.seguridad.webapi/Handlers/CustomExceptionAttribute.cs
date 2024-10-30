
using Common.Utils.Excepcions;
using Common.Utils.Resources;
using Common.Utils.Utils.Interface;
using planeador.seguridad.webapi.Models;
using Ideam.Sirlab.WebApi.Models.General;
using Infraestructura.Core.Context.SQLServer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace planeador.seguridad.webapi.Handlers
{
    [ExcludeFromCodeCoverage]
    public class CustomExceptionAttribute : ExceptionFilterAttribute
    {
        private readonly IBinnacle _ibinnacle;
        private readonly ContextSql _context;

        public CustomExceptionAttribute(IBinnacle ibinnacle, ContextSql context)
        {
            _ibinnacle = ibinnacle;
            this._context = context;
        }

        /// <summary>
        /// Metodo encargado de capturar todas las Excepciones del proyecto,
        /// Se debe agregar el decorador a cada controller [TypeFilter(typeof(CustomExceptionHandler))]
        /// </summary>
        /// <param name="context"> Parametro donde queda capturada la Exception </param>
        public override void OnException(ExceptionContext context)
        {
            HttpResponseException oResponseExeption = new HttpResponseException();
            ResponseModel<string> oResponse = new ResponseModel<string>()
            {
                IsSuccess = false,
                Result = JsonConvert.SerializeObject(context.Exception)
            };

            if (context.Exception is BusinessException)
            {
                oResponseExeption.Status = StatusCodes.Status400BadRequest;
                oResponse.Messages = context.Exception.Message;
                context.ExceptionHandled = true;
                this.SaveException(context);
            }
            else
            {
                if (context.Exception != null)
                {
                    oResponseExeption.Status = StatusCodes.Status500InternalServerError;
                    oResponse.Messages = GeneralMessages.Error500;
                    this.SaveException(context);
                }
                context.ExceptionHandled = true;
            }

            context.Result = new ObjectResult(oResponseExeption.Value)
            {
                StatusCode = oResponseExeption.Status,
                Value = oResponse
            };

            if (oResponseExeption.Status == StatusCodes.Status500InternalServerError)
                context.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = GeneralMessages.Error500;
        }

        /// <summary>
        /// This method that save a exception log in data base
        /// </summary>
        /// <param name="context"></param>
        public void SaveException(ExceptionContext context)
        {
            // var binnacleSave = _context.ConfigurationParameterEntities.FirstOrDefault(x => x.ParameterName == Enums.BinnacleOptions.Exceptions.GetDisplayName()).Value;
            // var result = Convert.ToInt32(binnacleSave);
            /*
             if (Convert.ToBoolean(result))
             {
                 _ibinnacle.SaveException(_ibinnacle.MakeObjectExceptionLog
                 (Convert.ToString(context.Exception.HResult),
                 ((ControllerActionDescriptor)context.ActionDescriptor).ActionName,
                 _ibinnacle.GetErrorMessage(context.Exception),
                 context.Exception.GetType().FullName));
             }
            */
        }
    }
}