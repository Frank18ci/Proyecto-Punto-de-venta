using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoCompuX.Models;
using System.Data;


namespace ProyectoCompuX.Controllers
{   

    public class AccesoController : Controller
    {
        // GET: Acceso
        
        public ActionResult Login()
        {
            return View();
        }
        EmpleadoDetalle LoginEmpleado(string Correo, string Clave)
        {
            EmpleadoDetalle empleado = null;
            SqlConnection con = null;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("exec sp_LoginEmpleado @Correo, @Clave", con);
            cmd.Parameters.AddWithValue("@Correo", Correo);
            cmd.Parameters.AddWithValue("@Clave", Clave);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                empleado = new EmpleadoDetalle();
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
            }
            reader.Close();
            con.Close();
            return empleado;
        }
        // POST: Acceso
        [HttpPost]public ActionResult Login(string Correo, string Clave)
        {
            EmpleadoDetalle emp = LoginEmpleado(Correo, Clave);
            if (emp != null)
            {
                Session["empleado"] = emp;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.mensaje = "Empleado no encontrado";
                return View();
            }


        }
        public ActionResult CerrarSesion()
        {
            Session["empleado"] = null;
            return RedirectToAction("Login", "Acceso");
        }

        

    }
}