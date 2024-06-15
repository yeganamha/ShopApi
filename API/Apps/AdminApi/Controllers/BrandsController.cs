using Core.Entities;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Apps.AdminApi.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public BrandsController(ShopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var data = _context.Brands.ToList();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            var data = _context.Brands.Find(id);

            if (data == null) return NotFound();

            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            //if (_context.Brands.Any(x => x.Name == brand.Name))
            //{
            //    ModelState.AddModelError("Name", "Brand already exist");
            //}

            //return BadRequest(ModelState);

            _context.Brands.Add(brand);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, brand);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Brand brand)
        {
            var existData = _context.Brands.Find(id);

            if(existData==null) return NotFound();

            if (existData.Name != brand.Name && _context.Brands.Any(x => x.Name == brand.Name))
            {
                ModelState.AddModelError("Name", "Brand already exist");
                
                return BadRequest(ModelState);
            }

            existData.Name=brand.Name;
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.Brands.Find(id);
            if (data==null) return NotFound();
            _context.Brands.Remove(data);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
