using PelatihanKe2.Model.DB;
using PelatihanKe2.Model;
using Microsoft.EntityFrameworkCore;

namespace PelatihanKe2.Services
{
    public class ItemService
    {
        private readonly ApplicationConteks _conteks;

        public ItemService(ApplicationConteks conteks)
        {
            _conteks = conteks;
        }

        public List<Item> GetListItems()
        {
            var data = _conteks.Items.ToList();
            return data;
        }

        public Item GetItemById(int id)
        {
            return _conteks.Items.FirstOrDefault(x => x.Id == id);
        }

        public bool CreateItems(Item item)
        {
           try
           {
                if (item.TglExpire <= DateTime.Today || item.TglExpire > DateTime.Today.AddDays(2))
                {
                    throw new Exception("Tanggal expire harus 1-2 hari ke depan");
                }

                _conteks.Items.Add(item);
                _conteks.SaveChanges();
                return true;
           }
           catch (Exception)
           {
                return false;
           }
           
        }

        public bool UpdateItems(Item item)
        {
            try
            {
                var ItemOld = _conteks.Items.Where(x => x.Id == item.Id).FirstOrDefault();

                if (item.TglExpire <= DateTime.Today || item.TglExpire > DateTime.Today.AddDays(2))
                {
                    throw new Exception("Tanggal expire harus 1-2 hari ke depan");
                }

                if (ItemOld != null)
                {
                    ItemOld.NamaItem = item.NamaItem;
                    ItemOld.Qty = item.Qty;
                    ItemOld.TglExpire = item.TglExpire;
                    ItemOld.Supplier = item.Supplier;
                    ItemOld.AlamatSupplier = item.AlamatSupplier;

                    _conteks.SaveChanges();

                    return true;
                }

                return false;
            }
            catch
            {
                throw new Exception("Item tidak ditemukan");
            }
        }

        public bool DeleteItems(int id)
        {
            try
            {
                var dataItem = _conteks.Items.FirstOrDefault(x => x.Id == id);
                if (dataItem != null)
                {
                    _conteks.Items.Remove(dataItem);
                    _conteks.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw new Exception("Item tidak ditemukan");
            }

        }
    }
}
