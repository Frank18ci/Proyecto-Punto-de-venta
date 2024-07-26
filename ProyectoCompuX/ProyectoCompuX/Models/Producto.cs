using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCompuX.Models
{
    public class ProductoDetalle
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripccion { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Display(Name = "Fecha Entrada")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FechaEntrada { get; set; }
        [Required]
        public string NombreProveedor { get; set; }
        [Display(Name = "Fecha Mod.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FechaModificacion { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
    public class Producto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripccion { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Display(Name = "Fecha Entrada")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FechaEntrada { get; set; }
        [Required]
        [Display(Name = "Proveedor")]
        public int IdProveedor { get; set; }
        [Display(Name = "Fecha Mod.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FechaModificacion { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}