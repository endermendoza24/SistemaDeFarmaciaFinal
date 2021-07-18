using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SIstemaFarmaciaFinal.Models
{
    public partial class Medicamento
    {
        [Key]
        [Column("cod_Medicamentos")]
        public int CodMedicamentos { get; set; }
        [Required]
        [Column("nombreGenerico")]
        [StringLength(50)]
        public string NombreGenerico { get; set; }
        [Required]
        [Column("estado")]
        [StringLength(50)]
        public string Estado { get; set; }
        [Required]
        [Column("viaAdministracion")]
        [StringLength(50)]
        public string ViaAdministracion { get; set; }
        [Column("id_Categoria")]
        public int IdCategoria { get; set; }
        [Column("id_Inventario")]
        public int IdInventario { get; set; }

        [ForeignKey(nameof(IdCategoria))]
        [InverseProperty(nameof(CategoriaMedicamento.Medicamentos))]
        public virtual CategoriaMedicamento IdCategoriaNavigation { get; set; }
        [ForeignKey(nameof(IdInventario))]
        [InverseProperty(nameof(Inventario.Medicamentos))]
        public virtual Inventario IdInventarioNavigation { get; set; }
    }
}
