using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibrary.Models;
using System.Data.SqlClient;

namespace MVCLibrary.Controllers
{
    public class BookController : Controller
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\bomba\documents\visual studio 2015\Projects\MVCLibrary\MVCLibrary\App_Data\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

        // GET: Book
        public ActionResult Index()
        {
            var entites = new Database1Entities();
            return View(entites.Books.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    sql.Open();
                    string query = "Insert into Books(CustomerID,IssueDate,ReturnDate,BookID) values(" + collection[1] + ",'" + collection[2] + "','" + collection[3] + "',"+collection[4]+")";
                    SqlCommand com = new SqlCommand(query, sql);
                    com.ExecuteNonQuery();
                    ViewBag.Message = "Data Inserted";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var entities = new Database1Entities();
            var cust = entities.Books.Where(a => a.Id == id).FirstOrDefault();
            return View(cust);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    sql.Open();
                    string query = "update Books set CustomerID=" + collection[2] + ",IssueDate='" + collection[3] + "',ReturnDate='" + collection[4] + "',BookID="+collection[5]+" where Id=" + id;
                    SqlCommand com = new SqlCommand(query, sql);
                    com.ExecuteNonQuery();
                    ViewBag.Message = "Data Updated";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var entities = new Database1Entities();
            var cust = entities.Books.Where(a => a.Id == id).FirstOrDefault();
            return View(cust);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    sql.Open();
                    string query = "delete from Books where Id=" + id;
                    SqlCommand com = new SqlCommand(query, sql);
                    com.ExecuteNonQuery();
                    ViewBag.Message = "Data Updated";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
