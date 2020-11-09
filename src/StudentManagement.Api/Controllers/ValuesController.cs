using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.DataAccess;

namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ValuesRepository _repository;

        public ValuesController(ValuesRepository repository)
        {
            _repository = repository??throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet]
        public async Task<List<Value>> Get()
        {
            return await _repository.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
            var response = await _repository.GetById(id);
            if (response == null) { return NotFound(); }
            return response;
        }
        [HttpPost]
        public async Task Post([FromBody] Value value) {
            await _repository.Insert(value);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteById(id);
        }


    }
}
