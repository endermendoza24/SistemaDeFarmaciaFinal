using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SIstemaFarmaciaFinal.Models
{
    [Table("Personal")]
    public partial class Personal
    {
        public Personal()
        {
            Compras = new HashSet<Compra>();
            Venta = new HashSet<Venta>();
        }

        [Key]
        [Column("id_Personal")]
        public int IdPersonal { get; set; }
        [Required]
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Column("primerApellido")]
        [StringLength(50)]
        public string PrimerApellido { get; set; }
        [Column("segundoApellido")]
        [StringLength(50)]
        public string SegundoApellido { get; set; }
        [Required]
        [Column("direccion")]
        [StringLength(50)]
        public string Direccion { get; set; }
        [Required]
        [Column("telefono")]
        [StringLength(20)]
        public string Telefono { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }

        [InverseProperty(nameof(Compra.IdPersonalNavigation))]
        public virtual ICollection<Compra> Compras { get; set; }
        [InverseProperty("IdPersonalNavigation")]
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
