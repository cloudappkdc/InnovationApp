using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Template.DTO;
using Template.Model;
using Template.Repository;
using Template.Service;

namespace MasterWebApp.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/sample/v{ver:apiVersion}/{Id}")]
    public class SampleController : Controller
    {
        private readonly DataBaseContext _ctx;

        public SampleController(DataBaseContext dbContext)
        {
            _ctx = dbContext;
        }

        // GET: api/mymodel
        [HttpGet]
        public SampleDTO GetById(long Id)
        {
            IUnitOfWork _unitOfWork = new UnitOfWork(_ctx);
            ISampleRepository _sampleRepository = new SampleRepository(_ctx);
            var _sampleService = new SampleService(_unitOfWork, _sampleRepository);
            return _sampleService.GetById(Id);
        }

    }

    [Produces("application/json")]
    [ApiVersion("2.0")]
    [Route("api/sample/v{ver:apiVersion}")]
    public class SampleControllerV2 : Controller
    {
        private readonly DataBaseContext _ctx;

        public SampleControllerV2(DataBaseContext dbContext)
        {
            _ctx = dbContext;
        }

        [HttpGet]
        public bool Add()
        {
            bool message = false;
            List<SampleDTO> newUser = new List<SampleDTO>();
            newUser.Add(new SampleDTO() { Name = "SampleUser2", Address = "Kolkata", CreatedBy = "sample.user2", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
            IUnitOfWork _unitOfWork = new UnitOfWork(_ctx);
            ISampleRepository _sampleRepository = new SampleRepository(_ctx);
            var _sampleService = new SampleService(_unitOfWork, _sampleRepository);
            message = _sampleService.Add(newUser);
            return message;

        }


    }

    [Produces("application/json")]
    [ApiVersion("3.0")]
    [Route("api/sample/v{ver:apiVersion}/{Id}")]
    public class SampleControllerV3 : Controller
    {
        private readonly DataBaseContext _ctx;

        public SampleControllerV3(DataBaseContext dbContext)
        {
            _ctx = dbContext;
        }

        [HttpGet]
        public bool DeleteById(long Id)
        {
            SampleDTO newUser = new SampleDTO();
            IUnitOfWork _unitOfWork = new UnitOfWork(_ctx);
            ISampleRepository _sampleRepository = new SampleRepository(_ctx);
            var _sampleService = new SampleService(_unitOfWork, _sampleRepository);          
            return _sampleService.DeleteById(Id);         
        }


    }

    [Produces("application/json")]
    [ApiVersion("4.0")]
    [Route("api/sample/v{ver:apiVersion}")]
    public class SampleControllerV4 : Controller
    {
        private readonly DataBaseContext _ctx;

        public SampleControllerV4(DataBaseContext dbContext)
        {
            _ctx = dbContext;
        }

        [HttpGet]
        public bool Update()
        {            
            SampleDTO newUser = new SampleDTO();

            IUnitOfWork _unitOfWork = new UnitOfWork(_ctx);
            ISampleRepository _sampleRepository = new SampleRepository(_ctx);
            var _sampleService = new SampleService(_unitOfWork, _sampleRepository);
            newUser = _sampleService.GetById(2);
         //   newUser.Name = "Priya B";


            Sample userList = Mapper.Map<Sample>(newUser);

            //   _sampleService.Update(userList);

            //  message = _sampleService.Add(newUser);
            return _sampleService.UpdateById(1);

        }


    }
}
