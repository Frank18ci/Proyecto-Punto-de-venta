using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCompuX.Models
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int IdVentas { get; set; }
        public int IdProductos { get; set; }
        public int Cantidad { get; set; }
        public double Monto { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FechaModificacion { get; set; }
        public bool Estado { get; set; }
    }
}