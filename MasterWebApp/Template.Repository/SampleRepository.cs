using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Template.Model;

namespace Template.Repository
{
    public class SampleRepository : GenericRepository<Sample>, ISampleRepository
    {       
        public SampleRepository(DbContext context)
            : base(context)
        {
            
        }

        

        public override IEnumerable<Sample> GetAll()
        {
            return _entities.Set<Sample>().Include(x => x.Name).AsEnumerable();
        }

        public Sample GetById(long id)
        {
            //return _dbset.Where(x => x.Id == id).FirstOrDefault();            
            return _dbset.Find(id);
        }

        public bool Add(List<Sample> entity)
        {
            try
            {
                foreach (var item in entity)
                {
                    _dbset.Add(item);
                    
                }
                _entities.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
                throw (ex);                
            }
        }

        public bool DeleteById(long Id)
        {
            Sample sample = new Sample() { Id = Id };
            _dbset.Attach(sample);
            _dbset.Remove(sample);

            try
            {
                _entities.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {

            }
            return false;
        }

        public bool UpdateById(long Id)
        {
            Sample sample = new Sample() { Id = Id };
            sample.Name = "Priya B.";
            _dbset.Attach(sample);            
            _entities.Entry(sample).State = EntityState.Modified;          
            return true;
        }

 

       
       
    }
}
