using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using PelatihanKe2.Migrations;
using PelatihanKe2.Model;
using PelatihanKe2.Model.DB;
using PelatihanKe2.Model.DTO;

namespace PelatihanKe2.Services
{
    public class CustomerService
    {
        private readonly ApplicationConteks _conteks;

        public CustomerService(ApplicationConteks conteks)
        {
            _conteks = conteks;
        }

        public List<CustomerDTO> GetlistCustomer()
        {
            var data = _conteks.Customers.Select(x => new CustomerDTO
            {
                Id = x.Id.ToString(),
                Name = x.Name,
                Address = x.Address,
                City = x.City,
                PhoneNumber = x.PhoneNumber,
                CreateDate = x.CreateDate != null ? x.CreateDate.Value.ToString("dd/MM/yyy HH:mm:ss") : "",
                UpdateDate = x.UpdateDate != null ? x.UpdateDate.Value.ToString("dd/MM/yyy HH:mm:ss") : "",

            }).ToList();

            return data;
        }

        // Mendapatkan satu data pelanggan berdasarkan ID
        //[Route(GetDataById)]

        public Customer GetCustomerById(int id)
        {
            return _conteks.Customers.FirstOrDefault(x => x.Id == id); // Mengembalikan satu pelanggan dengan ID tertentu
        }

        public bool CreateCustomer(CustomerRequestDTO customer)
        {
            try
            {
                var insertDataCustomer = new Customer
                {
                    
                    Name = customer.Name,
                    Address = customer.Address,
                    City = customer.City,
                    PhoneNumber = customer.PhoneNumber,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                };
                _conteks.Customers.Add(insertDataCustomer);
                _conteks.SaveChanges();

                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateCustomer(int Id, CustomerRequestDTO customer)
        {
            try
            {
                var customerOld = _conteks.Customers.Where(x => x.Id == Id).FirstOrDefault();
                if (customerOld != null)
                {
                    customerOld.Name = customer.Name;
                    customerOld.Address = customer.Address;
                    customerOld.City = customer.City;
                    customerOld.PhoneNumber = customer.PhoneNumber;
                    customerOld.UpdateDate = DateTime.Now;

                    _conteks.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;

            }
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                var customer = _conteks.Customers.FirstOrDefault(x => x.Id == id);
                if (customer != null)
                {
                    _conteks.Customers.Remove(customer);
                    _conteks.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw; // Bisa juga diganti dengan return false jika tidak ingin melempar exception
            }
        }


    }


}
