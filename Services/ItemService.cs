using PelatihanKe2.Model.DB;
using PelatihanKe2.Model;

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
                throw;
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
                throw;
            }

        }
    }
}
