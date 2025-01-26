using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PelatihanKe2.Model;
using PelatihanKe2.Model.DB;
using PelatihanKe2.Model.DTO;
using PelatihanKe2.Services;
using PelatihanKe2.Validator;
using System.Diagnostics.Eventing.Reader;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PelatihanKe2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private ValidationResult _validation;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var customerList = _customerService.GetlistCustomer();
                var response = new GeneralResponse
                {
                    StatusCode = "01",
                    Statusdesc = "Sukses",
                    Data = customerList
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var customerList = _customerService.GetlistCustomer();
                var response = new GeneralResponse
                {
                    StatusCode = "99",
                    Statusdesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };
                return BadRequest(response);
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet]
        [Route("GetCustomerById")]
        public IActionResult GetCustomerById(int id)
        {
            //var customer = _customerService.GetCustomerById(id);
            //if (customer == null)
            //{
            //    return NotFound(); // Mengembalikan status 404 jika pelanggan tidak ditemukan
            //}
            //return Ok(customer); // Mengembalikan data pelanggan


            try
            {
                var customer = _customerService.GetCustomerById(id);
                if (customer == null)
                {
                    var responseNotFound = new GeneralResponse
                    {
                        StatusCode = "02",
                        Statusdesc = "Customer Not Found",
                        Data = null
                    };
                    return NotFound(responseNotFound);
                }

                var responseSuccess = new GeneralResponse
                {
                    StatusCode = "01",
                    Statusdesc = "Success",
                    Data = customer
                };
                return Ok(responseSuccess);
            }
            catch (Exception ex)
            {
                var responseFailed = new GeneralResponse
                {
                    StatusCode = "99",
                    Statusdesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };
                return BadRequest(responseFailed);
            }
        }

        // POST api/<CustomerController>
        [HttpPost("InserDataCustomer")]
        public IActionResult Post(CustomerRequestDTO customer)
        {
           try
           {
                ValidatorRequestCustomer request = new ValidatorRequestCustomer();
                _validation = request.Validate(customer);

                if (_validation.IsValid)
                {
                    var InsertCustomer = _customerService.CreateCustomer(customer);
                    if (InsertCustomer)
                    {
                        var responseSuccess = new GeneralResponse
                        {
                            StatusCode = "01",
                            Statusdesc = "Insert Customer Success",
                            Data = null
                        };

                        return Ok(responseSuccess);
                    }

                    var responseFailed = new GeneralResponse
                    {
                        StatusCode = "02",
                        Statusdesc = "Insert Customer Failed",
                        Data = null
                    };


                    return BadRequest(responseFailed);
                }else
                {
                    var responseFailed = new GeneralResponse
                    {
                        StatusCode = "02",
                        Statusdesc = _validation.ToString(),
                        Data = null
                    };

                    return BadRequest(responseFailed);

                }
           }
           catch (Exception ex)
            {
                var responseFailed = new GeneralResponse
                {
                    StatusCode = "99",
                    Statusdesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };

                return BadRequest(responseFailed);
            }

        }

        // PUT api/<CustomerController>/5
        [HttpPut("UpdateDataCustomer")]
        public IActionResult Put(int Id, CustomerRequestDTO customer)
        {
            try
            {
                var dataUpdate = _customerService.UpdateCustomer(Id, customer);
                if(dataUpdate)
                {
                    var responseSuccess = new GeneralResponse
                    {
                        StatusCode = "01",
                        Statusdesc = "Update Customer Success",
                        Data = null
                    };

                    return Ok(responseSuccess);
                    //return Ok("Data Berhasil Diupdate");
                }

                var responseFailed = new GeneralResponse
                {
                    StatusCode = "02",
                    Statusdesc = "Update Customer Failed",
                    Data = null
                };

                return BadRequest(responseFailed);

            }
            catch (Exception ex)
            {
                var responseFailed = new GeneralResponse
                {
                    StatusCode = "99",
                    Statusdesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };

                return BadRequest(responseFailed);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete]
        [Route("DeleteCustomerById")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = _customerService.DeleteCustomer(id);
                if (data)
                {
                    var responseSuccess = new GeneralResponse
                    {
                        StatusCode = "01",
                        Statusdesc = "Delete Customer Success",
                        Data = null
                    };

                    return Ok(responseSuccess);
                    //return Ok("Data Berhasil Dihapus");
                }

                var responseFailed = new GeneralResponse
                {
                    StatusCode = "02",
                    Statusdesc = "Delete Customer Failed",
                    Data = null
                };

                return BadRequest(responseFailed);
            }
            catch (Exception ex)
            {
                var responseFailed = new GeneralResponse
                {
                    StatusCode = "99",
                    Statusdesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };

                return BadRequest(responseFailed);
            }
        }
    }
}
