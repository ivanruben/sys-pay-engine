using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManager.Models;

namespace DataManager.Repositories
{
    public class PricingRepository : IRepository<Pricing>

    {
        CalculatingPBI calculatingPBI;

        public PricingRepository()
        {
            calculatingPBI = new CalculatingPBI();

        }
        public IEnumerable<Pricing> List
        {
            get
            {
                return calculatingPBI.Pricings;
            }

        }

        public void Add(Pricing entity)
        {
            calculatingPBI.Pricings.Add(entity);
            _ = calculatingPBI.SaveChanges();
        }

        public void Delete(Pricing entity)
        {
            calculatingPBI.Pricings.Remove(entity);
            calculatingPBI.SaveChanges();
        }

        public void Update(Pricing entity)
        {
            calculatingPBI.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            calculatingPBI.SaveChanges();

        }

        public Pricing FindById(int Id)
        {
            var result = (from r in calculatingPBI.Pricings where r.Id == Id select r).FirstOrDefault();
            return result;
        }
    }
}
