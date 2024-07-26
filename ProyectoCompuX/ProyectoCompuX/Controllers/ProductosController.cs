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
    public class ProductosController : Controller
    {
        List<ProductoDetalle> ListarProductosAll()
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
            return productos;
        }
        List<ProductoDetalle> ListarProductosBusqueda(string Nombre)
        {
            List<ProductoDetalle> productos = new List<ProductoDetalle>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec ListarProductosBusqueda @Nombre", conn);
            cmd.Parameters.AddWithValue("@Nombre", Nombre);
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
            return productos;
        }
        [ValidarSesion]
        public ActionResult Index(string Nombre = "")
        {
            if (!string.IsNullOrEmpty(Nombre)) 
            {
                return View(ListarProductosBusqueda(Nombre));
            }
            ViewBag.mensaje = TempData["mensaje"];
            return View(ListarProductosAll());
        }

        ProductoDetalle buscarProductoDId(int id)
        {
            ProductoDetalle producto = null;
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec buscarProductoDId @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                producto = new ProductoDetalle();
                producto.Id = reader.GetInt32(0);
                producto.Nombre = reader.GetString(1);
                producto.Descripccion = reader.GetString(2);
                producto.Precio = reader.GetSqlMoney(3).ToDouble();
                producto.Cantidad = reader.GetInt32(4);
                producto.FechaEntrada = reader.GetDateTime(5);
                producto.NombreProveedor = reader.GetString(6);
                producto.FechaModificacion = reader.GetDateTime(7);
                producto.Estado = reader.GetBoolean(8);
            }
            reader.Close();
            conn.Close();
            return producto;
        }
        Producto buscarProductoId(int id)
        {
            Producto producto = null;
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec buscarProductoId @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                producto = new Producto();
                producto.Id = reader.GetInt32(0);
                producto.Nombre = reader.GetString(1);
                producto.Descripccion = reader.GetString(2);
                producto.Precio = reader.GetSqlMoney(3).ToDouble();
                producto.Cantidad = reader.GetInt32(4);
                producto.FechaEntrada = reader.GetDateTime(5);
                producto.IdProveedor = reader.GetInt32(6);
                producto.FechaModificacion = reader.GetDateTime(7);
                producto.Estado = reader.GetBoolean(8);
            }
            reader.Close();
            conn.Close();
            return producto;
        }
        int CrearProducto(Producto producto)
        {
            int resultado = 0;
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec CrearProducto @Nombre, @Descripcion, @Precio, @Cantidad, @IdProveedores, @Estado", conn);
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", producto.Descripccion);
            cmd.Parameters.AddWithValue("@Precio", producto.Precio);
            cmd.Parameters.AddWithValue("@Cantidad", producto.Cantidad);
            cmd.Parameters.AddWithValue("@IdProveedores", producto.IdProveedor);
            cmd.Parameters.AddWithValue("@Estado", producto.Estado);
            resultado = cmd.ExecuteNonQuery();
            conn.Close();
            return resultado;
        }

        //METODO DE BUSQUEDA POR IDPROVEEDOR
        public List<Proveedor> ListarProveedoresAll()
        {
            List<Proveedor> proveedors = new List<Proveedor>();
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
                proveedors.Add(proovedor);
            }
            reader.Close();
            conn.Close();
            return proveedors;
        }
        [ValidarSesion]
        public ActionResult Create()
        {
            ViewBag.listaProveedores = new SelectList(ListarProveedoresAll(), "Id", "Nombre");
            return View(new Producto());
        }
        [ValidarSesion]
        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            ViewBag.listaProveedores = new SelectList(ListarProveedoresAll(), "Id", "Nombre", producto.IdProveedor);
            if (!ModelState.IsValid)
            {
                return View(producto);
            }
            int resultado = CrearProducto(producto);
            ViewBag.mensaje = resultado + "Producto agregado: " + resultado;
            return View(producto);
        }
        [ValidarSesion]
        public ActionResult Details(int id)
        {
            ProductoDetalle producto = buscarProductoDId(id);
            return View(producto);
        }
        int EditarProducto(Producto producto)
        {
            int resultado = 0;
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec EditarProducto @Id, @Nombre, @Descripcion, @Precio, @Cantidad, @IdProveedores, @Estado", conn);
            cmd.Parameters.AddWithValue("@Id", producto.Id);
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", producto.Descripccion);
            cmd.Parameters.AddWithValue("@Precio", producto.Precio);
            cmd.Parameters.AddWithValue("@Cantidad", producto.Cantidad);
            cmd.Parameters.AddWithValue("@IdProveedores", producto.IdProveedor);
            cmd.Parameters.AddWithValue("@Estado", producto.Estado);
            resultado = cmd.ExecuteNonQuery();
            conn.Close();
            return resultado;
        }
        [ValidarSesion]
        public ActionResult Edit(int id)
        {
            Producto producto = buscarProductoId(id);
            ViewBag.listaProveedores = new SelectList(ListarProveedoresAll(), "Id", "Nombre", producto.IdProveedor);
            return View(producto);
        }
        [ValidarSesion]
        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            ViewBag.listaProveedores = new SelectList(ListarProveedoresAll(), "Id", "Nombre", producto.IdProveedor);
            if (!ModelState.IsValid)
            {
                return View(producto);
            }
            int resultado = EditarProducto(producto);
            ViewBag.mensaje = resultado + "Producto editado: " + resultado;
            return View(producto);
        }
        int EliminarProductoId(int id)
        {
            int resultado = 0;
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec EliminarProductoId @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            resultado = cmd.ExecuteNonQuery();
            conn.Close();
            return resultado;
        }
        [ValidarSesion]
        public ActionResult Delete(int id)
        {
            ProductoDetalle producto = buscarProductoDId(id);
            return View(producto);
        }
        [ValidarSesion]
        [HttpPost]
        public ActionResult Delete(ProductoDetalle producto)
        {
            int resultado = EliminarProductoId(producto.Id);
            TempData["mensaje"] = "Producto eliminado: " + resultado;
            return RedirectToAction("Index");
            
        }
    }
}