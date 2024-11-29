using AutoMapper;
using Crow.Models;
using Crow.Services;
using Crow.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Crow.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IClienteService _service;

        public ClienteController(IMapper mapper, IClienteService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new ClienteCreateViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(ClienteCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var cliente = _mapper.Map<ClienteModel>(viewModel);
                _service.CriarConta(cliente);

                TempData["messagemSucesso"] = $"O cliente {viewModel.Nome} for criado com sucesso";
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
