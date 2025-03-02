using AutoMapper;
using invoease.Models;
using Microsoft.AspNetCore.Mvc;

namespace invoease.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IMapper _mapper;

        private static List<Client> _clients = new List<Client>(){
            new Client{
                Id = 1,
                Name = "RunDNA",
                AdminEmail = "accounts@rundna.com.au",
                ContactPersonName = "Adele",
                PhoneNumber = "0486489789"
            }
        };
        private static List<Invoice> _invoices = new List<Invoice>()
{
    new Invoice
    {
        Id = 1,
        ClientId = 1,
        UserId = 501,
        InvoiceNumber = "INV-0001",
        Description = "Web Development Services",
        IssueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-10)),
        IsScheduled = false,
        ScheduledSendDate = DateTime.Now.AddDays(30),
        EmailDescription = "This is a description for the email.",
        DueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(30)),
        Items = new List<InvoiceItem>
        {
            new InvoiceItem
            {
                Id = 1,
                InvoiceId = 1,
                Description = "Design Work",
                ItemPrice = 100.0m,
                Quantity = 10,
                Cancelled = false,
                IsMiscellaneous = false,
                ItemTotal = 1000.0m,
                IsRecurring = false,
                WorkDays = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Wednesday }
            },
            new InvoiceItem
            {
                Id = 2,
                InvoiceId = 1,
                Description = "Development Work",
                ItemPrice = 150.0m,
                Quantity = 15,
                Cancelled = false,
                IsMiscellaneous = false,
                ItemTotal = 2250.0m,
                IsRecurring = false,
                WorkDays = new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Thursday }
            }
        },
        IsDraft = false,
        Sent = true,
        TotalExcGST = 3250.0m,
        TotalIncGST = 3575.0m,
        IsPaid = false,
        IsRecurring = false
    },
    new Invoice
    {
        Id = 2,
        ClientId = 1,
        UserId = 502,
        InvoiceNumber = "INV-0002",
        Description = "Consulting Services",
        IssueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)),
        IsScheduled = false,
        ScheduledSendDate = null,
        EmailDescription = "This is another email description.",
        DueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(20)),
        Items = new List<InvoiceItem>
        {
            new InvoiceItem
            {
                Id = 3,
                InvoiceId = 2,
                Description = "Consulting Session",
                ItemPrice = 200.0m,
                Quantity = 5,
                Cancelled = false,
                IsMiscellaneous = true,
                ItemTotal = 1000.0m,
                IsRecurring = true,
                WorkDays = new List<DayOfWeek> { DayOfWeek.Friday }
            }
        },
        IsDraft = false,
        Sent = false,
        TotalExcGST = 1000.0m,
        TotalIncGST = 1100.0m,
        IsPaid = true,
        IsRecurring = true
    },
    new Invoice
    {
        Id = 3,
        ClientId = 1,
        UserId = 503,
        InvoiceNumber = "INV-0003",
        Description = "Software License",
        IssueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-20)),
        IsScheduled = false,
        ScheduledSendDate = null,
        EmailDescription = "This email describes the invoice.",
        DueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(40)),
        Items = new List<InvoiceItem>
        {
            new InvoiceItem
            {
                Id = 4,
                InvoiceId = 3,
                Description = "Software License Fee",
                ItemPrice = 500.0m,
                Quantity = 1,
                Cancelled = false,
                IsMiscellaneous = false,
                ItemTotal = 500.0m,
                IsRecurring = false,
                WorkDays = new List<DayOfWeek> { DayOfWeek.Monday }
            }
        },
        IsDraft = true,
        Sent = false,
        TotalExcGST = 500.0m,
        TotalIncGST = 550.0m,
        IsPaid = false,
        IsRecurring = false
    }
};
        public InvoiceController(IMapper mapper)
        {
            _mapper = mapper;
        }


        public ActionResult Index()
        {
            var queryResult = _invoices.Where(i => i.Id == 1 && i.ClientId == 1).ToList();
            if (queryResult.Any())
            {
                var invList = _mapper.Map<List<InvoiceList>>(queryResult);
                var viewModel = new InvoiceListViewModel
                {
                    invoices = invList
                };
                return View(viewModel);
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            var queryResult = _invoices.FirstOrDefault(i => i.Id == id);
            if (queryResult != null)
            {
                var viewModel = _mapper.Map<InvoiceViewModel>(queryResult);
                return View(viewModel);
            }
            return View();
        }


    }
}
