using System.ComponentModel.DataAnnotations.Schema;

namespace LoginAspNetCoreMvcMySQL.Models
{
    [Table("usuarios")]
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Ativo { get; set; }
        public string Nivel { get; set; }
    }
}
