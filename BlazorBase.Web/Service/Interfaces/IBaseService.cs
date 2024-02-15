namespace BlazorBase.Web.Service.Interfaces
{
    public interface IBaseService<T>
    {
        Task<List<T>> GetAllAsync(params object[] parametros);
        Task<T> GetByIdAsync(params object[] parametros);
        Task<bool> GetExistsAsync(params object[] parametros);
        Task<T> CreateAsync(T obj, params object[] parametros);
        Task<bool> UpdateAsync(object obj, params object[] parametros);
        Task<bool> DeleteAsync(params object[] parametros);
        Task<dynamic> ProcurarRegistrosAsync(int id, params string[] campos);
    }
}