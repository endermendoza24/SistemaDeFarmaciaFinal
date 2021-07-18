using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SIstemaFarmaciaFinal.Models
{
    [Table("Categoria_Medicamento")]
    public partial class CategoriaMedicamento
    {
        public CategoriaMedicamento()
        {
            Medicamentos = new HashSet<Medicamento>();
        }

        [Key]
        [Column("id_Categoria")]
        public int IdCategoria { get; set; }
        [Required]
        [Column("nombre_Categoria")]
        [StringLength(50)]
        public string NombreCategoria { get; set; }
        [Required]
        [Column("descripcion_Categoria")]
        [StringLength(50)]
        public string DescripcionCategoria { get; set; }

        [InverseProperty(nameof(Medicamento.IdCategoriaNavigation))]
        public virtual ICollection<Medicamento> Medicamentos { get; set; }
    }
}
