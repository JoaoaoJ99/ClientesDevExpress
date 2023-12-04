using System.ComponentModel.DataAnnotations;

namespace ClientesDevExpress.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        [Required(ErrorMessage = "Por favor preencha o nome.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor preencha o email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Por favor preencha o telefone.")]
        [Range(900000000, 999999999, ErrorMessage = "Por favor insira um número de telefone válido.")]
        public int Telefone { get; set; }
        public string TelefoneString { get; set; }

    }
}
