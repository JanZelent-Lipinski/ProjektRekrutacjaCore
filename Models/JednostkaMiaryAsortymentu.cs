using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektRekrutacjaCore.Models
{
    [Table("JednostkiMiarAsortymentow", Schema = "ModelDanychContainer")]
    public class JednostkaMiaryAsortymentu
    {
        [Key]
        public int Id { get; set; }

        public int Asortyment_Id { get; set; }

        public int JednostkaMiary_Id { get; set; }
    }
}