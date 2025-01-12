namespace PelatihanKe2.Model.DB
{
    public class Customer
    {
        public int Id { get; set; }//id primary key dan aouto incremenet
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
