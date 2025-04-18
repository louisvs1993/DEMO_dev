﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DEMO_dev.Service;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using SQLitePCL;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using DEMO_dev.ViewModels.Label;
using Microsoft.AspNetCore.Mvc.Rendering;
using DEMO_dev.Domain.Entities;

namespace DEMO_dev.Controllers
{
    public class LabelController : Controller
    {
        private readonly ILogger<LabelController> _logger;
        private readonly IMapper _mapper;
        private readonly LabelService _labelService;
        private readonly CountryService _countryService;

        public LabelController(ILogger<LabelController> logger, IMapper mapper, LabelService labelService, CountryService countryService)
        {
            _logger = logger;
            _mapper = mapper;
            _labelService = labelService;
            _countryService = countryService;
        }

        //Make it get all the labels from the user
        public async Task<IActionResult> Labels()
        {
            var labels = await _labelService.GetAll();
            return View(labels);
        }

        public async Task<IActionResult> YourLabels() 
        {
            var labels = await _labelService.GetAllByUser(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(labels);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var label = new LabelCreateEditVM();

            ViewBag.listCountry = new SelectList(await _countryService.GetAll(), "Id", "Name");
            

            return View(label);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LabelCreateEditVM labelVM)
        {
            if (ModelState.IsValid)
            {
                var label = _mapper.Map<Label>(labelVM);
                await _labelService.Add(label);

                return RedirectToAction(nameof(YourLabels));
            }
            return RedirectToAction(nameof(YourLabels));
        }
    }
}
