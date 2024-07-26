using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCompuX.Models
{
    public class RegistroVenta
    {
        public int IdVenta { get; set; }
        public string Empleado { get; set; }
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public double Monto { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FechaVenta { get; set; }
    }
}