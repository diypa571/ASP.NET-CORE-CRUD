using Djupvikv01.Controllers;
using Djupvikv01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Dynamic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Web;
 

namespace Djupvikv01.Controllers
{
    public class PanelController : Controller
    {
       
 


        /*
        public IActionResult Index()
        {
            List<PanelModel> articles = new List<PanelModel>();
            PanelDataObject artikelobj = new PanelDataObject();
            articles = artikelobj.hamta();
            return View("Index", articles);
        }
        */
        public IActionResult Index()
        { 
            ArticleData artikelobj = new ArticleData();
            UsersData userslist = new UsersData();
            ArticletypData artyplist = new ArticletypData();
            dynamic dy = new ExpandoObject();
            dy.artikelobj = artikelobj.hamta();
            dy.userslist = userslist.hamtaUsers();
            dy.artyplist = artyplist.hamtaArtikeltyp();
            //    dy.listType = getArtType();
            // dy.listUser = getUser();


            return View(dy);

        }


      

        public ActionResult Details(int id)
        {
            ArticleData articles = new ArticleData();
            ArticleModel article = articles.hamtaDetail(id);
            return View("Details", article);
        }



   


        public ActionResult Create(int id)
        {
            ArticleData articles = new ArticleData();
            ArticleModel article = articles.hamtaDetail(id);
            return View("AddForm", article);

        }

        public ActionResult Picker()
        {
 
            return View("Picker");

        }


 
     
        public ActionResult Edit(int id)
        {
            ArticleData articles = new ArticleData();
            ArticleModel article = articles.hamtaDetail(id);
            return View("AddForm", article);

        }


        public ActionResult ProcessCreate(ArticleModel panelModel)
        {
            ArticleData dataObject = new ArticleData();
            dataObject.CreateOrUpdate(panelModel);
            return View("Details", panelModel);
        }






        public ActionResult Delete(int id)
        {
            ArticleData articles = new ArticleData();
            articles.Delete(id);
            //List<ArticleModel> article = articles.hamta();
            return View("Action");

        }
         

        public ActionResult Action()
        {
            return View("Action");

        }

      

        public ActionResult Search(string keyword)
        {

            ArticleData artikelobj = new ArticleData();
            UsersData userslist = new UsersData();

            dynamic sr = new ExpandoObject();
            sr.artikelobj = artikelobj.Find(keyword);
 
            return View(sr);

        }




        public ActionResult Fil(string author)
        {

            ArticleData artikelobj = new ArticleData();
            UsersData userslist = new UsersData();

            dynamic filt = new ExpandoObject();
            filt.artikelobj = artikelobj.Fil(author);

            return View(filt);

        }




        public ActionResult Sorting(string sort)
        {

            ArticleData artikelobj = new ArticleData();
            UsersData userslist = new UsersData();

            dynamic filt = new ExpandoObject();
            filt.artikelobj = artikelobj.Sorting(sort);

            return View(filt);

        }







    }
}
 