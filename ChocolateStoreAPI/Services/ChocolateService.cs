using ChocolateStoreAPI.DataFile;
using ChocolateStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChocolateStoreAPI.Services
{
    public class ChocolateService : IChocolateService
    {
        private IEnumerable<Chocolate> _chocolates;
        private IDataAccess<Chocolate> _dataAccess;

        public ChocolateService()
        {
            if(this._dataAccess == null)
            {
                _dataAccess = new DataAccess<Chocolate>();
            }

            _chocolates = this._dataAccess.Read();
        }

        public void Delete(int id)
        {
            if (_chocolates.Count() == 0)
            {
                throw new Exception("No list found.");
            }

            var chocolate = _chocolates.SingleOrDefault(x => x.Id == id);
            if (chocolate == null)
            {
                throw new Exception("No mobile with that id found");
            }
            _chocolates = _chocolates.Where(ch => ch.Id != id).ToList();
            _dataAccess.Save(_chocolates);
        }

        public IEnumerable<Chocolate> Get()
        {
            if (_chocolates.Count() == 0)
            {
                throw new Exception("No list found.");
            }
            return new List<Chocolate>().Concat(_chocolates);
        }

        public Chocolate GetByID(int id)
        {
            var chocolate = _chocolates.SingleOrDefault(x => x.Id == id);
            if (chocolate == null)
            {
                throw new Exception("No mobile with that id found");
            }
            return chocolate;
        }

        public void Save(Chocolate chocolate)
        {
            _chocolates = _chocolates.Concat(new List<Chocolate>() { chocolate });
            _dataAccess.Save(_chocolates);
        }
    }
}
