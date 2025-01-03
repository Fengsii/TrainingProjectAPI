using System.ComponentModel.DataAnnotations;

namespace PelatihanKe2.Model.DB
{
    public class Item
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama Item wajib diisi")]
        [RegularExpression(@"^(?! )[A-Za-z]+(?: [A-Za-z]+){0,3}(?<! )$",
            ErrorMessage = "Nama hanya boleh huruf, tidak boleh ada spasi di awal/akhir, tidak boleh spasi berturut-turut, dan maksimal 3 spasi")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Panjang supplier harus 5-15 karakter")]
        public string NamaItem { get; set; }

        [Required(ErrorMessage = "Quantity wajib diisi")]
        [Range(50, 1000, ErrorMessage = "Quantity harus Minimal 50 sampai 1000")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "Tanggal Expire wajib diisi")]
        public DateTime TglExpire { get; set; }

        [Required(ErrorMessage = "Supplier wajib diisi")]
        [RegularExpression(@"^(?! )[A-Za-z]+(?: [A-Za-z]+){0,3}(?<! )$",
            ErrorMessage = "Supplier hanya boleh huruf, tidak boleh ada spasi di awal/akhir, tidak boleh spasi berturut-turut, dan maksimal 3 spasi")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Panjang supplier harus 5-20 karakter")]
        public string Supplier { get; set; }
 
        [RegularExpression(@"^$|^Jl\.\s[A-Za-z]+(?:\s[A-Za-z]+)*\sNo\.\s\d+,\sRT\s\d+/RW\s\d+,\sKelurahan\s[A-Za-z]+(?:\s[A-Za-z]+)*,\sKecamatan\s[A-Za-z]+(?:\s[A-Za-z]+)*,\s[A-Za-z]+(?:\s[A-Za-z]+)*,\s[A-Za-z]+(?:\s[A-Za-z]+)*,\s\d{5}$",
            ErrorMessage = "Format alamat tidak sesuai. Contoh: Jl. Sudirman No. 45, RT 03/RW 05, Kelurahan Menteng, Kecamatan Menteng, Jakarta Pusat, DKI Jakarta, 10310")]
        public string? AlamatSupplier { get; set; }
    }
}
