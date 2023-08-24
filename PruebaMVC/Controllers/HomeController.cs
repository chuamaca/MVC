using PruebaMVC.Entidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace PruebaMVC.Controllers
{
    public class HomeController : Controller
    {

        Brand marca = new Brand();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //public ActionResult ListaMarcas(string nmbrand)
        //{
           

        //    ViewBag.MiLista = marca.Listar_Marcas(nmbrand);
            

        //    return RedirectToAction("Contact");

        //    //return View();
        //}

        public ActionResult Contact(string nmbrand)
        {
            var id=0;
            if (nmbrand.IsInt())
            {
               id = Convert.ToInt32(nmbrand);
            }

            ViewBag.MiLista = marca.Listar_Marcas(nmbrand, id);
            ViewBag.CurrentFilter = nmbrand;
            ViewBag.Message = "Your contact page.";

            return View();


        }

        public ActionResult Eliminar(int id)
        {
            var rtaResult = marca.QuitarMarcas(id);

            if (!rtaResult)
            {
                ViewBag.Message = "No se Pudo hacer la Accion Eliminar";
            }
              
            return RedirectToAction("Contact", rtaResult);

        }
    }
}