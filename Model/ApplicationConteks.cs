using Microsoft.EntityFrameworkCore;
using PelatihanKe2.Model.DB;

namespace PelatihanKe2.Model
{
    public class ApplicationConteks: DbContext
    {
        public ApplicationConteks(DbContextOptions<ApplicationConteks> options) : base(options) 
        { 

        }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}
