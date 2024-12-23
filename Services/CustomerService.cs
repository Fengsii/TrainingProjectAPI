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
    }
    
    
}
