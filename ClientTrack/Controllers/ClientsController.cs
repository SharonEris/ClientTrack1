using Microsoft.AspNetCore.Mvc;
using ClientTrack.DBL.Models;
using ClientTrack.DBL.Repositories;
using System.Threading.Tasks;
using ClientTrack.BL;

namespace ClientTrack.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ClientBL _clientBL;

        public ClientsController(ClientBL clientBL)
        {
            _clientBL = clientBL;
        }

        [HttpGet]
        public IActionResult CreateClient()
        {
            //ViewBag.Statuses = _clientBL.GetStatuses();
            ViewBag.Products = _clientBL.GetProducts();
            ViewBag.Countries = _clientBL.GetCountries();  


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientModel client)
        {
            if (ModelState.IsValid)
            {
                int clientId = await _clientBL.CreateClientAsync(client);

                TempData["SuccessMessage"] = "Client added successfully"; 
                return RedirectToAction("ListClient");
            }

            //ViewBag.Statuses = _clientBL.GetStatuses();
            ViewBag.Products = _clientBL.GetProducts();
            ViewBag.Countries = _clientBL.GetCountries(); 
            return View(client);
        }

        public async Task<IActionResult> ListClient()
        {
            var clients = await _clientBL.GetClientsAsync();
            return View(clients);
        }


        [HttpGet]
        public async Task<IActionResult> ManageClient(int id)
        {
            var client = await _clientBL.GetClientAsync(id);
            if (client == null)
            {
                return NotFound("Client not found.");
            }

            return View(client);
        }
    }










































































}
