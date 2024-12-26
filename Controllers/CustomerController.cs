using Microsoft.AspNetCore.Mvc;
using PelatihanKe2.Model.DB;
using PelatihanKe2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PelatihanKe2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            var customerList = _customerService.GetlistCustomer();
            return Ok(customerList);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound(); // Mengembalikan status 404 jika pelanggan tidak ditemukan
            }
            return Ok(customer); // Mengembalikan data pelanggan
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            var InsertCustomer = _customerService.CreateCustomer(customer);
            if(InsertCustomer)
            {
                return Ok("Insert Customer Success");
            }
            return BadRequest("Insert Customer Failed");
        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        public IActionResult Put(Customer customer)
        {
            try
            {
                var dataUpdate = _customerService.UpdateCustomer(customer);
                if(dataUpdate)
                {
                    return Ok("Data Berhasil Diupdate");
                }
                return BadRequest("Update data gagal");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
                throw;
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = _customerService.DeleteCustomer(id);
                if (data)
                {
                    return Ok("Data Berhasil Dihapus");
                }

                return NotFound("Data Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message.ToString());
                return BadRequest($"Terjadi Kesalahan : {ex.Message}");
            }
        }
    }
}
