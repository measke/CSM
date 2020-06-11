using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CustomerSupport.Models;

namespace CustomerSupport.Controllers
{
    public class TicketController : Controller
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
        public static readonly List<Ticket> Tickets = new List<Ticket>();

        // counter for ticket Ids
        public static int counter = 1;

        // main page - active tickets list and an entry form
        public ActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel();

            viewModel.Unsolved = Tickets
                .Where(x => !x.Solved)
                .OrderBy(x => x.DueDate).ToList();

            viewModel.Solved = Tickets
                .Where(x => x.Solved)
                .OrderBy(x => x.SolvedDate).ToList();

            return View(viewModel);
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
            var ticket = Tickets.Single(t => t.Id == id);
            ticket.Solve();

            return RedirectToAction("Index");
        }
    }

}
