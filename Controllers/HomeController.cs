using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models;
namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        lib_dataEntities lib = new lib_dataEntities();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult History()
        {
            return View(lib.Books.Where(b => b.category=="History").ToList());
        }
        public ActionResult Programming()
        {
            return View(lib.Books.Where(b => b.category == "Programming").ToList());
        }
        public ActionResult Science()
        {
            return View(lib.Books.Where(b => b.category == "Science").ToList());
        }
        public ActionResult Islamic()
        {
            return View(lib.Books.Where(b => b.category == "Islamic").ToList());
        }
        public ActionResult English()
        {
            return View(lib.Books.Where(b => b.category == "English").ToList());
        }
        public ActionResult Urdu()
        {
            return View(lib.Books.Where(b => b.category == "Urdu").ToList());
        }
        public ActionResult Technology()
        {
            return View(lib.Books.Where(b => b.category == "Technology").ToList());
        }
        public ActionResult Literature()
        {
            return View(lib.Books.Where(b => b.category == "Literature").ToList());
        }

        public ActionResult Add()
        {
            return View("Add"); 
        }
        public ActionResult AddDone()
        {
            Book b = new Book();
            b.B_name = Request["bname"];
            b.author = Request["author"];
            b.category = Request["category"];
            b.status = Request["status"];
            lib.Books.Add(b);
            lib.SaveChanges();
            if (b.category == "History")
                return RedirectToAction("History");
            else if (b.category == "English")
                return RedirectToAction("English");
            else if (b.category == "Islamic")
                return RedirectToAction("Islamic");
            else if (b.category == "Literature")
                return RedirectToAction("Literature");
            else if (b.category == "Programming")
                return RedirectToAction("Programming");
            else if (b.category == "Science")
                return RedirectToAction("Science");
            else if (b.category == "Technology")
                return RedirectToAction("Technology");
            else if (b.category == "Urdu")
                return RedirectToAction("Urdu");
            return RedirectToAction("Index");
            
            
        }
        public ActionResult Edit(int id)
        {
            Book b = lib.Books.First(i => i.ISBN == id);
            return View(b);
        }
        public ActionResult EditDone(int id)
        {
            Book b = lib.Books.First(i => i.ISBN == id);
            b.B_name = Request["bname"];
            b.author = Request["author"];
            b.category = Request["category"];
            b.status = Request["status"];
            lib.SaveChanges();
            if(b.category=="History")
                return RedirectToAction("History");
            else if(b.category=="English")
                return RedirectToAction("English");
            else if(b.category=="Islamic")
                return RedirectToAction("Islamic");
            else if(b.category=="Literature")
                return RedirectToAction("Literature");
            else if(b.category=="Programming")
                return RedirectToAction("Programming");
            else if(b.category=="Science")
                return RedirectToAction("Science");
            else if(b.category=="Technology")
                return RedirectToAction("Technology");
            else if(b.category=="Urdu")
                return RedirectToAction("Urdu");
            return RedirectToAction("Index");
            
        }

        public ActionResult Delete(int id)
        {
            Book b = lib.Books.First(i => i.ISBN == id);
            lib.Books.Remove(b);
            lib.SaveChanges();
            return View("Index");
        }
        public ActionResult Borrow()
        {
            return View(lib.Books.Where(b => b.status == "Yes").ToList());
        }
        public ActionResult BorrowDone()
        {
            Member m = new Member();
            m.M_name = Request["name"];
            string id = Request["b_id"];
            m.B_id = Int32.Parse(id);
            Book b = lib.Books.First(i => i.ISBN == m.B_id);
            b.status = "No";
            lib.Members.Add(m);
            lib.SaveChanges();
            return RedirectToAction("Member");
        }
        public ActionResult AllBook()
        {
            return View(lib.Books.Select(b => b).ToList());
        }
        public ActionResult Member()
        {
            return View(lib.Members.Select(b=>b).ToList());
        }
        public ActionResult Deposit(int id)
        {
            Member m = lib.Members.First(i => i.M_id == id);
            Book b = lib.Books.First(i => i.ISBN == m.B_id);
            b.status = "Yes";
            lib.Members.Remove(m);
            lib.SaveChanges();
            return RedirectToAction("Member");
        }
    }
}
