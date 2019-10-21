using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using MVCLibrary.Models;

namespace MVCLibrary.Controllers
{
    public class ComputerController : Controller
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\bomba\documents\visual studio 2015\Projects\MVCLibrary\MVCLibrary\App_Data\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        // GET: Computer
        public ActionResult Index()
        {

            var entites = new Database1Entities();
            return View(entites.Computers.ToList());
        }

        // GET: Computer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Computer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Computer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    sql.Open();
                    string query = "Insert into Computer(CustomerID,ComputerID,Time) values(" + collection[1] + "," + collection[2] + "," + collection[3] + ")";
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

        // GET: Computer/Edit/5
        public ActionResult Edit(int id)
        {
            var entities = new Database1Entities();
            var cust = entities.Computers.Where(a => a.Id == id).FirstOrDefault();
            return View(cust);
        }

        // POST: Computer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    sql.Open();
                    string query = "update Computer set CustomerID=" + collection[2] + ",ComputerID=" + collection[3] + ",Time=" + collection[4] + " where Id=" + id;
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

        // GET: Computer/Delete/5
        public ActionResult Delete(int id)
        {
            var entities = new Database1Entities();
            var cust = entities.Computers.Where(a => a.Id == id).FirstOrDefault();
            return View(cust);
        }

        // POST: Computer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    sql.Open();
                    string query = "delete from Computer where Id=" + id;
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
