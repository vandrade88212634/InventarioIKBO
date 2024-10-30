namespace Common.Utils.Utils.Interface
{
    public interface IUtils
    {
        /// <summary>
        /// devuelve el tipo de rol de un agente
        ///  tipo de mercado (comercializador, generador, distribuidor, transmisor)
        /// </summary>
        /// <param name="agent">agente</param>
        /// <returns></returns>
        string RolAgent(string agent);

        /// <summary>
        /// Method responsible for returning a list of dates with weekends that are in a range of dates
        /// </summary>
        /// <param name="start_date">Start of the date of the range to evaluate</param>
        /// <param name="end_date">End of range date to evaluate</param>
        /// <returns></returns>
        List<DateTime> GetWeekendDatesRange(DateTime startDate, DateTime endDate);

        /// <summary>
        /// save object in cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="parameterTime"></param>
        void SaveDataInCache(string key, object data, string parameterTime);

        /// <summary>
        /// Remove object in cache
        /// </summary>
        /// <param name="key"></param>
        void RemoveDataInCache(string key);

        /// <summary>
        /// Get T object in cache
        /// </summary>
        /// <param name="key"></param>
        T GetDataInCache<T>(object key);

        /// <summary>
        /// Extrac a string part
        /// </summary>
        /// <param name="_string"></param>
        /// <returns></returns>
        string GetExtracString(string _string);

        /// <summary>
        /// Extract list of roles
        /// </summary>
        /// <param name="_string"></param>
        /// <returns></returns>
        string[] GetListRoles(string roles);

        /// <summary>
        /// Checks if a role is in the list of roles
        /// </summary>
        /// <param name="role">role to check</param>
        /// <param name="roles">comma separated string of roles</param>
        /// <param name="priorityRoles">List of priority roles. These roles take precedence over the checked role</param>
        /// <returns>true / false</returns>
        bool HasRole(string role, string roles, List<string> priorityRoles = null);

        /// <summary>
        /// Checks if a role is in the list of roles
        /// </summary>
        /// <param name="role">role to check</param>
        /// <param name="roles">List of roles</param>
        /// <param name="priorityRoles">List of priority roles. These roles take precedence over the checked role</param>
        /// <returns>true / false</returns>
        bool HasRole(string role, string[] roles, List<string> priorityRoles = null);

        /// <summary>
        /// Checks if the agent role is in the list of roles
        /// </summary>
        /// <param name="roles">comma separated string of roles</param>
        /// <returns>true / false</returns>
        bool HasAgentRole(string roles);

        /// <summary>
        /// Checks if the agent role is in the list of roles
        /// </summary>
        /// <param name="roles">List of roles</param>
        /// <returns>true / false</returns>
        bool HasAgentRole(string[] roles);

        /// <summary>
        /// Checks if the administrator role is in the list of roles
        /// </summary>
        /// <param name="roles">comma separated string of roles</param>
        /// <returns>true / false</returns>
        bool HasAdministratorRole(string roles);

        /// <summary>
        /// Checks if the administrator role is in the list of roles
        /// </summary>
        /// <param name="roles">List of roles</param>
        /// <returns>true / false</returns>
        bool HasAdministratorRole(string[] roles);

        /// <summary>
        /// Checks if the analyst role is in the list of roles
        /// </summary>
        /// <param name="roles">comma separated string of roles</param>
        /// <returns>true / false</returns>
        bool HasAnalystRole(string roles);

        /// <summary>
        /// Checks if the analyst role is in the list of roles
        /// </summary>
        /// <param name="roles">List of roles</param>
        /// <returns>true / false</returns>
        bool HasAnalystRole(string[] roles);

        /// <summary>
        /// Calculate NextDate
        /// Victor Andrade
        /// </summary>
        /// <param name=" Datetime NextDate, Parametres Nextday
        /// <returns>NextDate</returns>
        /// 
        DateTime GetNextDate(DateTime NextDate, int NextDay, int Expiration);

        string formatea(string Texto);

        string reformateaIns(string Texto);

        string SetDynamicTable(SetDynamicTableDto input);

        string devuelveCamino();
        string creararchivo(string camino, string nombre, string Docbase64);

        string Encrypt(string plainText);
        string Decrypt(string menajeEncriptado);
        string GetRandomPassword(int length);

    }
}