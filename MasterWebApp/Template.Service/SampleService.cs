using Template.DTO;
using Template.Model;
using Template.Repository;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;

namespace Template.Service
{
    public class SampleService : EntityService<Sample>, ISampleService
    {
        IUnitOfWork _unitOfWork;
        ISampleRepository _SampleRepository;

        public SampleService(IUnitOfWork unitOfWork, ISampleRepository SampleRepository)
            : base(unitOfWork, SampleRepository)
        {
            _unitOfWork = unitOfWork;
            _SampleRepository = SampleRepository;
        }


        public SampleDTO GetById(long Id)
        {
            return Mapper.Map<SampleDTO>(_SampleRepository.GetById(Id));
        }
      
        //Add new users
        public bool Add(List<SampleDTO> entity)
        {
            bool message = false;
            List<Sample> userList = new List<Sample>();
            userList = Mapper.Map<List<Sample>>(entity);
            message = _SampleRepository.Add(userList);
            return message;
        }

        public bool DeleteById(long Id)
        {
            SampleDTO dto = new SampleDTO() { Id=Id};

            Sample sample = Mapper.Map<Sample>(dto);
            return _SampleRepository.DeleteById(Id);
           
        }

        public bool UpdateById(long Id)
        {
            return _SampleRepository.UpdateById(Id);
        }
    }
}
