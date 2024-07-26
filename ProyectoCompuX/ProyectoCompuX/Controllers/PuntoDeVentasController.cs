using ProyectoCompuX.Models;
using ProyectoCompuX.Permisos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web.Mvc;

namespace ProyectoCompuX.Controllers
{
    public class PuntoDeVentasController : Controller
    {
        List<RegistroVenta> registroVentas(DateTime FechaInicio, DateTime FechaFin)
        {
            List<RegistroVenta> registroVentas = new List<RegistroVenta>();
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec RegistroVentas @FechaInicio, @FechaFin", conn);
            cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
            cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                RegistroVenta registroVenta = new RegistroVenta();
                registroVenta.IdVenta = reader.GetInt32(0);
                registroVenta.Empleado = reader.GetString(1);
                registroVenta.Cliente = reader.GetString(2);
                registroVenta.Producto = reader.GetString(3);
                registroVenta.Precio = reader.GetSqlMoney(4).ToDouble();
                registroVenta.Cantidad = reader.GetInt32(5);
                registroVenta.Monto = reader.GetSqlMoney(6).ToDouble();
                registroVenta.FechaVenta = reader.GetDateTime(7);
                registroVentas.Add(registroVenta);
            }
            reader.Close();
            conn.Close();
            return registroVentas;
        }
        List<double> registroVentasMonto(DateTime FechaInicio, DateTime FechaFin)
        {
            List<double> registroVentas = new List<double>();
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec RegistroVentasMonto @FechaInicio, @FechaFin", conn);
            cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
            cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                double registroVenta = reader.GetSqlMoney(1).ToDouble();
                registroVentas.Add(registroVenta);
            }
            reader.Close();
            conn.Close();
            return registroVentas;
        }
        [ValidarSesion]
        public ActionResult RegistroVentas(DateTime? FechaInicio = null, DateTime? FechaFin = null)
        {
            DateTime fi = FechaInicio == null ? DateTime.Today.AddDays(-7) : (DateTime)FechaInicio;
            DateTime ff = FechaFin == null ? DateTime.Today : (DateTime)FechaFin;
            ViewBag.registroVentas = registroVentas(fi, ff);
            ViewBag.registroVentasMonto = registroVentasMonto(fi, ff);
            return View();
        }

        private static List<ProductoDetalle> carrito = new List<ProductoDetalle>();
        List<Cliente> ListarClientesAll()
        {
            SqlConnection conn = null;
            List<Cliente> clientes = new List<Cliente>();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec ListarClientesAll", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = reader.GetInt32(0);
                cliente.Nombres = reader.GetString(3) + " - " + reader.GetString(1) + " " + reader.GetString(2);
                cliente.Apellidos = reader.GetString(2);
                cliente.DNI = reader.GetString(3);
                cliente.Direccion = reader.GetString(4);
                cliente.FechaNacimiento = reader.GetDateTime(5);
                cliente.FechaModificacion = reader.GetDateTime(6);
                cliente.Estado = reader.GetBoolean(7);
                clientes.Add(cliente);
            }
            reader.Close();
            conn.Close();
            return clientes;
        }
        List<EmpleadoDetalle> ListarEmpleadosAll()
        {
            List<EmpleadoDetalle> empleados = new List<EmpleadoDetalle>();
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec ListarEmpleadosAll", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                EmpleadoDetalle empleado = new EmpleadoDetalle();
                empleado.Id = reader.GetInt32(0);
                empleado.Nombres = reader.GetString(3) + " - " + reader.GetString(1) + " " + reader.GetString(2);
                empleado.Apellidos = reader.GetString(2);
                empleado.DNI = reader.GetString(3);
                empleado.Direccion = reader.GetString(4);
                empleado.FechaNacimiento = reader.GetDateTime(5);
                empleado.Sueldo = reader.GetSqlMoney(6).ToDouble();
                empleado.FechaIngreso = reader.GetDateTime(7);
                empleado.Correo = reader.GetString(8);
                empleado.Clave = reader.GetString(9);
                empleado.TipoEmpleado = reader.GetString(10);
                empleado.FechaModificacion = reader.GetDateTime(11);
                empleado.Estado = reader.GetBoolean(12);
                empleados.Add(empleado);
            }
            reader.Close();
            conn.Close();
            return empleados;
        }
        List<ProductoDetalle> ListarProductosAll(string searchTerm = "")
        {
            List<ProductoDetalle> productos = new List<ProductoDetalle>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec ListarProductosAll", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ProductoDetalle producto = new ProductoDetalle();
                producto.Id = reader.GetInt32(0);
                producto.Nombre = reader.GetString(1);
                producto.Descripccion = reader.GetString(2);
                producto.Precio = reader.GetSqlMoney(3).ToDouble();
                producto.Cantidad = reader.GetInt32(4);
                producto.FechaEntrada = reader.GetDateTime(5);
                producto.NombreProveedor = reader.GetString(6);
                producto.FechaModificacion = reader.GetDateTime(7);
                producto.Estado = reader.GetBoolean(8);
                productos.Add(producto);
            }
            reader.Close();
            conn.Close();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                productos = productos.Where(p => p.Nombre.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            return productos;
        }
        [ValidarSesion]
        public ActionResult PuntoDeVenta(string searchTerm = "")
        {
            ViewBag.mensaje = TempData["mensaje"];
            ViewBag.SearchTerm = searchTerm;
            ViewBag.Productos = ListarProductosAll(searchTerm);
            ViewBag.Carrito = carrito;
            ViewBag.Total = carrito.Sum(x => x.Precio * x.Cantidad);
            Empleado empleado = Session["empleado"] as Empleado;
            if (empleado != null)
            {
                ViewBag.listaEmpleados = new SelectList(ListarEmpleadosAll(), "Id", "Nombres", empleado.Id);
            }
            else
            {
                ViewBag.listaEmpleados = new SelectList(ListarEmpleadosAll(), "Id", "Nombres");
            }
            ViewBag.listaClientes = new SelectList(ListarClientesAll(), "Id", "Nombres");
            

            return View();
        }
        [ValidarSesion]
        [HttpPost]
        public ActionResult AgregarAlCarrito(int id, int cantidad)
        {
            ProductoDetalle producto = ListarProductosAll().FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                var productoEnCarrito = carrito.FirstOrDefault(p => p.Id == id);
                if (productoEnCarrito != null)
                {
                    productoEnCarrito.Cantidad += cantidad;
                }
                else
                {
                    producto.Cantidad = cantidad;
                    carrito.Add(producto);
                }
            }
            return RedirectToAction("PuntoDeVenta");
        }
        [ValidarSesion]
        public ActionResult VaciarCarrito()
        {
            carrito.Clear();
            return RedirectToAction("PuntoDeVenta");
        }
        [ValidarSesion]
        [HttpPost]
        public ActionResult GuardarCompra(int IdCliente = -1, int IdEmpleado = -1)
        {
            String mensaje = "Mal";
            int IdVenta = 0;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            
            if(IdEmpleado != -1 && IdCliente != -1)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec CrearVenta @IdCliente, @IdEmpleado", conn);
                cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdCliente);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    IdVenta = Convert.ToInt32(value: r["Id"]);
                }
                r.Close();
                conn.Close();
            }
            if (IdVenta != 0)
            {
                conn.Open();

                foreach (var producto in carrito)
                {
                    SqlCommand cmd = new SqlCommand("exec CrearVentaDetalle @IdVenta, @IdProducto, @Cantidad", conn);
                    cmd.Parameters.AddWithValue("@IdVenta", IdVenta);
                    cmd.Parameters.AddWithValue("@IdProducto", producto.Id);
                    cmd.Parameters.AddWithValue("@Cantidad", producto.Cantidad);
                    cmd.ExecuteNonQuery();
                    
                }
                mensaje = "Compra realizada";
                conn.Close();
            }
            TempData["mensaje"]= mensaje;
            return RedirectToAction("PuntoDeVenta");
        }
    }
}