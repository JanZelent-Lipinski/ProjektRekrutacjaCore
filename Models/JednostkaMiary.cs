using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektRekrutacjaCore.Models
{
    [Table("JednostkiMiar", Schema = "ModelDanychContainer")]
    public class JednostkaMiary
    {
        [Key]
        public int Id { get; set; }

        public string? Nazwa { get; set; }
    }
}