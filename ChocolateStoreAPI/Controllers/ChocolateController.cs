using ChocolateStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ChocolateStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChocolateController : ControllerBase
    {
        private static List<Chocolate> _chocolates = new List<Chocolate>()
        { 
            new Chocolate(){Id = 1, Brand = "Snickers",Price = 500 },
            new Chocolate(){Id = 2, Brand = "Baunty",Price = 400 },
            new Chocolate(){Id = 3, Brand = "Twix",Price = 300 },
            new Chocolate(){Id = 4, Brand = "Mars",Price = 250 }
        };

        [HttpGet]
        public IActionResult Gets()
        {
            if (_chocolates.Count == 0)
            {
                return NotFound("No list found.");
            }
            return Ok(_chocolates);
        }

        [HttpGet("GetMobile")]
        public IActionResult Get(int id)
        {
            var chocolate = _chocolates.SingleOrDefault(x => x.Id == id);
            if (chocolate == null)
            {
                return NotFound("No mobile with that id found");
            }
            return Ok(chocolate);
        }


        [HttpPost]
        public IActionResult Save(Chocolate chocolate)
        {
            _chocolates.Add(chocolate);
            if (_chocolates.Count == 0)
            {
                return NotFound("No list found.");
            }
            return Ok(_chocolates);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var chocolate = _chocolates.SingleOrDefault(x => x.Id == id);
            if (chocolate == null)
            {
                return NotFound("No mobile with that id found");
            }
            _chocolates.Remove(chocolate);
            if (_chocolates.Count == 0)
            {
                return NotFound("No list found.");
            }
            return Ok(_chocolates);
        }
    }
}

