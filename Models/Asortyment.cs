using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektRekrutacjaCore.Models
{
    [Table("Asortymenty", Schema = "ModelDanychContainer")]
    public class Asortyment
    {
        [Key]
        public int Id { get; set; }

        public string? Nazwa { get; set; }

        public decimal? CenaEwidencyjna { get; set; }

        public Guid? WalutaCenyEwidencyjnej_Id { get; set; }
    }
}