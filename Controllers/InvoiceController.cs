using AutoMapper;
using invoease.Models;
using Microsoft.AspNetCore.Mvc;

namespace invoease.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IMapper _mapper;

        public InvoiceController(IMapper mapper, InvoeaseDbContext context)
        {
            _mapper = mapper;
        }


        // public ActionResult Index()
        // {
        //     var queryResult = _invoices.Where(i => i.Id == 1 && i.ClientId == 1).ToList();
        //     if (queryResult.Any())
        //     {
        //         var invList = _mapper.Map<List<InvoiceList>>(queryResult);
        //         var viewModel = new InvoiceListViewModel
        //         {
        //             invoices = invList
        //         };
        //         return View(viewModel);
        //     }
        //     return View();
        // }
        // public ActionResult Details(int id)
        // {
        //     var queryResult = _invoices.FirstOrDefault(i => i.Id == id);
        //     if (queryResult != null)
        //     {
        //         var viewModel = _mapper.Map<InvoiceViewModel>(queryResult);
        //         return View(viewModel);
        //     }
        //     return View();
        // }

        public ActionResult Create()
        {
            return View();
        }


    }
}
