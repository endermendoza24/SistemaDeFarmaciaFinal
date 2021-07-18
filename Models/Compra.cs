using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SIstemaFarmaciaFinal.Models
{
    public partial class Compra
    {
        public Compra()
        {
            DetalleCompras = new HashSet<DetalleCompra>();
            Inventarios = new HashSet<Inventario>();
        }

        [Key]
        [Column("cod_Compras")]
        public int CodCompras { get; set; }
        [Column("fecha_Compra", TypeName = "datetime")]
        public DateTime FechaCompra { get; set; }
        public double Iva { get; set; }
        [Column("subtotal")]
        public double Subtotal { get; set; }
        [Column("total")]
        public double Total { get; set; }
        [Column("Id_Laboratorio")]
        public int IdLaboratorio { get; set; }
        [Column("Id_Personal")]
        public int IdPersonal { get; set; }

        [ForeignKey(nameof(IdLaboratorio))]
        [InverseProperty(nameof(Laboratorio.Compras))]
        public virtual Laboratorio IdLaboratorioNavigation { get; set; }
        [ForeignKey(nameof(IdPersonal))]
        [InverseProperty(nameof(Personal.Compras))]
        public virtual Personal IdPersonalNavigation { get; set; }
        [InverseProperty(nameof(DetalleCompra.CodComprasNavigation))]
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
        [InverseProperty(nameof(Inventario.IdCompraNavigation))]
        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
