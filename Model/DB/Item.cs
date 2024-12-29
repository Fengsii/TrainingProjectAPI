using System.ComponentModel.DataAnnotations;

namespace PelatihanKe2.Model.DB
{
    public class Item
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama Item wajib diisi")]
        [StringLength(100, ErrorMessage = "Nama Item tidak boleh lebih dari 100 karakter")]
        public string NamaItem { get; set; }

        [Required(ErrorMessage = "Quantity wajib diisi")]
        [Range(50, 1000, ErrorMessage = "Quantity harus Minimal 50 sampai 1000")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "Tanggal Expire wajib diisi")]
        public DateTime TglExpire { get; set; }

        [Required(ErrorMessage = "Supplier wajib diisi")]
        [StringLength(100, ErrorMessage = "Supplier tidak boleh lebih dari 100 karakter")]
        public string Supplier { get; set; }

        [StringLength(100, ErrorMessage = "Alamat Supplier tidak boleh lebih dari 100 karakter")]
        public string? AlamatSupplier { get; set; }
    }
}
