using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
              new Car{Id=1, BrandId=1, ColorId=1, ModelYear=2011, DailyPrice=2500, Description="Mercedes"},
              new Car{Id=2, BrandId=1, ColorId=3, ModelYear=2015, DailyPrice=1800, Description="Mustang"},
              new Car{Id=3, BrandId=2, ColorId=5, ModelYear=1965, DailyPrice=1000, Description="Ford"},
              new Car{Id=4, BrandId=3, ColorId=7, ModelYear=2009, DailyPrice=1200, Description="Toyota"}

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id); //lambda işareti
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int BrandId)
        {
            return _cars.Where(p => p.BrandId == BrandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}