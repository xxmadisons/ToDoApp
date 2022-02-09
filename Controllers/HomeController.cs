using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Controllers
{
    public class HomeController : Controller
    {
        private ToDoContext daContext { get; set; }

        // Constructor
        public HomeController(ToDoContext someName)
        {
            daContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ToDo()
        {
            ViewBag.Categories = daContext.Categories.ToList();
            return View("ToDoEntry");
        }

        [HttpPost]
        public IActionResult ToDo(ToDoResponse tdr)
        {
            if (ModelState.IsValid)
            {
                daContext.Add(tdr);
                daContext.SaveChanges();

                return View("Confirmation", tdr);
            }
            else // if invalid
            {
                ViewBag.Categories = daContext.Categories.ToList();
                return View("ToDoEntry");
            }
        }


        //[HttpGet]
        public IActionResult ToDoList()
        {
            var entries = daContext.Responses
                .Include(x => x.Category)
                .ToList();

            return View(entries);
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = daContext.Categories.ToList();

            var entry = daContext.Responses.Single(x => x.TaskID == taskid);

            return View("ToDoEntry", entry);
        }

        [HttpPost]
        public IActionResult Edit(ToDoResponse tdr)
        {
            daContext.Update(tdr);
            daContext.SaveChanges();

            return RedirectToAction("ToDoList");
        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var entry = daContext.Responses.Single(x => x.TaskID == taskid);

            return View(entry);
        }

        [HttpPost]
        public IActionResult Delete(ToDoResponse tdr)
        {
            daContext.Responses.Remove(tdr);
            daContext.SaveChanges();

            return RedirectToAction("ToDoList");
        }


    }
}
