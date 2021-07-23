using Newtonsoft.Json;
using PesquisaValidacaoCep.API.Shared.Requests;
using PesquisaValidacaoCep.API.Shared.Response;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PesquisaValidacaoCep.API.Shared.Service
{
    public abstract class HttpClientService
    {
        readonly string _jsonMediaType = "application/json";

        public async Task<ConsultaCepResponse> GetAsync(ConsultaCepRequest request)
        {
            try
            {
                var instanceOut = new ConsultaCepResponse();

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    client.BaseAddress = new Uri($"https://viacep.com.br/ws/");
                    client.Timeout = TimeSpan.FromMinutes(15);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_jsonMediaType));

                    response = await client.GetAsync($"{request.Cep}/json");

                    if (response.IsSuccessStatusCode)
                        instanceOut = JsonConvert.DeserializeObject<ConsultaCepResponse>(await response.Content.ReadAsStringAsync());
                    else
                    {
                        var serviceResult = await response.Content.ReadAsAsync<ServiceResult>(); 
                        instanceOut.ErrorMessage = serviceResult.Message;
                    }

                    instanceOut.ProcessOk = response.IsSuccessStatusCode;
                }

                return instanceOut;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter dados do servidor. Erro: {ex.Message}");
            }
        }
    }
}
