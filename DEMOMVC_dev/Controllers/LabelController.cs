using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DEMO_dev.Service;

namespace DEMO_dev.Controllers
{
    public class LabelController : Controller
    {
        private readonly ILogger<LabelController> _logger;
        private readonly IMapper _mapper;
        private readonly LabelService _labelService;

        public LabelController(ILogger<LabelController> logger, IMapper mapper, LabelService labelService)
        {
            _logger = logger;
            _mapper = mapper;
            _labelService = labelService;
        }

        //Make it get all the labels from the user
        public async Task<IActionResult> Labels()
        {
            var labels = await _labelService.GetAll();
            return View(labels);
        }

        public async Task<IActionResult> YourLabels() 
        {
            var labels = await _labelService.GetAll();
            return View(labels);
        }
    }
}
