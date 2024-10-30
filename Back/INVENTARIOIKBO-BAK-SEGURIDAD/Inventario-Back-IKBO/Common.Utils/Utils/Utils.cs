using Common.Utils.Constant;
using Common.Utils.Dto;
using Common.Utils.RestServices.Interface;
using Common.Utils.Utils.Interface;

using HtmlAgilityPack;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Web;

namespace Common.Utils.Utils
{
    [ExcludeFromCodeCoverage]
    public class Utils : IUtils
    {
        public readonly IConfiguration configuration;
        private readonly IMemoryCache cache;
        public readonly IRestService RestService;
        private readonly string openPlaceholderTag = $"[tableDetail@]";
        private readonly string closePlaceholderTag = $"[/tableDetail@]";
        private readonly IWebHostEnvironment _webHostEnvironment;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="cache"></param>
        public Utils(IConfiguration configuration, IMemoryCache cache, IWebHostEnvironment webHostEnvironment)
        {
            this.configuration = configuration;
            this.cache = cache;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// devuelve el tipo de rol de un agente
        ///  tipo de mercado (comercializador, generador, distribuidor, transmisor)
        /// </summary>
        /// <param name="agent">agente</param>
        /// <returns></returns>
        public string RolAgent(string agent)
        {
            string rol = string.Empty;
            if (!string.IsNullOrEmpty(agent))
            {
                string letra = agent.Substring(agent.Length - 1, 1);
                if (letra.ToLower().Equals("c"))
                    rol = "COMERCIALIZADOR";
                if (letra.ToLower().Equals("g"))
                    rol = "GENERADOR";
                if (letra.ToLower().Equals("d"))
                    rol = "DISTRIBUIDOR";
                if (letra.ToLower().Equals("t"))
                    rol = "TRANSMISOR";
            }
            return rol;
        }

        /// <summary>
        /// devuelve el tipo de rol de un agente
        ///  tipo de mercado (comercializador, generador, distribuidor, transmisor)
        /// </summary>
        /// <param name="agent">agente</param>
        /// <returns></returns>
        public int OrderAgent(string agent)
        {
            int orderAgent = 0;
            if (!string.IsNullOrEmpty(agent))
            {
                string letra = agent.Substring(agent.Length - 1, 1);
                if (letra.ToLower().Equals("c"))
                    orderAgent = 3;
                if (letra.ToLower().Equals("g"))
                    orderAgent = 2;
                if (letra.ToLower().Equals("d"))
                    orderAgent = 1;
                if (letra.ToLower().Equals("t"))
                    orderAgent = 4;
            }
            return orderAgent;
        }

        /// <summary>
        /// Method responsible for returning a list of dates with weekends that are in a range of dates
        /// </summary>
        /// <param name="start_date">Start of the date of the range to evaluate</param>
        /// <param name="end_date">End of range date to evaluate</param>
        /// <returns></returns>
        public List<DateTime> GetWeekendDatesRange(DateTime startDate, DateTime endDate)
        {
            return Enumerable.Range(0, (int)((endDate - startDate).TotalDays) + 1)
                             .Select(n => startDate.AddDays(n))
                             .Where(x => x.DayOfWeek == DayOfWeek.Saturday
                                    || x.DayOfWeek == DayOfWeek.Sunday)
                             .ToList();
        }

        /// <summary>
        /// save object in cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="parameterTime"></param>
        public void SaveDataInCache(string key, object data, string parameterTime)
        {
            IConfiguration conf = configuration.GetSection("ParametersTimeHoursCache");
            string timeCacheFromHoursToken = conf.GetSection(parameterTime).Value;

            MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(double.Parse(timeCacheFromHoursToken)));

            cache.Set(key, data, cacheEntryOptions);
        }

        /// <summary>
        /// Remove object in cache
        /// </summary>
        /// <param name="key"></param>
        public void RemoveDataInCache(string key)
        {
            cache.Remove(key);
        }

        /// <summary>
        /// Get T object in cache
        /// </summary>
        /// <param name="key"></param>
        public T GetDataInCache<T>(object key)
        {
            cache.TryGetValue<T>(key, out T result);

            return result;
        }

