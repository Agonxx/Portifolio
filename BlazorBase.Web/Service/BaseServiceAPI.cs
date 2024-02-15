
using Microsoft.AspNetCore.Components;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorBase.Web.Service
{
    public abstract class BaseServiceAPI
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly JsonSerializerOptions _options;
        protected readonly NavigationManager _navigation;
        protected string NomeApi { get; set; }
        protected string Url { get; set; }

        public BaseServiceAPI(IHttpClientFactory httpClientFactory, NavigationManager navigation)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
                IncludeFields = true
            };
            _navigation = navigation;
        }

        protected string UnirParametros(params object[] parametros)
        {
            if (parametros.Length == 0)
                return "";

            var url = string.Join('/', parametros);

            return url.Replace("/?", "?");
        }

        protected void AdicionaHeaders(HttpClient client)
        {
            //if (string.IsNullOrEmpty(GlobalVar.UserToken?.Token))
            //    _navigation.NavigateTo(ConstantsAPI.LoginAuth, true);

            //client.DefaultRequestHeaders.Add(ConstantsAPI.Authorization, "Bearer " + GlobalVar.UserToken.Token);
            //client.DefaultRequestHeaders.Add(ConstantsAPI.PERIODO_ATIVO_KEY, GlobalVar.PeriodoAtivo?.ToString("dd/MM/yyyy"));
        }

        protected void RemoverHeaders()
        {
            //_navigation.NavigateTo(ConstantsAPI.LoginAuth, true);
        }

        public string AddParamQuery(params (string name, object value)[] parametros)
        {
            string url = "?";
            foreach (var (name, value) in parametros)
            {
                url += $"&{name}={value}";
            }

            return url.Replace("?&", "?");
        }

        protected virtual async Task<string> Get(params object[] parametros)
        {
            try
            {
                var urlFinal = $"{Url}/{UnirParametros(parametros)}";
                var client = _httpClientFactory.CreateClient(NomeApi);
                AdicionaHeaders(client);
                var response = await client.GetAsync(urlFinal);
                return await TratarResponse(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        protected virtual async Task<string> Post(Object obj = null, params object[] parametros)
        {
            try
            {

                var urlFinal = $"{Url}/{UnirParametros(parametros)}";
                var objJson = new StringContent(System.Text.Json.JsonSerializer.Serialize(obj, _options), Encoding.UTF8, "application/json");
                var client = _httpClientFactory.CreateClient(NomeApi);

                AdicionaHeaders(client);
                var response = await client.PostAsync(urlFinal, objJson);
                return await TratarResponse(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        protected virtual async Task<string> Put(Object obj = null, params object[] parametros)
        {
            try
            {
                var urlFinal = $"{Url}/{UnirParametros(parametros)}";
                var objJson = new StringContent(System.Text.Json.JsonSerializer.Serialize(obj, _options), Encoding.UTF8, "application/json");
                var client = _httpClientFactory.CreateClient(NomeApi);
                AdicionaHeaders(client);
                var response = await client.PutAsync(urlFinal, objJson);
                return await TratarResponse(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        protected virtual async Task<string> Delete(params object[] parametros)
        {
            try
            {
                var urlFinal = $"{Url}/{UnirParametros(parametros)}";
                var client = _httpClientFactory.CreateClient(NomeApi);
                AdicionaHeaders(client);
                var response = await client.DeleteAsync(urlFinal);
                var content = await response.Content.ReadAsStringAsync();

                return await TratarResponse(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        private async Task<string> TratarResponse(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return content;
                case System.Net.HttpStatusCode.Unauthorized:
                case System.Net.HttpStatusCode.PreconditionFailed:
                    {
                        RemoverHeaders();
                        return null;
                    }
                case System.Net.HttpStatusCode.BadRequest:
                case System.Net.HttpStatusCode.Forbidden:
                    {
                        throw new HttpRequestException(content);
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        protected T Deserialize<T>(string content)
        {
            if (string.IsNullOrEmpty(content))
                return default;

            return System.Text.Json.JsonSerializer.Deserialize<T>(content, _options);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
