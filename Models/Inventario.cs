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
        [Column("id_Inventario")]
        public int IdInventario { get; set; }
        [Column("fechaEntrada_Inventario", TypeName = "datetime")]
        public DateTime FechaEntradaInventario { get; set; }
        [Required]
        [Column("nombreComercial")]
        [StringLength(50)]
        public string NombreComercial { get; set; }
        [Column("Stock_Inicial")]
        public int StockInicial { get; set; }
        public int Entradas { get; set; }
        public int Salidas { get; set; }
        [Column("Stock_Actual")]
        public int StockActual { get; set; }
        [Column("Precio_Preventa")]
        public double PrecioPreventa { get; set; }
        [Column("Costo_Preventa")]
        public double CostoPreventa { get; set; }
        [Column("id_Presentacion_Med")]
        public int IdPresentacionMed { get; set; }
        [Column("id_Laboratorio")]
        public int IdLaboratorio { get; set; }
        [Column("id_Compra")]
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
    }
}