        /// <summary>
        /// Extrac a string part
        /// </summary>
        /// <param name="_string"></param>
        /// <returns></returns>
        public string GetExtracString(string _string)
        {
            StringBuilder stringName = new StringBuilder();
            for (int i = 0; i < _string.Length; i++)
            {
                if (Char.IsLetter(_string[i]))
                    stringName.Append(_string[i]);
            }

            return stringName.ToString();
        }

        /// <summary>
        /// Extract list of roles
        /// </summary>
        /// <param name="_string"></param>
        /// <returns></returns>
        public string[] GetListRoles(string roles)
        {
            string[] listRoles = roles.Split(',');

            for (int i = 0; i < listRoles.Length; i++)
                listRoles[i] = listRoles[i].ToLower();

            return listRoles;
        }

        /// <summary>
        /// Checks if a role is in the list of roles
        /// </summary>
        /// <param name="role">role to check</param>
        /// <param name="roles">comma separated string of roles</param>
        /// <param name="priorityRoles">List of priority roles. These roles take precedence over the checked role</param>
        /// <returns>true / false</returns>
        public bool HasRole(string role, string roles, List<string> priorityRoles = null)
        {
            return this.HasRole(role, this.GetListRoles(roles), priorityRoles);
        }

        /// <summary>
        /// Checks if a role is in the list of roles
        /// </summary>
        /// <param name="role">role to check</param>
        /// <param name="roles">List of roles</param>
        /// <param name="priorityRoles">List of priority roles. These roles take precedence over the checked role</param>
        /// <returns>true / false</returns>
        public bool HasRole(string role, string[] roles, List<string> priorityRoles = null)
        {
            if (priorityRoles == null)
                priorityRoles = new List<string>();

            bool hasPriorityRoles = roles != null && priorityRoles.Any(p => roles.Contains(p));
            bool hasRole = roles != null && roles.Contains(role);

            return hasRole && !hasPriorityRoles;
        }

        /// <summary>
        /// Checks if the agent role is in the list of roles
        /// </summary>
        /// <param name="roles">comma separated string of roles</param>
        /// <returns>true / false</returns>
        public bool HasAgentRole(string roles)
        {
            return this.HasAgentRole(this.GetListRoles(roles));
        }

        /// <summary>
        /// Checks if the agent role is in the list of roles
        /// </summary>
        /// <param name="roles">List of roles</param>
        /// <returns>true / false</returns>
        public bool HasAgentRole(string[] roles)
        {
            List<string> priorityRoles = new List<string> { RolesAcmeName.ACME_ADMINISTRADOR.ToLower(), RolesAcmeName.ACME_ANALISTA.ToLower() };
            return this.HasRole(RolesAcmeName.ACME_AGENTE.ToLower(), roles, priorityRoles);
        }

        /// <summary>
        /// Checks if the analyst role is in the list of roles
        /// </summary>
        /// <param name="roles">comma separated string of roles</param>
        /// <returns>true / false</returns>
        public bool HasAnalystRole(string roles)
        {
            return this.HasAnalystRole(this.GetListRoles(roles));
        }

        /// <summary>
        /// Checks if the analyst role is in the list of roles
        /// </summary>
        /// <param name="roles">List of roles</param>
        /// <returns>true / false</returns>
        public bool HasAnalystRole(string[] roles)
        {
            List<string> priorityRoles = new List<string> { RolesAcmeName.ACME_ADMINISTRADOR.ToLower() };
            return this.HasRole(RolesAcmeName.ACME_AGENTE.ToLower(), roles, priorityRoles);
        }

        /// <summary>
        /// Checks if the administrator role is in the list of roles
        /// </summary>
        /// <param name="roles">comma separated string of roles</param>
        /// <returns>true / false</returns>
        public bool HasAdministratorRole(string roles)
        {
            return this.HasAdministratorRole(this.GetListRoles(roles));
        }

