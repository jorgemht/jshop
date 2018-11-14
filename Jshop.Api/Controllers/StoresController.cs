namespace Jshop.Api.Controllers
{
    using Jshop.Domain;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StoresController : ControllerBase
    {
        private readonly MainDbContext _context;

        public StoresController(MainDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Store> GetStores()
        {
            try
            {
                var x = _context.Stores;
            }
            catch (Exception)
            {

                throw;
            }
            return _context.Stores;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStore([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var store = await _context.Stores.FindAsync(id);

            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStore([FromRoute] long id, [FromBody] Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != store.StoreId)
            {
                return BadRequest();
            }

            _context.Entry(store).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostStore([FromBody] Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Stores.Add(store);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStore", new { id = store.StoreId }, store);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var store = await _context.Stores.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }

            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();

            return Ok(store);
        }

        private bool StoreExists(long id)
        {
            return _context.Stores.Any(e => e.StoreId == id);
        }
    }
}