using System.ComponentModel.DataAnnotations.Schema;

namespace PesquisaValidacaoCep.API.Shared.Requests
{
    public class BaseRequest
    {
        [NotMapped]
        public string ErrorMessage { get; set; }
    }
}