        /// <summary>
        /// Checks if the administrator role is in the list of roles
        /// </summary>
        /// <param name="roles">List of roles</param>
        /// <returns>true / false</returns>
        public bool HasAdministratorRole(string[] roles)
        {
            return this.HasRole(RolesAcmeName.ACME_ADMINISTRADOR.ToLower(), roles);
        }

        /// <summary>
        /// Calculate NextDate
        /// Victor Andrade
        /// </summary>
        /// <param name=" Datetime NextDate, Parametres Nextday
        /// <returns>NextDate</returns>
        ///
        public DateTime GetNextDate(DateTime NextDate, int NextDay, int Expiration)
        {
            while (Convert.ToInt32(NextDate.DayOfWeek) == NextDay)
            {
                NextDate = NextDate.AddDays(1);
            }

            return NextDate;
        }

        public string formatea(string Texto)
        {
            if (Texto == null || Texto == "")
            {
                return "0";
            }
            Texto = reformateaIns(Texto);
            string valorformateado = "";
            string valorentero = "";

            if (Texto.IndexOf(".") != -1)
            {
                valorentero = Texto.ToString().Substring(0, Texto.ToString().IndexOf("."));
            }
            else
            {
                valorentero = Texto;
            }

            string nuevovalor = "";
            if (valorentero.Length > 3)
            {
                for (int lnLetra = valorentero.Length; lnLetra > 0; lnLetra = lnLetra - 3)
                {
                    if (lnLetra <= 3)
                    {
                        nuevovalor = valorentero.Substring(0, lnLetra) + nuevovalor;
                    }
                    else
                    {
                        nuevovalor = "," + valorentero.Substring(lnLetra - 3, 3) + nuevovalor;
                    }
                }

                valorformateado = nuevovalor;
            }
            else
            {
                valorformateado = valorentero;
            }

            return valorformateado;
        }

        public string reformateaIns(string Texto)
        {
            if (Texto == null || Texto == "0")
            { return "0"; }

            Texto = Texto.Replace(",", ".");
            Texto = Texto.Replace("$", "");
            if (Texto == "")
            {
                Texto = "0";
            }
            return Texto;
        }

        public string FormatVariableToken(string token)
        {
            return $"{TemplateVariables.VarStartFixed}{token}{TemplateVariables.VarEndFixed}";
        }

