using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibrary.Models;
using System.Data.SqlClient;

namespace MVCLibrary.Controllers
{
    public class CustomerController : Controller
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\bomba\documents\visual studio 2015\Projects\MVCLibrary\MVCLibrary\App_Data\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        // GET: Customer
        public ActionResult Index()
        {
            var entites = new Database1Entities();
            return View(entites.Customers.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    sql.Open();
                    string query = "Insert into Customer(Name,Phone,Email) values('" + collection[1] + "','" + collection[2] + "','" + collection[3] + "')";
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

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var entities = new Database1Entities();
            var cust = entities.Customers.Where(a => a.Id == id).FirstOrDefault();
            return View(cust);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    sql.Open();
                    string query = "update Customer set Name='"+collection[2]+"',Phone='"+collection[3]+"',Email='"+collection[4]+"' where Id="+id;
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var entities = new Database1Entities();
            var cust = entities.Customers.Where(a => a.Id == id).FirstOrDefault();
            return View(cust);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    sql.Open();
                    string query = "delete from Customer where Id=" + id;
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
