using PesquisaValidacaoCep.API.Shared.Interfaces;
using PesquisaValidacaoCep.API.Shared.Requests;
using PesquisaValidacaoCep.API.Shared.Response;
using System;
using System.Threading.Tasks;

namespace PesquisaValidacaoCep.API.Shared.Service
{
    public class ConsultaCepService : HttpClientService, IConsultaCepService
    {
        public ConsultaCepResponse Response { get; set; }
        public ConsultaCepService()
        {
            Response = new ConsultaCepResponse();
        }

        public async Task ObterDadosCep(ConsultaCepRequest request)
        {
            try
            {
                Response = await GetAsync(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}