        public string ParsetHtml(string html, TemplateHtmlTable tableData, string placeholder = null)
        {
            string result = null;

            if (string.IsNullOrEmpty(placeholder))
                placeholder = "tableDetail";

            string brTag = "<br>";
            string openPlaceholderTag = $"[{placeholder}]";
            string closePlaceholderTag = $"[/{placeholder}]";
            string openRepeatColumnTag = "[repeatColum]";
            string closeRepeatColumnTag = "[/repeatColum]";
            string openRepeatColumnBrTag = string.Concat(openRepeatColumnTag, brTag);
            string closeRepeatColumnBrTag = string.Concat(brTag, closeRepeatColumnTag);

            string openRepeatRowTag = "[repeatRow]";
            string closeRepeatRowTag = "[/repeatRow]";
            string openRepeatRowBrTag = string.Concat(openRepeatRowTag, brTag);
            string closeRepeatRowBrTag = string.Concat(brTag, closeRepeatRowTag);

            int startIndex = html.IndexOf(openPlaceholderTag);
            int endIndex = html.IndexOf(closePlaceholderTag);

            if (startIndex != -1 && endIndex != -1)
            {
                string table = html.Substring(startIndex, endIndex - startIndex);
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(table);

                var htmlTable = htmlDoc.DocumentNode.SelectSingleNode("//table");
                var tableColRows = htmlTable.SelectNodes("tr|tbody/tr");
                var tableColGroups = htmlTable.SelectNodes("colgroup") != null ? htmlTable.SelectNodes("colgroup").FirstOrDefault() : null;

                int index = 0;
                foreach (var row in tableColRows)
                {
                    var cols = row.SelectNodes("td");

                    if (cols.Any(x => x.InnerText.Contains(openRepeatRowTag)) && cols.Any(x => x.InnerText.Contains(openRepeatColumnTag))) //Body with dynamic colums
                    {
                        var rowHtml = row.OuterHtml;
                        int rowIndex = 0;
                        foreach (var body in tableData.Rows)
                        {
                            HtmlNode newRow = rowIndex == 0 ? row : HtmlNode.CreateNode(rowHtml);
                            cols = newRow.SelectNodes("td");
                            var dynamicColums = cols.Where(x => x.InnerText.Contains(openRepeatColumnTag)).ToList();
                            var fixedColums = cols.Where(x => !x.InnerText.Contains(openRepeatColumnTag)).ToList();

                            foreach (var dc in body.DynamicColumns)
                            {
                                var column = dynamicColums.FirstOrDefault(x => x.InnerText.Contains(dc.Key));
                                if (column != null)
                                {
                                    int colIndex = 0;
                                    var columnHtml = column.OuterHtml;
                                    foreach (var itemValue in dc.Value)
                                    {
                                        string newColumnHtml = columnHtml
                                            .Replace(dc.Key, itemValue)
                                            .Replace(openRepeatColumnBrTag, string.Empty)
                                            .Replace(closeRepeatColumnBrTag, string.Empty)
                                            .Replace(openRepeatColumnTag, string.Empty)
                                            .Replace(closeRepeatColumnTag, string.Empty);

                                        if (colIndex == 0)
                                            column.InnerHtml = HtmlNode.CreateNode(newColumnHtml).InnerHtml;
                                        else
                                            newRow.InsertAfter(HtmlNode.CreateNode(newColumnHtml), column);

                                        colIndex++;
                                    }
                                }
                            }

                            foreach (var fc in body.FixedColumns)
                            {
                                var fixedColumn = fixedColums.FirstOrDefault(x => x.InnerText.Contains(fc.Key));
                                if (fixedColumn != null)
                                {
                                    fixedColumn.InnerHtml = fixedColumn.InnerHtml
                                            .Replace(fc.Key, fc.Value)
                                            .Replace(openRepeatRowBrTag, string.Empty)
                                            .Replace(closeRepeatRowBrTag, string.Empty)
                                            .Replace(openRepeatRowTag, string.Empty)
                                            .Replace(closeRepeatRowTag, string.Empty);
                                }
                            }

                            if (rowIndex > 0)
                                row.ParentNode.InsertAfter(newRow, row);

                            rowIndex++;
                        }
                    }
                    else if (cols.Any(x => x.InnerText.Contains(openRepeatRowTag))) //Body without dynamic columns 
                    {
                        var rowHtml = row.OuterHtml;
                        int rowIndex = 0;
                        if (tableData.Rows.Any())
                        {
                            foreach (var body in tableData.Rows)
                            {
                                HtmlNode newRow = rowIndex == 0 ? row : HtmlNode.CreateNode(rowHtml);
                                cols = newRow.SelectNodes("td");
                                var fixedColums = cols.Where(x => !x.InnerText.Contains(openRepeatColumnTag)).ToList();

                                foreach (var fc in body.FixedColumns)
                                {
                                    var fixedColumn = fixedColums.FirstOrDefault(x => x.InnerText.Contains(fc.Key));
                                    if (fixedColumn != null)
                                    {
                                        fixedColumn.InnerHtml = fixedColumn.InnerHtml
                                                .Replace(fc.Key, fc.Value)
                                                .Replace(openRepeatRowBrTag, string.Empty)
                                                .Replace(closeRepeatRowBrTag, string.Empty)
                                                .Replace(openRepeatRowTag, string.Empty)
                                                .Replace(closeRepeatRowTag, string.Empty);
                                    }
                                }

                                if (rowIndex > 0)
                                    row.ParentNode.InsertAfter(newRow, row);

                                rowIndex++;
                            }
                        }
                        else
                        {
                            HtmlNode newRow = rowIndex == 0 ? row : HtmlNode.CreateNode(rowHtml);
                            cols = newRow.SelectNodes("td");
                            var fixedColums = cols.Where(x => !x.InnerText.Contains(openRepeatColumnTag)).ToList();
                            foreach (var item in fixedColums)
                            {
                                item.InnerHtml = string.Empty;
                            }
                        }
                    }
                    else if (cols.Any(x => x.InnerText.Contains(openRepeatColumnTag)) && index == 0) //Header with dynamic columns 
                    {
                        var dynamicColums = cols.Where(x => x.InnerText.Contains(openRepeatColumnTag)).ToList();
                        foreach (var dc in tableData.Header.DynamicColumns)
                        {
                            var column = dynamicColums.FirstOrDefault(x => x.InnerText.Contains(dc.Key));
                            int positionColum = cols.IndexOf(column);
                            if (column != null)
                            {
                                int colIndex = 0;
                                var columnHtml = column.OuterHtml;
                                string colGroupHtml = null;
                                HtmlNode colGroup = null;
                                if (tableColGroups != null && tableColGroups.ChildNodes.Count > 0)
                                {
                                    colGroup = tableColGroups.ChildNodes.Skip(positionColum).Take(1).FirstOrDefault();
                                    colGroupHtml = colGroup != null ? colGroup.OuterHtml : null;
                                }
                                foreach (var itemValue in dc.Value)
                                {
                                    string newColumnHtml = columnHtml
                                        .Replace(dc.Key, itemValue)
                                        .Replace(openRepeatColumnBrTag, string.Empty)
                                        .Replace(closeRepeatColumnBrTag, string.Empty)
                                        .Replace(openRepeatColumnTag, string.Empty)
                                        .Replace(closeRepeatColumnTag, string.Empty);

                                    if (colIndex == 0)
                                    {
                                        column.InnerHtml = HtmlNode.CreateNode(newColumnHtml).InnerHtml;
                                    }
                                    else
                                    {
                                        row.InsertAfter(HtmlNode.CreateNode(newColumnHtml), column);
                                        if (colGroup != null)
                                            tableColGroups.InsertBefore(HtmlNode.CreateNode(colGroupHtml), colGroup);
                                    }
                                    colIndex++;
                                }
                            }
                        }
                    }
                    else if (cols.Any(x => x.InnerText.Contains(openRepeatColumnTag)) && index > 1) //Footer with dynamic columns 
                    {
                        var dynamicColums = cols.Where(x => x.InnerText.Contains(openRepeatColumnTag));
                        var fixedColums = cols.Where(x => !x.InnerText.Contains(openRepeatColumnTag)).ToList();

                        foreach (var dc in tableData.Footer.DynamicColumns)
                        {
                            var column = dynamicColums.FirstOrDefault(x => x.InnerText.Contains(dc.Key));
                            if (column != null)
                            {
                                int colIndex = 0;
                                var columnHtml = column.OuterHtml;
                                foreach (var itemValue in dc.Value)
                                {
                                    string newColumnHtml = columnHtml
                                        .Replace(dc.Key, itemValue)
                                        .Replace(openRepeatColumnBrTag, string.Empty)
                                        .Replace(closeRepeatColumnBrTag, string.Empty)
                                        .Replace(openRepeatColumnTag, string.Empty)
                                        .Replace(closeRepeatColumnTag, string.Empty);

                                    if (colIndex == 0)
                                        column.InnerHtml = HtmlNode.CreateNode(newColumnHtml).InnerHtml;
                                    else
                                        row.InsertAfter(HtmlNode.CreateNode(newColumnHtml), column);

                                    colIndex++;
                                }
                            }
                        }

                        foreach (var fc in tableData.Footer.FixedColumns)
                        {
                            var fixedColumn = fixedColums.FirstOrDefault(x => x.InnerText.Contains(fc.Key));
                            if (fixedColumn != null)
                            {
                                fixedColumn.InnerHtml = fixedColumn.InnerHtml
                                        .Replace(fc.Key, fc.Value)
                                        .Replace(openRepeatRowBrTag, string.Empty)
                                        .Replace(closeRepeatRowBrTag, string.Empty)
                                        .Replace(openRepeatRowTag, string.Empty)
                                        .Replace(closeRepeatRowTag, string.Empty);
                            }
                        }
                    }
                    else if (index > 1) //Footer without dynamic columns 
                    {
                        var fixedColums = cols.Where(x => !x.InnerText.Contains(openRepeatColumnTag)).ToList();
                        foreach (var fc in tableData.Footer.FixedColumns)
                        {
                            var fixedColumn = fixedColums.FirstOrDefault(x => x.InnerText.Contains(fc.Key));
                            if (fixedColumn != null)
                            {
                                fixedColumn.InnerHtml = fixedColumn.InnerHtml
                                        .Replace(fc.Key, fc.Value)
                                        .Replace(openRepeatRowBrTag, string.Empty)
                                        .Replace(closeRepeatRowBrTag, string.Empty)
                                        .Replace(openRepeatRowTag, string.Empty)
                                        .Replace(closeRepeatRowTag, string.Empty);
                            }
                        }
                    }

                    index++;
                }

                result = htmlTable.OuterHtml;
            }

            return result;
        }

