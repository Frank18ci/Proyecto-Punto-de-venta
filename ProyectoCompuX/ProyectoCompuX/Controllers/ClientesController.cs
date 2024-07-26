using ProyectoCompuX.Models;
using ProyectoCompuX.Permisos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProyectoCompuX.Controllers
{
    public class ClientesController : Controller
    {
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
                cliente.Nombres = reader.GetString(1);
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
        List<Cliente> ListarClientesBusqueda(string Nombre)
        {
            SqlConnection conn = null;
            List<Cliente> clientes = new List<Cliente>();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec ListarClientesBusqueda @Nombre", conn);
            cmd.Parameters.AddWithValue("@Nombre", Nombre);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = reader.GetInt32(0);
                cliente.Nombres = reader.GetString(1);
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
        int CrearCliente(Cliente cliente)
        {
            int resultado = 0;
            SqlConnection sqlConnection = null;
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("exec CrearCliente @Nombres, @Apellidos, @DNI, @Dirreccion, @FechaNacimiento, @Estado", sqlConnection);
            cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
            cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
            cmd.Parameters.AddWithValue("@DNI", cliente.DNI);
            cmd.Parameters.AddWithValue("@Dirreccion", cliente.Direccion);
            cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
            resultado = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return resultado;
        }
        [ValidarSesion]
        public ActionResult Index(string Nombre = "")
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                return View(ListarClientesBusqueda(Nombre));
            }
            ViewBag.mensaje = TempData["mensaje"];
            return View(ListarClientesAll());
        }
        [ValidarSesion]
        public ActionResult Create()
        {
            return View(new Cliente());
        }
        [ValidarSesion]
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }
            int resultado = CrearCliente(cliente);
            ViewBag.mensaje = "Clientes agregados: " + resultado;
            return View(cliente);
        }
        Cliente BuscarClienteId(int id)
        {
            Cliente cliente = null;
            SqlConnection sqlConnection = null;
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("exec BuscarClienteId @Id", sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cliente = new Cliente();
                cliente.Id = reader.GetInt32(0);
                cliente.Nombres = reader.GetString(1);
                cliente.Apellidos = reader.GetString(2);
                cliente.DNI = reader.GetString(3);
                cliente.Direccion = reader.GetString(4);
                cliente.FechaNacimiento = reader.GetDateTime(5);
                cliente.FechaModificacion = reader.GetDateTime(6);
                cliente.Estado = reader.GetBoolean(7);
            }
            return cliente;
        }
        [ValidarSesion]
        public ActionResult Details(int id) 
        { 
            Cliente cliente = BuscarClienteId(id);
            return View(cliente);
        }
        [ValidarSesion]
        public ActionResult Edit(int id)
        {
            Cliente cliente = BuscarClienteId(id);
            return View(cliente);
        }
        int EditarCliente(Cliente cliente)
        {
            int resultado = 0;
            SqlConnection sqlConnection = null;
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("exec EditarCliente @Id, @Nombres, @Apellidos, @DNI, @Dirreccion, @FechaNacimiento, @Estado", sqlConnection);
            cmd.Parameters.AddWithValue("@Id", cliente.Id);
            cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
            cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
            cmd.Parameters.AddWithValue("@DNI", cliente.DNI);
            cmd.Parameters.AddWithValue("@Dirreccion", cliente.Direccion);
            cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
            resultado = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return resultado;
        }
        [ValidarSesion]
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }
            int resultado = EditarCliente(cliente);
            ViewBag.mensaje = "Clientes editados: " + resultado;
            return View(cliente);
        }
        [ValidarSesion]
        public ActionResult Delete(int id) 
        {
            Cliente cliente = BuscarClienteId(id);
            return View(cliente);
        }
        int EliminarClienteId(int id)
        {
            int resultado = 0;
            SqlConnection sqlConnection = null;
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("exec EliminarClienteId @Id", sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);
            resultado = cmd.ExecuteNonQuery();
            return resultado;
        }
        [ValidarSesion]
        [HttpPost]
        public ActionResult Delete(Cliente cliente)
        {
            int resultado = EliminarClienteId(cliente.Id);
            TempData["mensaje"] = "Cliente emliminado:" + resultado;
            return RedirectToAction("Index");
        }
    }
}