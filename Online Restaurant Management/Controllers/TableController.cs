using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Controllers
{
    public class TableController:Controller
    {
        private readonly ITableRepository _tablectx;
        public TableController(ITableRepository tablecontext)
        {
            _tablectx = tablecontext;
        }

        public IActionResult Index()
        {
            IEnumerable<Table> tables = _tablectx.Alltables();
            return View(tables);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Table table)
        {
            if(ModelState.IsValid)
            {
                Table table1 = _tablectx.Add(table);
                IEnumerable<Table> tables = _tablectx.Alltables();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Table table = _tablectx.GetTable(id);
            if(table == null)
            {
                return NotFound();
            }
            return View(table);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = _tablectx.GetTable(id);
            if (table == null)
            {
                return NotFound();
            }

            return View(table);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            _tablectx.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Table table = _tablectx.GetTable(id);
            if(table == null)
            {
                return View("Error");
            }

            return View(table);
        }

        [HttpPost]
        public IActionResult Edit(Table table)
        {
            if (table != null)
            {
                Table table1 = _tablectx.Update(table);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
