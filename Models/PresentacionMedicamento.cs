using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SIstemaFarmaciaFinal.Models
{
    [Table("Presentacion_Medicamento")]
    public partial class PresentacionMedicamento
    {
        public PresentacionMedicamento()
        {
            Inventarios = new HashSet<Inventario>();
        }

        [Key]
        [Column("id_PresentacionMed")]
        public int IdPresentacionMed { get; set; }
        [Required]
        [Column("unidadEnvasado")]
        [StringLength(50)]
        public string UnidadEnvasado { get; set; }
        [Required]
        [Column("formaPresentacion")]
        [StringLength(50)]
        public string FormaPresentacion { get; set; }
        [Required]
        [Column("concentracion")]
        [StringLength(50)]
        public string Concentracion { get; set; }
        [Required]
        [Column("unidadMedidaPresentacion")]
        [StringLength(50)]
        public string UnidadMedidaPresentacion { get; set; }
        [Required]
        [Column("Unidades")]
        [StringLength(50)]        
        public string Unidades { get; set; }
        [Required]
        [Column("subUnidades")]
        [StringLength(50)]
        public string SubUnidades { get; set; }

        [InverseProperty(nameof(Inventario.IdPresentacionMedNavigation))]
        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