        /// <summary>
        /// Set Dynamic Table ONLY ROWS.
        /// </summary>
        /// <param name="input">The input SetDynamicTableDto.</param>
        /// <returns>string</returns>
        /// <remarks>Augusto Recuero</remarks>
        public string SetDynamicTable(SetDynamicTableDto input)
        {
            string flatOpenPlaceholderTag = openPlaceholderTag.Replace("@", input.numberTable != null ? input.numberTable : "");
            string flatClosePlaceholderTag = closePlaceholderTag.Replace("@", input.numberTable != null ? input.numberTable : "");
            int startIndex = input.body.IndexOf(flatOpenPlaceholderTag);
            int endIndex = input.body.IndexOf(flatClosePlaceholderTag);
            Type typeEntity = input.typeDto;
            IEnumerable<PropertyInfo> props = typeEntity.GetProperties();

            TemplateHtmlTable templateTableData = new TemplateHtmlTable();

            foreach (var item in input.requestSubmit)
            {
                TemplateHtmlTableBody body = new TemplateHtmlTableBody();
                foreach (PropertyInfo itemName in props)
                {
                    string propertyName = itemName.Name;
                    string varName = this.FormatVariableToken(itemName.CustomAttributes.FirstOrDefault().NamedArguments.FirstOrDefault().TypedValue.Value.ToString());

                    if (!body.FixedColumns.ContainsKey(varName))
                        body.FixedColumns.Add(varName, item.GetType().GetProperty(propertyName).GetValue(item, null)?.ToString());
                }
                templateTableData.Rows.Add(body);
            }
            string htmlTable = this.ParsetHtml(input.body, templateTableData, flatOpenPlaceholderTag.Replace("[", "").Replace("]", ""));

            if (startIndex != -1 && endIndex != -1)
            {
                string table = input.body.Substring(startIndex, endIndex - startIndex);
                input.body = input.body
                    .Replace(table, htmlTable)
                    .Replace(flatClosePlaceholderTag, string.Empty);
            }


            return input.body.Replace("<table class=", "<table width='100%' class=");
        }
        public string SetSignaturesLetters(string body, List<SetSignaturesLettersDto> signatures)
        {
            int index = 1;
            foreach (SetSignaturesLettersDto item in signatures)
            {
                string number = index.ToString();
                body = body.Replace($"{TemplateVariables.VarStartFixed}Firmante{number}{TemplateVariables.VarEndFixed}", item.Signature)
                .Replace($"{TemplateVariables.VarStartFixed}CargoFirmante{number}{TemplateVariables.VarEndFixed}", item.Position)
                .Replace($"{TemplateVariables.VarStartFixed}CedulaFirmante{number}{TemplateVariables.VarEndFixed}", "C.C. " + item.Document)
                .Replace($"{TemplateVariables.VarStartFixed}LugarExpedicionCedulaFirmante{number}{TemplateVariables.VarEndFixed}", "de " + item.ExpeditionLocation);

                index++;
            }
            if (signatures.Count < 2)
            {
                string number = "2";
                body = body.Replace($"{TemplateVariables.VarStartFixed}Firmante{number}{TemplateVariables.VarEndFixed}", "")
                .Replace($"{TemplateVariables.VarStartFixed}CargoFirmante{number}{TemplateVariables.VarEndFixed}", "")
                .Replace($"{TemplateVariables.VarStartFixed}CedulaFirmante{number}{TemplateVariables.VarEndFixed}", "")
                .Replace($"{TemplateVariables.VarStartFixed}LugarExpedicionCedulaFirmante{number}{TemplateVariables.VarEndFixed}", "");
            }
            body = body.Replace($"<table class=\"ck-table-resized\" style=\"border-color:hsl(0, 0%, 100%);border-style:solid;\">", "<table border=0 width='100%'>")
                .Replace($"<table width=\'100%\' class=\"ck-table-resized\" style=\"border-color:hsl(0, 0%, 100%);border-style:solid;\">", "<table border=0 width='100%'>")
                .Replace($"<table class=\"ck-table-resized\">", "<table border=0 width='100%'>");
            return body;
        }

