using ChocolateStoreAPI.DataFile;
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
        private List<Chocolate> _chocolates;
        private IDataAccess<Chocolate> _dataAccess;

        public ChocolateController(IDataAccess<Chocolate> _dataAccess)
        {
            this._dataAccess = _dataAccess;
            this._chocolates = _dataAccess.Read();
        }
        
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
            _dataAccess.Save(_chocolates);
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
            _dataAccess.Save(_chocolates);
            return Ok(_chocolates);
        }
    }
}

