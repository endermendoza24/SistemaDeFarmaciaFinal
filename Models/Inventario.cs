using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SIstemaFarmaciaFinal.Models
{
    [Table("Inventario")]
    public partial class Inventario
    {
        public Inventario()
        {
            Medicamentos = new HashSet<Medicamento>();
            Venta = new HashSet<Venta>();
        }

        [Key]
        [Column("idInventario")]
        public DateTime IdInventario { get; set; }
        [Required]
        [Column("fechaEntradaInventario")]
        
        public string FechaEntradaInventario { get; set; }
        [Required]
        [Column("nombreComercial")]
        [StringLength(50)]
        public string NombreComercial { get; set; }
        [Column("StockInicial")]
        public int StockInicial { get; set; }
        [Column("Entradas")]
        public int Entradas { get; set; }
        [Column("Salidas")]
        public int Salidas { get; set; }
        [Column("StockActual")]
        public int StockActual { get; set; }
        [Column("PrecioPreventa")]
        public double PrecioPreventa { get; set; }
        [Column("CostoPreventa")]
        public double CostoPreventa { get; set; }
        [Column("idPresentacionMed")]
        public int IdPresentacionMed { get; set; }
        [Column("idLaboratorio")]
        public int IdLaboratorio { get; set; }
        [Column("idCompra")]
        public int IdCompra { get; set; }

        [ForeignKey(nameof(IdCompra))]
        [InverseProperty(nameof(Compra.Inventarios))]
        public virtual Compra IdCompraNavigation { get; set; }
        [ForeignKey(nameof(IdLaboratorio))]
        [InverseProperty(nameof(Laboratorio.Inventarios))]
        public virtual Laboratorio IdLaboratorioNavigation { get; set; }
        [ForeignKey(nameof(IdPresentacionMed))]
        [InverseProperty(nameof(PresentacionMedicamento.Inventarios))]
        public virtual PresentacionMedicamento IdPresentacionMedNavigation { get; set; }
        [InverseProperty(nameof(Medicamento.IdInventarioNavigation))]
        public virtual ICollection<Medicamento> Medicamentos { get; set; }
        [InverseProperty("IdInventarioNavigation")]
        public virtual ICollection<Venta> Venta { get; set; }

        //public static implicit operator Inventario(Inventario v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
