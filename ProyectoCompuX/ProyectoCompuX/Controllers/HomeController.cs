using ProyectoCompuX.Models;
using ProyectoCompuX.Permisos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ProyectoCompuX.Controllers
{
    public class HomeController : Controller
    {
        static double Ventas = 0;
        static double Productos = 0;
        static double Sueldo = 0;
        static int ClientesC = 0;
        static int ProductosC = 0;
        static int ProveedoresC = 0;
        static int EmpleadosC = 0;
        static int VentasC = 0;
        List<double> ObtenerDatos()
        {
            List<double> montos = new List<double>();
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec DashboardDatosVentas", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
                montos.Add(reader.GetSqlMoney(1).ToDouble());
            } 
            reader.Close();
            conn.Close();
            return montos;
        }
        void ObtenerDatosSuma()
        {
            List<double> montos = new List<double>();
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec DashboardDatosSuma", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Ventas =reader.GetSqlMoney(0).ToDouble();
                Sueldo = reader.GetSqlMoney(1).ToDouble();
                Productos = reader.GetSqlMoney(2).ToDouble();
            }
            reader.Close();
            conn.Close();
        }
        void ObtenerDatosCantidad()
        {
            List<double> montos = new List<double>();
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec DashboardDatosCantidad", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ClientesC = reader.GetInt32(0);
                ProductosC = reader.GetInt32(1);
                ProveedoresC = reader.GetInt32(2);
                EmpleadosC = reader.GetInt32(3);
                VentasC = reader.GetInt32(4);
            }
            reader.Close();
            conn.Close();
        }
        [ValidarSesion]
        public ActionResult Index()
        {
            ObtenerDatosCantidad();
            ViewBag.ClientesC = ClientesC;
            ViewBag.ProductosC = ProductosC;
            ViewBag.ProveedoresC = ProveedoresC;
            ViewBag.EmpleadosC = EmpleadosC;
            ViewBag.VentasC = VentasC;
            ObtenerDatosSuma();
            List<double> montos2 = new List<double>();
            montos2.Add(Ventas);
            montos2.Add(Productos);
            montos2.Add(Sueldo);
            ViewBag.montos = ObtenerDatos();
            ViewBag.montos2 = montos2;
            return View();
        }
    }
}