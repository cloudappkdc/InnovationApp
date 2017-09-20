using System.Collections.Generic;
using Template.DTO;
using Template.Model;

namespace Template.Service
{
    public interface ISampleService : IEntityService<Sample>
    {
        SampleDTO GetById(long Id);
        bool Add(List<SampleDTO> entity);
        bool UpdateById(long Id);
    }
}
