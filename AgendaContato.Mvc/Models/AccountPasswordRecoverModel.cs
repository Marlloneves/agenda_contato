using System.ComponentModel.DataAnnotations;

namespace AgendaContato.Mvc.Models
{
    public class AccountPasswordRecoverModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de e-mail válido")]
        [Required(ErrorMessage = "Por favor, informe seu email.")]
        public string Email { get; set; }
    }
}
