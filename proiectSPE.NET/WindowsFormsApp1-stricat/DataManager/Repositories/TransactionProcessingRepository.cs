using DataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Repositories
{
    public class TransactionProcessingRepository : IRepository<TransactionProcessing>
    {

        CalculatingPBI calculatingPBI;

        public TransactionProcessingRepository()
        {
            calculatingPBI = new CalculatingPBI();

        }
        public IEnumerable<TransactionProcessing> List
        {
            get
            {
                return calculatingPBI.TransactionProcessings;
            }

        }

        public void Add(TransactionProcessing entity)
        {
            calculatingPBI.TransactionProcessings.Add(entity);
            _ = calculatingPBI.SaveChanges();
        }

        public void Delete(TransactionProcessing entity)
        {
            calculatingPBI.TransactionProcessings.Remove(entity);
            calculatingPBI.SaveChanges();
        }

        public void Update(TransactionProcessing entity)
        {
            calculatingPBI.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            calculatingPBI.SaveChanges();

        }

        public TransactionProcessing FindById(int Id)
        {
            var result = (from r in calculatingPBI.TransactionProcessings where r.Id == Id select r).FirstOrDefault();
            return result;
        }
    }
}
