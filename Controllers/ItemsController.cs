using Microsoft.AspNetCore.Mvc;
using PelatihanKe2.Model.DB;
using PelatihanKe2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PelatihanKe2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemsController(ItemService itemService)
        {
            _itemService = itemService;
        }


        // GET: api/<ItemsController>
        [HttpGet]
        public IActionResult Get()
        {
            var itemList = _itemService.GetListItems();
            return Ok(itemList);
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _itemService.GetItemById(id);

            if (item == null)
            {
                return NotFound("Data Tidak Ditemukan");
            }

            return Ok(item);
        }

        // POST api/<ItemsController>
        [HttpPost]
        public IActionResult Post(Item item)
        {
            var itemt = _itemService.CreateItems(item);
            if(itemt)
            {
                return Ok("Insert Customer Success");
            }

            return BadRequest("Insert Customer Failed");

        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Item item)
        {
           try
            {
                var dataup = _itemService.UpdateItems(item);
                if(dataup)
                {
                    return Ok("Data Berhasil Diupdate");
                }
                return BadRequest("Update data gagal");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
                throw;
            }
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = _itemService.DeleteItems(id);
                if(data)
                {
                    return Ok("Data Berhasil Dihapus");
                }

                return NotFound("Data Tidak Ditemukan");
            }
            catch(Exception ex)
            {
                //return BadRequest(ex.Message.ToString());
                return BadRequest($"Terjadi Kesalahan : {ex.Message}");
            }
        }
    }
}
