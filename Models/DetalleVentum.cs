using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SIstemaFarmaciaFinal.Models
{
    [Table("detalle_Venta")]
    public partial class DetalleVentum
    {
        [Key]
        [Column("cod_DetalleVenta")]
        public int CodDetalleVenta { get; set; }
        [Required]
        [Column("cliente")]
        [StringLength(50)]
        public string Cliente { get; set; }
        [Column("cantidad")]
        public int Cantidad { get; set; }
        [Column("precio")]
        public double Precio { get; set; }
        [Column("descuento")]
        public double Descuento { get; set; }
        [Column("cod_Ventas")]
        public int CodVentas { get; set; }

        [ForeignKey(nameof(CodVentas))]
        [InverseProperty(nameof(Venta.DetalleVenta))]
        public virtual Venta CodVentasNavigation { get; set; }
    }
}
