using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SIstemaFarmaciaFinal.Models
{
    [Table("Laboratorio")]
    public partial class Laboratorio
    {
        public Laboratorio()
        {
            Compras = new HashSet<Compra>();
            Inventarios = new HashSet<Inventario>();
        }

        [Key]
        [Column("id_laboratorio")]
        public int IdLaboratorio { get; set; }
        [Required]
        [Column("nombre_Laboratorio")]
        [StringLength(50)]
        public string NombreLaboratorio { get; set; }
        [Required]
        [Column("telefono_Laboratorio")]
        [StringLength(20)]
        public string TelefonoLaboratorio { get; set; }
        [Required]
        [Column("direccion")]
        [StringLength(50)]
        public string Direccion { get; set; }
        [Required]
        [Column("email_Lab")]
        [StringLength(50)]
        public string EmailLab { get; set; }
        [Required]
        [Column("politicasDeVencimiento")]
        [StringLength(300)]
        public string PoliticasDeVencimiento { get; set; }

        [InverseProperty(nameof(Compra.IdLaboratorioNavigation))]
        public virtual ICollection<Compra> Compras { get; set; }
        [InverseProperty(nameof(Inventario.IdLaboratorioNavigation))]
        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
