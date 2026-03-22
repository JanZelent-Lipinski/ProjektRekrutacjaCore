using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektRekrutacjaCore.Models
{
    [Table("Waluty", Schema = "ModelDanychContainer")]
    public class Waluta
    {
        [Key]
        public Guid Id { get; set; }

        public string? Symbol { get; set; }

        public string? Nazwa { get; set; }
    }
}