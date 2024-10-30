namespace Common.Utils.RestServices.Interface
{
    public interface IRestService
    {
        Task<T> GetRestServiceAsync<T>(string url, string controller, string method,
            IDictionary<string, string> parameters, IDictionary<string, string> headers);

        Task<T> PostRestServiceAsync<T>(string url, string controller, string method
            , object parameters, IDictionary<string, string> headers);

        Task<T> GetRestServiceAsyncList<T>(string url, string controller, string method,
          IDictionary<string, string[]> parameters, IDictionary<string, string> headers);

        Task<T> PostRestServiceStringParametersAsync<T>(string url, string controller, string method
            , IDictionary<string, string> parameters, IDictionary<string, string> headers);

        bool PostRestServicePortalAsync(byte[] fileByte, string url, string fileName, string token);
    }
}