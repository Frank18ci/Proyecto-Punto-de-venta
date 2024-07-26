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
    public class ProveedoresController : Controller
    {
        List<Proveedor> ListarProveedoresAll()
        {
            List<Proveedor> proovedors = new List<Proveedor>();
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec ListarProveedoresAll", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
                Proveedor proovedor = new Proveedor();
                proovedor.Id = reader.GetInt32(0);
                proovedor.Nombre = reader.GetString(1);
                proovedor.RUC = reader.GetString(2);
                proovedor.Direccion = reader.GetString(3);
                proovedor.FechaModificacion = reader.GetDateTime(4);
                proovedor.Estado = reader.GetBoolean(5);
                proovedors.Add(proovedor);
            }
            reader.Close();
            conn.Close();
            return proovedors;
        }
        List<Proveedor> ListarProveedoresBusqueda(string Nombre)
        {
            List<Proveedor> proovedors = new List<Proveedor>();
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec ListarProveedoresBusqueda @Nombre", conn);
            cmd.Parameters.AddWithValue("@Nombre", Nombre);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Proveedor proovedor = new Proveedor();
                proovedor.Id = reader.GetInt32(0);
                proovedor.Nombre = reader.GetString(1);
                proovedor.RUC = reader.GetString(2);
                proovedor.Direccion = reader.GetString(3);
                proovedor.FechaModificacion = reader.GetDateTime(4);
                proovedor.Estado = reader.GetBoolean(5);
                proovedors.Add(proovedor);
            }
            reader.Close();
            conn.Close();
            return proovedors;
        }
        [ValidarSesion]
        public ActionResult Index(string Nombre = "")
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                return View(ListarProveedoresBusqueda(Nombre));
            }
            ViewBag.mensaje = TempData["mensaje"];
            return View(ListarProveedoresAll());
        }
        [ValidarSesion]
        public ActionResult Create()
        {
            return View(new Proveedor());
        }
        int CrearProveedor(Proveedor proveedor)
        {
            int resultado = 0;
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec CrearProveedor @Nombre, @RUC, @Dirreccion, @Estado", conn);
            cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
            cmd.Parameters.AddWithValue("@RUC", proveedor.RUC);
            cmd.Parameters.AddWithValue("@Dirreccion", proveedor.Direccion);
            cmd.Parameters.AddWithValue("@Estado", proveedor.Estado);
            resultado = cmd.ExecuteNonQuery();
            conn.Close();
            return resultado;
        }
        [ValidarSesion]
        [HttpPost]
        public ActionResult Create(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return View(proveedor);
            }
            int resultado = CrearProveedor(proveedor);
            ViewBag.mensaje = "Proveedor ingresado: " + resultado;  
            return View(proveedor);
        }
        Proveedor BuscarProveedorId(int id) 
        {
            Proveedor proovedor = null;
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec BuscarProveedorId @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
                proovedor = new Proveedor();
                proovedor.Id = reader.GetInt32(0);
                proovedor.Nombre = reader.GetString(1);
                proovedor.RUC = reader.GetString(2);
                proovedor.Direccion = reader.GetString(3);
                proovedor.FechaModificacion = reader.GetDateTime(4);
                proovedor.Estado = reader.GetBoolean(5);
            }
            reader.Close();
            conn.Close();
            return proovedor;
        }
        [ValidarSesion]
        public ActionResult Details(int id)
        {
            Proveedor proveedor = BuscarProveedorId(id);
            return View(proveedor);
        }
        [ValidarSesion]
        public ActionResult Edit(int id)
        {
            Proveedor proveedor = BuscarProveedorId(id);
            return View(proveedor);
        }
        int EditarProveedor(Proveedor proveedor)
        {
            int resultado = 0;
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec EditarProveedor @Id, @Nombre, @RUC, @Dirreccion, @Estado", conn);
            cmd.Parameters.AddWithValue("@Id", proveedor.Id);
            cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
            cmd.Parameters.AddWithValue("@RUC", proveedor.RUC);
            cmd.Parameters.AddWithValue("@Dirreccion", proveedor.Direccion);
            cmd.Parameters.AddWithValue("@Estado", proveedor.Estado);
            resultado = cmd.ExecuteNonQuery();
            conn.Close();
            return resultado;
        }
        [ValidarSesion]
        [HttpPost]
        public ActionResult Edit(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return View(proveedor);
            }
            int resultado = EditarProveedor(proveedor);
            ViewBag.mensaje = "Proveedor editado: " + resultado;
            return View(proveedor);
        }
        [ValidarSesion]
        public ActionResult Delete(int id)
        {
            Proveedor proveedor = BuscarProveedorId(id);
            return View(proveedor);
        }
        int EliminarProveedorId(int id)
        {
            int resultado = 0;
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec EliminarProveedorId @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            resultado = cmd.ExecuteNonQuery();
            conn.Close();
            return resultado;
        }
        [ValidarSesion]
        [HttpPost]
        public ActionResult Delete(Proveedor proveedor)
        {
            int resultado = EliminarProveedorId(proveedor.Id);
            TempData["mensaje"] = "Proveedor eliminado: " + resultado;
            return RedirectToAction("Index");
        }


    }
}