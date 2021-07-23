using System.Text.RegularExpressions;

namespace PesquisaValidacaoCep.API.Shared.Requests
{
    public class ConsultaCepRequest : BaseRequest
    {
        public ConsultaCepRequest(string cep)
        {
            Cep = cep;
        }
        public string Cep { get; private set; }

        public bool Isvalid()
        {
 
            if(Cep.Length != 8 || !Regex.IsMatch(Cep, ("[0-9]{8}")))
            {
                ErrorMessage = "Cep Inválido.";
                return false;
            }
                
            return true;
        }
    }
}