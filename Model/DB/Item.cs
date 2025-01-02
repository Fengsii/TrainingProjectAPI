using System.ComponentModel.DataAnnotations;

namespace PelatihanKe2.Model.DB
{
    public class Item
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama Item wajib diisi")]
        [MaxLength(18, ErrorMessage = "Maximal 18 Karakter")]
        [MinLength(6, ErrorMessage = "Minimal Inputan 6 Karakter")]
        public string NamaItem { get; set; }

        [Required(ErrorMessage = "Quantity wajib diisi")]
        [Range(50, 1000, ErrorMessage = "Quantity harus Minimal 50 sampai 1000")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "Tanggal Expire wajib diisi")]
        public DateTime TglExpire { get; set; }

        [Required(ErrorMessage = "Supplier wajib diisi")]
        [MaxLength(20, ErrorMessage = "Maximal 20 Karakter")]
        [MinLength(5, ErrorMessage = "Minimal Inputan 5 Karakter")]
        public string Supplier { get; set; }

        [MaxLength(25, ErrorMessage = "Maximal 25 Karakter")]
        [MinLength(8, ErrorMessage = "Minimal Inputan 8 Karakter")]
        public string? AlamatSupplier { get; set; }
    }
}
