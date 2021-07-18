using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SIstemaFarmaciaFinal.Models
{
    public partial class Venta
    {
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
        }

        [Key]
        [Column("cod_Ventas")]
        public int CodVentas { get; set; }
        [Column("fecha_Ventas", TypeName = "datetime")]
        public DateTime FechaVentas { get; set; }
        [Column("subtotal")]
        public double Subtotal { get; set; }
        [Column("iva")]
        public double Iva { get; set; }
        [Column("total")]
        public double Total { get; set; }
        [Column("id_Personal")]
        public int IdPersonal { get; set; }
        [Column("id_Inventario")]
        public int IdInventario { get; set; }

        [ForeignKey(nameof(IdInventario))]
        [InverseProperty(nameof(Inventario.Venta))]
        public virtual Inventario IdInventarioNavigation { get; set; }
        [ForeignKey(nameof(IdPersonal))]
        [InverseProperty(nameof(Personal.Venta))]
        public virtual Personal IdPersonalNavigation { get; set; }
        [InverseProperty(nameof(DetalleVentum.CodVentasNavigation))]
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
    }
}
