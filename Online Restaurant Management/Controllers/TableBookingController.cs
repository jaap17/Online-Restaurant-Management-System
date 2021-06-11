using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Models.Table;
using RestaurantManagementSystem.Models.TableBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Controllers
{
    public class TableBookingController:Controller
    {
        private readonly ITableBookingRepository _tableBooking;
        private readonly ITableRepository tableRepository;
        

        public TableBookingController(ITableBookingRepository tableBooking,ITableRepository tableRepository)
        {
            this._tableBooking = tableBooking;
            this.tableRepository = tableRepository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TableBooking tableBooking)
        {
            if(ModelState.IsValid)
            {
                TableBooking booking = _tableBooking.Create(tableBooking);
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult TableBookingQueries()
        {
            IEnumerable<TableBooking> tableBookings = _tableBooking.getTableBookings();
            return View("TableBookingQueries",tableBookings);
        }

        [HttpPost]
        public IActionResult AssignTable(string Email)
        {
           TableBooking tableBooking = _tableBooking.GetTableBookingbyEmail(Email);
            ViewBag.Email = tableBooking.Email;
            ViewBag.Capacity = tableBooking.Numberofpersons;
            ViewBag.ID = tableBooking.TableBookingId;
            int capacity = tableBooking.Numberofpersons;
            IEnumerable<Table> tables = tableRepository.VacantTables(capacity);
            
            return View("BookTable",tables);
        }

        public IActionResult FinalAssign(string Email,int tableid,int id)
        {
            Table table = tableRepository.GetTable(id);
            table.status = "Assigned";
            table.customerusername = Email;
            Table table1 = tableRepository.Update(table);
            _tableBooking.Delete(tableid);
            IEnumerable<Table> tables = tableRepository.Alltables();
            return View(tables);
        }

        public IActionResult TableStatus()
        {
            IEnumerable<Table> tables = tableRepository.Alltables();
            return View("FinalAssign",tables);
        }
    }
}