        /// <summary>
        /// Set Copy Destinatary.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <param name="destinataries">The destinataries.</param>
        /// <param name="userName">The userName.</param>
        /// <returns>string</returns>
        /// <remarks>Augusto Recuero</remarks>
        public string SetCopyDestinatary(string body, List<string> destinataries, string userName)
        {
            string list = "";
            foreach (string item in destinataries)
            {
                list = list + "<li>" + item + "</li>";
            }
            body = body
                .Replace($"{TemplateVariables.VarStartFixed}DestinatariosCopia{TemplateVariables.VarEndFixed}", "<ul>" + list + "</ul>")
                .Replace($"{TemplateVariables.VarStartFixed}QuienElaboro{TemplateVariables.VarEndFixed}", userName);
            return body.Replace("table border=0", "table width='100%' border=0");
        }

        public string creararchivo(string camino,string nombre, string Docbase64)
        {
            string seCreo = "";
            try
            {
                string webRootPath = _webHostEnvironment.ContentRootPath;



                camino = camino + "\\" + nombre;
                string path = "";
                path = webRootPath + camino;
                byte[] bytes = Convert.FromBase64String(Docbase64);
                System.IO.FileStream stream =
                new FileStream(path, FileMode.CreateNew);
                System.IO.BinaryWriter writer =
                    new BinaryWriter(stream);
                writer.Write(bytes, 0, bytes.Length);
                writer.Close();
                seCreo = "Se creo";
            }
            catch (Exception ex)
            {
                seCreo = ex.Message;
                
            }
            return seCreo;
        }

