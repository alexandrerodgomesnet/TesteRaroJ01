using PesquisaValidacaoCep.API.Shared.Requests;
using PesquisaValidacaoCep.API.Shared.Response;
using System.Threading.Tasks;

namespace PesquisaValidacaoCep.API.Shared.Interfaces
{
    public interface IConsultaCepService
    {
        ConsultaCepResponse Response { get; set; }
        Task ObterDadosCep(ConsultaCepRequest request);
    }
}