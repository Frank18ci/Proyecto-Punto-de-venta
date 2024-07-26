using ProyectoCompuX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoCompuX.Permisos
{
    public class ValidarSesionAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["empleado"] == null)
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }
            else
            {
                var empleado = filterContext.HttpContext.Session["empleado"] as EmpleadoDetalle;
                filterContext.Controller.ViewBag.Empleado = empleado;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}