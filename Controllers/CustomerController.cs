using Microsoft.AspNetCore.Mvc;
using RestServer.Data;
using RestServer.Model;
using System.Collections.Generic;

namespace RestServer.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerDataContext _repository;
        public CustomerController(CustomerDataContext repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            var customers = _repository.GetCustomers();
            return Ok(customers);
        }

        [HttpPost]
        public ActionResult<IEnumerable<Customer>> AddCustomer([FromBody] List<Customer> customers)
        {
            var customerList = _repository.AddCustomer(customers);
            return Ok(customerList);
        }
    }
}
