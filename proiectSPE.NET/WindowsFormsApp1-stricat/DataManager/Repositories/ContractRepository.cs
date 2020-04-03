using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManager.Models;

namespace DataManager.Repositories
{
    public class ContractRepository : IRepository<Contract>

    {
        CalculatingPBI calculatingPBI;

        public ContractRepository()
        {
            calculatingPBI = new CalculatingPBI();

        }
        public IEnumerable<Contract> List
        {
            get
            {
                return calculatingPBI.Contract;
            }

        }

        public void Add(Contract entity)
        {
            calculatingPBI.Contract.Add(entity);
            _ = calculatingPBI.SaveChanges();
        }

        public void Delete(Contract entity)
        {
            calculatingPBI.Contract.Remove(entity);
            calculatingPBI.SaveChanges();
        }

        public void Update(Contract entity)
        {
            calculatingPBI.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            calculatingPBI.SaveChanges();

        }

        public Contract FindById(int Id)
        {
            var result = (from r in calculatingPBI.Contract where r.Id == Id select r).FirstOrDefault();
            return result;
        }

    }
}
