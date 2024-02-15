using BlazorBase.Web.Service.Interfaces;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorBase.Web.Service
{
    public class BaseService<T> : BaseServiceAPI, IDisposable, IBaseService<T> where T : class
    {
        public BaseService(IHttpClientFactory httpClientFactory, NavigationManager navigation, IConfiguration configuracao) : base(httpClientFactory, navigation)
        {
            NomeApi = configuracao.GetSection("BlazorBase.Api").Value;
            Url = typeof(T).Name.ToLower();
        }

        #region Get

        public virtual async Task<List<T>> GetAllAsync(params object[] parametros)
        {
            var content = await Get(parametros);
            return Deserialize<List<T>>(content);
        }

        public virtual async Task<T> GetByIdAsync(params object[] parametros)
        {
            var content = await Get(parametros);
            return Deserialize<T>(content);
        }

        public virtual async Task<bool> GetExistsAsync(params object[] parametros)
        {
            var content = await Get(parametros);
            return Deserialize<bool>(content);
        }

        public virtual async Task<dynamic> ProcurarRegistrosAsync(int id, params string[] campos)
        {
            var content = await Post((id, campos), "ProcurarRegistros");
            if (!string.IsNullOrEmpty(content))
                return JsonConvert.DeserializeObject<dynamic>(content);
            else
                return null;
            //return Deserialize<dynamic>(content);
        }

        #endregion

        #region Create

        public virtual async Task<T> CreateAsync(T obj, params object[] parametros)
        {
            var content = await Post(obj, parametros);
            return Deserialize<T>(content);
        }

        #endregion

        #region Update

        public virtual async Task<bool> UpdateAsync(Object obj, params object[] parametros)
         {
            var content = await Put(obj, parametros);
            return Deserialize<bool>(content);
        }

        #endregion

        #region Delete

        public virtual async Task<bool> DeleteAsync(params object[] parametros)
        {
            var content = await Delete(parametros);
            return Deserialize<bool>(content);
        }

        #endregion
    }
}
