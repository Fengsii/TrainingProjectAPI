using Microsoft.EntityFrameworkCore;
using PelatihanKe2.Model;
using PelatihanKe2.Model.DB;

namespace PelatihanKe2.Services
{
    public class CustomerService
    {
        private readonly ApplicationConteks _conteks;

        public CustomerService(ApplicationConteks conteks)
        {
            _conteks = conteks;
        }

        public List<Customer> GetlistCustomer()
        {
            var data = _conteks.Customers.ToList();
            return data;
        }

        // Mendapatkan satu data pelanggan berdasarkan ID
        public Customer GetCustomerById(int id)
        {
            return _conteks.Customers.FirstOrDefault(x => x.Id == id); // Mengembalikan satu pelanggan dengan ID tertentu
        }

        public bool CreateCustomer(Customer customer)
        {
            try
            {
                _conteks.Customers.Add(customer);
                _conteks.SaveChanges();

                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                var customerOld = _conteks.Customers.Where(x => x.Id == customer.Id).FirstOrDefault();
                if (customerOld != null)
                {
                    customerOld.Name = customer.Name;
                    customerOld.Address = customer.Address;
                    customerOld.City = customer.City;
                    customerOld.PhoneNumber = customer.PhoneNumber;

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
