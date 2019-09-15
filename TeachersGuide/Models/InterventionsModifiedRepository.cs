using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TeachersGuide.Models
{
    public class InterventionsModifiedRepository:IInterventionsModifiedRepository
    {
        private AppDbContext _appDbContext;         //change to readonly
        public InterventionsModifiedRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<InterventionsModified> GetAll()
        {
            return _appDbContext.InterventionsModified;
        }

        public bool addNewIntervention(InterventionsModified newIntervention)
        {
            _appDbContext.InterventionsModified.Add(newIntervention);
            _appDbContext.SaveChanges();
            return true;
        }

        public InterventionsModified getId(long id)
        {
            return _appDbContext.InterventionsModified.Find(id);
        }

        public bool edit(InterventionsModified interventionsModified)
        {
            //InterventionsModified interventionToEdit = _appDbContext.InterventionsModified.Find(interventionsModified.id);
            _appDbContext.Entry(interventionsModified).State = EntityState.Modified;
            Console.Write("DatatobeEdited :: ");
            Console.Write(interventionsModified.id);
            Console.Write(interventionsModified.articleLink);
            //_appDbContext.InterventionsModified.Update(interventionsModified);
            try
            {
                _appDbContext.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;

        }

        public bool delete(long id)
        {
            InterventionsModified interventionToRemove = _appDbContext.InterventionsModified.Find(id);
            _appDbContext.Remove(interventionToRemove);
            try
            {
                _appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
