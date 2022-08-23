using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NYToDoListApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ToDoRepository doRepository;

        public TodosController()
        {
            doRepository = new ToDoRepository();
        }
        [HttpGet]
        public IEnumerable<ToDo> Get()
        {
            return doRepository.GetAll();
        }
        [HttpGet("{id}")]
        public ToDo Get(int id)
        {
            return doRepository.GetById(id);
        }
        [HttpPost]
        public void Post([FromBody] ToDo to)
        {
            if (ModelState.IsValid)
            {
                doRepository.AddTo(to);
            }
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ToDo to)
        {
            to.Id = id;
            if (ModelState.IsValid)
            {
                doRepository.Update(to);
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            doRepository.Delete(id);
        }
    }
}
