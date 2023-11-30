using System.ComponentModel.DataAnnotations;

namespace ClientesDevExpress.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        [Required]
        public string Nome { get; set; } = "Nome";
        [Required]
        public string Email { get; set; } = "Email";
        [Required]
        [Range(900000000, 999999999)]
        public string Telefone { get; set; } = "999999999";

    }
}
