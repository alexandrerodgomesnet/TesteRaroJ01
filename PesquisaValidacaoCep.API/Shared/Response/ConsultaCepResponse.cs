using System;

namespace PesquisaValidacaoCep.API.Shared.Response
{
    public class ConsultaCepResponse : BaseResponse
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string DDD { get; set; }
        public string Siafi { get; set; }

        public bool IsValid()
        {
            if (ProcessOk && string.IsNullOrEmpty(Cep) && string.IsNullOrEmpty(Localidade))
            {
                ErrorMessage = $"Cep não encontrado.";
                return false;
            }                

            return true;
        }
    }
}