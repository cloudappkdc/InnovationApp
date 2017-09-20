using System.Collections.Generic;
using Template.Model;

namespace Template.Repository
{
    public interface ISampleRepository : IGenericRepository<Sample>
    {
        Sample GetById(long id);
        bool Add(List<Sample> entity);
        bool DeleteById(long Id);
        bool UpdateById(long Id);
    }
}
