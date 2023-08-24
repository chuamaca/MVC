using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PruebaMVC.Utils
{
    public class Conexion
    {

        public static string conexionDB { get { return ConfigurationManager.ConnectionStrings["SQL_PE"].ConnectionString;  } }

        //public static string conexionDB { get { return (HttpContext.Current.Session["PAIS"].ToString() != "PE") ? ConfigurationManager.ConnectionStrings["SQL_PE"].ConnectionString : ConfigurationManager.ConnectionStrings["SQL_PE"].ConnectionString; } }
    }
}