        public string devuelveCamino()
        {
            string webRootPath = _webHostEnvironment.ContentRootPath;

            return webRootPath;
        }

       
            public string Encrypt(string plainText)
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Encoding.UTF8.GetBytes("ThisIsASecretKey"); ;
                    aesAlg.IV = Encoding.UTF8.GetBytes("ThisIsASecretKey");
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(plainText);
                            }
                            return Convert.ToBase64String(msEncrypt.ToArray());
                        }
                    }
                }
            }


       

        public string Decrypt(string mensajeEncriptado)
        {
            var keybytes = Encoding.UTF8.GetBytes("ThisIsASecretKey");
            var iv = Encoding.UTF8.GetBytes("ThisIsASecretKey");

            var encrypted = Convert.FromBase64String(mensajeEncriptado);
            var decriptedFromJavascript = DecryptStringFromBytes(encrypted, keybytes, iv);
            return string.Format(decriptedFromJavascript);
        }

        private string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments. 
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException("cipherText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }

            // Declare the string used to hold 
            // the decrypted text. 
            string plaintext = null;

            // Create an RijndaelManaged object 
            // with the specified key and IV. 
            using (var rijAlg = new RijndaelManaged())
            {
                //Settings 
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;

                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform. 
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                try
                {
                    // Create the streams used for decryption. 
                    using (var msDecrypt = new MemoryStream(cipherText))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {

                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream 
                                // and place them in a string. 
                                plaintext = srDecrypt.ReadToEnd();

                            }

                        }
                    }
                }
                catch
                {
                    plaintext = "keyError";
                }
            }

            return plaintext;
        }

        public string GetRandomPassword(int length)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }

    }
}