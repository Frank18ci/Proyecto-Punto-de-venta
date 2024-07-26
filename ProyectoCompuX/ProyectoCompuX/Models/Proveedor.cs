using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ProyectoCompuX.Models
{
    public class Proveedor
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string RUC { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Display(Name = "Fecha Mod.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FechaModificacion { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}