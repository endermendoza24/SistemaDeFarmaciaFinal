using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SIstemaFarmaciaFinal.Models
{
    [Table("detalle_Compras")]
    public partial class DetalleCompra
    {
        [Key]
        [Column("id_DetalleCompra")]
        public int IdDetalleCompra { get; set; }
        [Column("cantidad")]
        public double Cantidad { get; set; }
        [Column("precio")]
        public double Precio { get; set; }
        [Column("costo")]
        public double Costo { get; set; }
        [Column("descuento")]
        public double Descuento { get; set; }
        [Column("cod_Compras")]
        public int CodCompras { get; set; }

        [ForeignKey(nameof(CodCompras))]
        [InverseProperty(nameof(Compra.DetalleCompras))]
        public virtual Compra CodComprasNavigation { get; set; }
    }
}
