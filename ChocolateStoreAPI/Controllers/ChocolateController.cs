using ChocolateStoreAPI.DataFile;
using ChocolateStoreAPI.Models;
using ChocolateStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChocolateStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChocolateController : ControllerBase
    {
        private readonly IChocolateService _chocolateService;

        public ChocolateController(IChocolateService chocolateService)
        {
            this._chocolateService = chocolateService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _chocolateService.Get();
                return Ok(_chocolateService.Get());
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetMobile")]
        public IActionResult Get(int id)
        {
            try
            {
                _chocolateService.GetByID(id);
                return Ok(_chocolateService.Get());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Save(Chocolate chocolate)
        {
            try
            {
                _chocolateService.Save(chocolate);
                return Ok(_chocolateService.Get());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _chocolateService.Delete(id);
                return Ok(_chocolateService.Get());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

