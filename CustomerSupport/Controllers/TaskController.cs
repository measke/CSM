using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomerSupport.Models;
using Microsoft.AspNetCore.Authentication;

namespace CustomerSupport.Controllers
{
    public class TaskController : Controller
    {
        //private readonly ILogger<TaskController> _logger;

        //public TaskController(ILogger<TaskController> logger)
        //{
        //    _logger = logger;
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // a collection of tickets to store all the tickets in
        public static List<Ticket> Tickets = new List<Ticket>()
        {
            new Ticket { Description = "Homme and alooooooooooooooooooooooooooooooooooooooooooooooong description", DueDate = new DateTime(2020, 6, 3, 1, 1, 1), Id = 1 },
            new Ticket { Description = "due in less than 1 hour", DueDate = new DateTime(2020, 6, 1, 22, 36, 1), Id = 2 },
            new Ticket { Description = "due in more than 1 hour", DueDate = new DateTime(2020, 6, 1, 23, 11, 4), Id = 3 },
            new Ticket { Description = "Eile", DueDate = new DateTime(2020, 5, 31), Id = 4 },
            new Ticket { Description = "Üleeile", DueDate = new DateTime(2020, 5, 30), Solved = true, Id = 5 }
        };

        // counter for ticket Ids
        public static int counter = 6;

        // main page - active tickets list and an entry form
        public ActionResult Index()
        {
            // create a new collection with only unsolved tickets
            var unsolved = Tickets.Where(x => x.Solved == false).ToList();

            // create a new collection ordered by duedate
            var ordered = unsolved.OrderBy(x => x.DueDate).ToList();

            //determine if duedate is already past or in the next hour
            foreach (Ticket ticket in ordered)
            {
                int res = DateTime.Compare(t1: DateTime.Now.AddHours(1),
                                           t2: ticket.DueDate);
                ticket.OverDue = res == 1;
            }

            return View(ordered);
        }

        // add a new ticket to Tickets collection from entry form
        [HttpPost]
        public ActionResult Add(string Desc_form, DateTime Due_form)
        {
            Tickets.Add(new Ticket
            {
                Id = counter,
                Description = Desc_form,
                DueDate = Due_form,
                EntryDate = DateTime.Now
            });
            counter++;
            return RedirectToAction("Index");
        }

        // Update the solved value when the checkbox is ticked
        public ActionResult Update(int id)
        {
            foreach(Ticket ticket in Tickets)
            {
                if (ticket.Id == id)
                {
                    ticket.Solved = true;
                }
            }
            return RedirectToAction("Index");
        }
    }

}
