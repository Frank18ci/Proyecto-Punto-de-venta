using ProyectoCompuX.Models;
using ProyectoCompuX.Permisos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoCompuX.Controllers
{
    public class EmpleadosController : Controller
    {
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
                empleado.Nombres = reader.GetString(1);
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
        List<EmpleadoDetalle> ListarEmpleadosBusqueda(string Nombre)
        {
            List<EmpleadoDetalle> empleados = new List<EmpleadoDetalle>();
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec ListarEmpleadosBusqueda @Nombre", conn);
            cmd.Parameters.AddWithValue("@Nombre", Nombre);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                EmpleadoDetalle empleado = new EmpleadoDetalle();
                empleado.Id = reader.GetInt32(0);
                empleado.Nombres = reader.GetString(1);
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
        [ValidarSesion]
        public ActionResult Index(string Nombre = "")
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                return View(ListarEmpleadosBusqueda(Nombre));
            }
            ViewBag.mensaje = TempData["mensaje"];
            return View(ListarEmpleadosAll());
        }
        [ValidarSesion]
        public ActionResult Create()
        {
            ViewBag.tipoEmpleado = new SelectList(listaTipoEmpleado(), "Id", "Tipo");
            return View(new Empleado());
        }
        List<TipoEmpleado> listaTipoEmpleado()
        {
            List<TipoEmpleado> tipoEmpleados = new List<TipoEmpleado>();
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec ListarTiposEmpleadoAll", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                TipoEmpleado tipoEmpleado = new TipoEmpleado();
                tipoEmpleado.Id = reader.GetInt32(0);
                tipoEmpleado.Tipo = reader.GetString(1);
                tipoEmpleados.Add(tipoEmpleado);
            }
            reader.Close();
            conn.Close();
            return tipoEmpleados;   
        }
        int CrearEmpleado(Empleado empleado)
        {
            int resultado = 0;
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec CrearEmpleado @Nombres, @Apellidos, @DNI, @Dirreccion, @FechaNacimiento, @Sueldo, @FechaIngreso, @Correo, @Clave, @IdTipoEmpleado, @Estado", conn);
            cmd.Parameters.AddWithValue("@Nombres", empleado.Nombres);
            cmd.Parameters.AddWithValue("@Apellidos", empleado.Apellidos);
            cmd.Parameters.AddWithValue("@DNI", empleado.DNI);
            cmd.Parameters.AddWithValue("@Dirreccion", empleado.Direccion);
            cmd.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Sueldo", empleado.Sueldo);
            cmd.Parameters.AddWithValue("@FechaIngreso", empleado.FechaIngreso);
            cmd.Parameters.AddWithValue("@Correo", empleado.Correo);
            cmd.Parameters.AddWithValue("@Clave", empleado.Clave);
            cmd.Parameters.AddWithValue("@IdTipoEmpleado", empleado.IdTipoEmpleado);
            cmd.Parameters.AddWithValue("@Estado", empleado.Estado);
            resultado = cmd.ExecuteNonQuery();
            conn.Close();
            return resultado;
        }
        [ValidarSesion]
        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            ViewBag.tipoEmpleado = new SelectList(listaTipoEmpleado(), "Id", "Tipo", empleado.IdTipoEmpleado);
            if (!ModelState.IsValid)
            {
                return View(empleado);
            }
            int resultado = CrearEmpleado(empleado);
            ViewBag.mensaje = "Empleado creado: " + resultado;
            return View(empleado);
        }
        EmpleadoDetalle BuscarEmpleadoDId(int id)
        {
            EmpleadoDetalle empleadoDetalle = null;
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec BuscarEmpleadoDId @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                empleadoDetalle = new EmpleadoDetalle();
                empleadoDetalle.Id = reader.GetInt32(0);
                empleadoDetalle.Nombres = reader.GetString(1);
                empleadoDetalle.Apellidos = reader.GetString(2);
                empleadoDetalle.DNI = reader.GetString(3);
                empleadoDetalle.Direccion = reader.GetString(4);
                empleadoDetalle.FechaNacimiento = reader.GetDateTime(5);
                empleadoDetalle.Sueldo = reader.GetSqlMoney(6).ToDouble();
                empleadoDetalle.FechaIngreso = reader.GetDateTime(7);
                empleadoDetalle.Correo = reader.GetString(8);
                empleadoDetalle.Clave = reader.GetString(9);
                empleadoDetalle.TipoEmpleado = reader.GetString(10);
                empleadoDetalle.FechaModificacion = reader.GetDateTime(11);
                empleadoDetalle.Estado = reader.GetBoolean(12);
            }
            reader.Close();
            conn.Close();
            return empleadoDetalle;
        }
        [ValidarSesion]
        public ActionResult Details(int id) 
        {
            EmpleadoDetalle empleadoDetalle = BuscarEmpleadoDId(id);
            return View(empleadoDetalle);
        }
        Empleado BuscarEmpleadoId(int id)
        {
            Empleado empleado = null;
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec BuscarEmpleadoId @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                empleado = new Empleado();
                empleado.Id = reader.GetInt32(0);
                empleado.Nombres = reader.GetString(1);
                empleado.Apellidos = reader.GetString(2);
                empleado.DNI = reader.GetString(3);
                empleado.Direccion = reader.GetString(4);
                empleado.FechaNacimiento = reader.GetDateTime(5);
                empleado.Sueldo = reader.GetSqlMoney(6).ToDouble();
                empleado.FechaIngreso = reader.GetDateTime(7);
                empleado.Correo = reader.GetString(8);
                empleado.Clave = reader.GetString(9);
                empleado.IdTipoEmpleado = reader.GetInt32(10);
                empleado.FechaModificacion = reader.GetDateTime(11);
                empleado.Estado = reader.GetBoolean(12);
            }
            reader.Close();
            conn.Close();
            return empleado;
        }
        [ValidarSesion]
        public ActionResult Edit(int id)
        {
            Empleado empleado = BuscarEmpleadoId(id);
            ViewBag.tipoEmpleado = new SelectList(listaTipoEmpleado(), "Id", "Tipo", empleado.IdTipoEmpleado);
            return View(empleado);
        }
        int EditarEmpleado(Empleado empleado)
        {
            int resultado = 0;
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec EditarEmpleado @Id, @Nombres, @Apellidos, @DNI, @Dirreccion, @FechaNacimiento, @Sueldo, @FechaIngreso, @Correo, @Clave, @IdTipoEmpleado, @Estado", conn);
            cmd.Parameters.AddWithValue("@Id", empleado.Id);
            cmd.Parameters.AddWithValue("@Nombres", empleado.Nombres);
            cmd.Parameters.AddWithValue("@Apellidos", empleado.Apellidos);
            cmd.Parameters.AddWithValue("@DNI", empleado.DNI);
            cmd.Parameters.AddWithValue("@Dirreccion", empleado.Direccion);
            cmd.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Sueldo", empleado.Sueldo);
            cmd.Parameters.AddWithValue("@FechaIngreso", empleado.FechaIngreso);
            cmd.Parameters.AddWithValue("@Correo", empleado.Correo);
            cmd.Parameters.AddWithValue("@Clave", empleado.Clave);
            cmd.Parameters.AddWithValue("@IdTipoEmpleado", empleado.IdTipoEmpleado);
            cmd.Parameters.AddWithValue("@Estado", empleado.Estado);
            resultado = cmd.ExecuteNonQuery();
            conn.Close();
            return resultado;
        }
        [ValidarSesion]
        [HttpPost]
        public ActionResult Edit(Empleado empleado)
        {
            ViewBag.tipoEmpleado = new SelectList(listaTipoEmpleado(), "Id", "Tipo", empleado.IdTipoEmpleado);
            if (!ModelState.IsValid)
            {
                return View(empleado);
            }
            int resultado = EditarEmpleado(empleado);
            ViewBag.mensaje = "Empleado editado: " + resultado;

            return View(empleado);
        }
        [ValidarSesion]
        public ActionResult Delete(int id)
        {
            EmpleadoDetalle empleadoDetalle = BuscarEmpleadoDId(id);
            return View(empleadoDetalle);
        }
        int EliminarEmpleadoId(int id) 
        {
            int resultado = 0;
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec EliminarEmpleadoId @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            resultado = cmd.ExecuteNonQuery();
            conn.Close();
            return resultado;
        }
        [ValidarSesion]
        [HttpPost]
        public ActionResult Delete(EmpleadoDetalle empleadoDetalle)
        {
            int resultado = EliminarEmpleadoId(empleadoDetalle.Id);
            TempData["mensaje"] = "Empleado eliminado: " + resultado;
            return RedirectToAction("Index");
        }

    }
}